using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Access_SQL_Query_Tool
{
    public partial class SqlQuery : Form
    {
        private readonly IConfiguration _configuration;
        public SqlQuery(IConfiguration configuration)
        {
            InitializeComponent();
            _configuration = configuration;
            LblDatabaseFilename.Text = _configuration["AppSettings:DatabasePath"];
        }

        private void CmdExecute_Click(object sender, EventArgs e)
        {
            ExecuteQuery();
        }

        private void RtbQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Alt) == Keys.Alt && e.KeyCode == Keys.X)
            {
                ExecuteQuery();
                e.SuppressKeyPress = true;
            }
        }

        private string GetSQL(RichTextBox rtb)
        {
            StringBuilder sb = new();
            foreach (var line in from line in rtb.Lines
                                 where !line.TrimStart().StartsWith("--")
                                 select line)
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }
        private void ExecuteQuery()
        {
            var dbPath = _configuration["AppSettings:DatabasePath"];
            if (!File.Exists(dbPath))
            {
                if (dbPath == null) dbPath = "";
                dbPath = SelectDatabase(dbPath);
                if (File.Exists(dbPath)) UpdateAppSettings("AppSettings:DatabasePath", dbPath);
                LblDatabaseFilename.Text = dbPath;
            }

            var cnnString = $"Provider=Microsoft.ACE.OLEDB.16.0; Data Source=\"{dbPath}\";";

            string sql = GetSQL(RtbQuery);
            DataTable dt = new("Result");

            TabQueryOutput.Text = "Output";
            TabQueryOutput.Refresh();
            RtbMessageOutput.Clear();
            GrdOutput.DataSource = null;
            GrdOutput.Refresh();

            using (OleDbConnection db = new(cnnString))
            {
                try
                {
                    OleDbCommand cmd = new(sql, db);
                    db.Open();
                    Stopwatch sw = new();
                    sw.Start();
                    dt.Load(cmd.ExecuteReader());
                    sw.Stop();
                    TabQueryOutput.Text = $"Output: {dt.Rows.Count} recs in {sw.ElapsedMilliseconds / 1000} seconds";
                    GrdOutput.DataSource = dt;
                    GrdOutput.Refresh();
                    TabOutputAndMessage.SelectTab(0);
                }
                catch (Exception ex)
                {
                    RtbMessageOutput.Text = $"Query Length: {sql.Length}\nMessage: {ex.Message}";
                    TabOutputAndMessage.SelectTab(1);
                }
                finally
                {
                    if (db.State != ConnectionState.Closed)
                    {
                        db.Close();
                    }
                }
            }
        }

        private void LblDatabaseFilename_Click(object sender, EventArgs e)
        {
            var dbPath = _configuration["AppSettings:DatabasePath"];
            if (dbPath == null) dbPath = "";
            dbPath = SelectDatabase(dbPath);
            if (File.Exists(dbPath))
            {
                UpdateAppSettings("AppSettings:DatabasePath", dbPath);
                LblDatabaseFilename.Text = dbPath;
            }
        }

        private string SelectDatabase(string startAt = "")
        {
            using (OpenFileDialog ofd = new()
            {
                Title = "Please select and open MS Access database file",
                Filter = "MS Access Databases (*.accdb)|*.accdb",
                FileName = startAt
            }
            )
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
            }
            return startAt;
        }

        private void CmdExecuteNonQuery_Click(object sender, EventArgs e)
        {
            var dbPath = _configuration["AppSettings:DatabasePath"]; ;
            if (!File.Exists(dbPath))
            {
                if (dbPath == null) dbPath = "";
                dbPath = SelectDatabase(dbPath);
                if (File.Exists(dbPath)) UpdateAppSettings("AppSettings:DatabasePath", dbPath);
                LblDatabaseFilename.Text = dbPath;
            }

            var cnnString = $"Provider=Microsoft.ACE.OLEDB.16.0; Data Source=\"{dbPath}\";";

            string sql = GetSQL(RtbQuery);
            DataTable dt = new("Result");

            TabQueryOutput.Text = "Output";
            TabQueryOutput.Refresh();
            RtbMessageOutput.Clear();
            GrdOutput.DataSource = null;
            GrdOutput.Refresh();

            using (OleDbConnection db = new(cnnString))
            {
                try
                {
                    OleDbCommand cmd = new(sql, db);
                    db.Open();
                    Stopwatch sw = new();
                    sw.Start();
                    //dt.Load(cmd.ExecuteReader());
                    int rc = cmd.ExecuteNonQuery();
                    sw.Stop();
                    RtbMessageOutput.Text = $"Output: {rc} recs in {sw.ElapsedMilliseconds / 1000} seconds";
                    GrdOutput.DataSource = null;// dt;
                    GrdOutput.Refresh();
                    TabOutputAndMessage.SelectTab(1);
                }
                catch (Exception ex)
                {
                    RtbMessageOutput.Text = $"Query Length: {sql.Length}\nMessage: {ex.Message}";
                    TabOutputAndMessage.SelectTab(1);
                }
                finally
                {
                    if (db.State != ConnectionState.Closed)
                    {
                        db.Close();
                    }
                }
            }
        }

        private void RtbQuery_TextChanged(object sender, EventArgs e)
        {
            FormatSQL(RtbQuery);
        }

        private void FormatSQL(RichTextBox richTextBox)
        {
            // Save the current selection
            int selectionStart = richTextBox.SelectionStart;
            int selectionLength = richTextBox.SelectionLength;

            // Define SQL keywords
            string[] keywords = { "SELECT", "FROM", "WHERE", "INSERT", "UPDATE", "DELETE", "JOIN", "INNER", "LEFT", "RIGHT", "ON", "AS", "AND", "OR", "NOT", "NULL", "IN", "LIKE", "BETWEEN", "GROUP", "BY", "ORDER", "HAVING", "DISTINCT", "TOP", "LIMIT" };

            // Clear previous formatting
            richTextBox.SelectAll();
            richTextBox.SelectionColor = Color.Black;

            // Apply formatting
            foreach (string keyword in keywords)
            {
                Regex regex = new Regex($@"\b{keyword}\b", RegexOptions.IgnoreCase);
                foreach (Match match in regex.Matches(richTextBox.Text))
                {
                    richTextBox.Select(match.Index, match.Length);
                    richTextBox.SelectionColor = Color.Blue;
                    richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                }
            }

            // Restore the original selection
            richTextBox.Select(selectionStart, selectionLength);
            richTextBox.SelectionColor = Color.Black;
        }

        private static void UpdateAppSettings(string key, string value)
        {
            var f = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            if (File.Exists(f))
            {
                string json = File.ReadAllText(f);
                JObject jsonObj = JObject.Parse(json);
                string[] sectionPath = key.Split(':');
                JToken section = jsonObj;
                if (section != null && sectionPath != null && sectionPath.Length > 0)
                {
                    for (int i = 0; i < sectionPath.Length - 1; i++)
                    {
                        section = section[sectionPath[i]];
                    }
                    section[sectionPath[^1]] = value; // Update the value
                    File.WriteAllText(f, jsonObj.ToString());
                }
            }
        }

        private void SqlQuery_Load(object sender, EventArgs e)
        {
            RtbQuery.Text = _configuration["AppSettings:LastSQL"];
        }

        private void SqlQuery_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (RtbQuery.Text.Trim().Length > 0)
            {
                UpdateAppSettings("AppSettings:LastSQL", RtbQuery.Text.Trim());
            }
        }
    }
}