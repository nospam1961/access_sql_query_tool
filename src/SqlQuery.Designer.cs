using System.Windows.Forms;

namespace Access_SQL_Query_Tool
{
    partial class SqlQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlQuery));
            SplToolbarAndOther = new SplitContainer();
            CmdExecuteNonQuery = new Button();
            LblDatabaseFilename = new Label();
            CmdExecute = new Button();
            SplContainerQueryAndResult = new SplitContainer();
            RtbQuery = new RichTextBox();
            TabOutputAndMessage = new TabControl();
            TabQueryOutput = new TabPage();
            GrdOutput = new DataGridView();
            TabMessageOutput = new TabPage();
            RtbMessageOutput = new RichTextBox();
            LblVersion = new Label();
            ((System.ComponentModel.ISupportInitialize)SplToolbarAndOther).BeginInit();
            SplToolbarAndOther.Panel1.SuspendLayout();
            SplToolbarAndOther.Panel2.SuspendLayout();
            SplToolbarAndOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplContainerQueryAndResult).BeginInit();
            SplContainerQueryAndResult.Panel1.SuspendLayout();
            SplContainerQueryAndResult.Panel2.SuspendLayout();
            SplContainerQueryAndResult.SuspendLayout();
            TabOutputAndMessage.SuspendLayout();
            TabQueryOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GrdOutput).BeginInit();
            TabMessageOutput.SuspendLayout();
            SuspendLayout();
            // 
            // SplToolbarAndOther
            // 
            SplToolbarAndOther.Dock = DockStyle.Fill;
            SplToolbarAndOther.Location = new System.Drawing.Point(0, 0);
            SplToolbarAndOther.Name = "SplToolbarAndOther";
            SplToolbarAndOther.Orientation = Orientation.Horizontal;
            // 
            // SplToolbarAndOther.Panel1
            // 
            SplToolbarAndOther.Panel1.Controls.Add(LblVersion);
            SplToolbarAndOther.Panel1.Controls.Add(CmdExecuteNonQuery);
            SplToolbarAndOther.Panel1.Controls.Add(LblDatabaseFilename);
            SplToolbarAndOther.Panel1.Controls.Add(CmdExecute);
            // 
            // SplToolbarAndOther.Panel2
            // 
            SplToolbarAndOther.Panel2.Controls.Add(SplContainerQueryAndResult);
            SplToolbarAndOther.Size = new System.Drawing.Size(1008, 729);
            SplToolbarAndOther.SplitterDistance = 59;
            SplToolbarAndOther.TabIndex = 0;
            // 
            // CmdExecuteNonQuery
            // 
            CmdExecuteNonQuery.Location = new System.Drawing.Point(214, 10);
            CmdExecuteNonQuery.Name = "CmdExecuteNonQuery";
            CmdExecuteNonQuery.Size = new System.Drawing.Size(144, 23);
            CmdExecuteNonQuery.TabIndex = 2;
            CmdExecuteNonQuery.Text = "Execute Non Query";
            CmdExecuteNonQuery.UseVisualStyleBackColor = true;
            CmdExecuteNonQuery.Click += CmdExecuteNonQuery_Click;
            // 
            // LblDatabaseFilename
            // 
            LblDatabaseFilename.AutoSize = true;
            LblDatabaseFilename.Location = new System.Drawing.Point(364, 14);
            LblDatabaseFilename.Name = "LblDatabaseFilename";
            LblDatabaseFilename.Size = new System.Drawing.Size(218, 15);
            LblDatabaseFilename.TabIndex = 1;
            LblDatabaseFilename.Text = "Click to select a MS Access Database file";
            LblDatabaseFilename.Click += LblDatabaseFilename_Click;
            // 
            // CmdExecute
            // 
            CmdExecute.Location = new System.Drawing.Point(133, 10);
            CmdExecute.Name = "CmdExecute";
            CmdExecute.Size = new System.Drawing.Size(75, 23);
            CmdExecute.TabIndex = 0;
            CmdExecute.Text = "E&xecute";
            CmdExecute.UseVisualStyleBackColor = true;
            CmdExecute.Click += CmdExecute_Click;
            // 
            // SplContainerQueryAndResult
            // 
            SplContainerQueryAndResult.Dock = DockStyle.Fill;
            SplContainerQueryAndResult.Location = new System.Drawing.Point(0, 0);
            SplContainerQueryAndResult.Name = "SplContainerQueryAndResult";
            SplContainerQueryAndResult.Orientation = Orientation.Horizontal;
            // 
            // SplContainerQueryAndResult.Panel1
            // 
            SplContainerQueryAndResult.Panel1.Controls.Add(RtbQuery);
            // 
            // SplContainerQueryAndResult.Panel2
            // 
            SplContainerQueryAndResult.Panel2.Controls.Add(TabOutputAndMessage);
            SplContainerQueryAndResult.Size = new System.Drawing.Size(1008, 666);
            SplContainerQueryAndResult.SplitterDistance = 294;
            SplContainerQueryAndResult.TabIndex = 0;
            // 
            // RtbQuery
            // 
            RtbQuery.AcceptsTab = true;
            RtbQuery.Dock = DockStyle.Fill;
            RtbQuery.Font = new System.Drawing.Font("JetBrains Mono", 14.25F);
            RtbQuery.Location = new System.Drawing.Point(0, 0);
            RtbQuery.Name = "RtbQuery";
            RtbQuery.Size = new System.Drawing.Size(1008, 294);
            RtbQuery.TabIndex = 0;
            RtbQuery.Text = "SELECT \n  ID\n, President_Name\n, Years_In_Office\n, President_Number\n, Party\nFROM tbl_Presidents_US\nWHERE President_Number = '1st'\n;\n";
            RtbQuery.TextChanged += RtbQuery_TextChanged;
            RtbQuery.KeyDown += RtbQuery_KeyDown;
            // 
            // TabOutputAndMessage
            // 
            TabOutputAndMessage.Controls.Add(TabQueryOutput);
            TabOutputAndMessage.Controls.Add(TabMessageOutput);
            TabOutputAndMessage.Dock = DockStyle.Fill;
            TabOutputAndMessage.Location = new System.Drawing.Point(0, 0);
            TabOutputAndMessage.Name = "TabOutputAndMessage";
            TabOutputAndMessage.SelectedIndex = 0;
            TabOutputAndMessage.Size = new System.Drawing.Size(1008, 368);
            TabOutputAndMessage.TabIndex = 1;
            // 
            // TabQueryOutput
            // 
            TabQueryOutput.Controls.Add(GrdOutput);
            TabQueryOutput.Location = new System.Drawing.Point(4, 24);
            TabQueryOutput.Name = "TabQueryOutput";
            TabQueryOutput.Padding = new Padding(3);
            TabQueryOutput.Size = new System.Drawing.Size(1000, 340);
            TabQueryOutput.TabIndex = 0;
            TabQueryOutput.Text = "Output";
            TabQueryOutput.UseVisualStyleBackColor = true;
            // 
            // GrdOutput
            // 
            GrdOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GrdOutput.Dock = DockStyle.Fill;
            GrdOutput.Location = new System.Drawing.Point(3, 3);
            GrdOutput.Name = "GrdOutput";
            GrdOutput.Size = new System.Drawing.Size(994, 334);
            GrdOutput.TabIndex = 1;
            // 
            // TabMessageOutput
            // 
            TabMessageOutput.Controls.Add(RtbMessageOutput);
            TabMessageOutput.Location = new System.Drawing.Point(4, 24);
            TabMessageOutput.Name = "TabMessageOutput";
            TabMessageOutput.Padding = new Padding(3);
            TabMessageOutput.Size = new System.Drawing.Size(1000, 340);
            TabMessageOutput.TabIndex = 1;
            TabMessageOutput.Text = "Message";
            TabMessageOutput.UseVisualStyleBackColor = true;
            // 
            // RtbMessageOutput
            // 
            RtbMessageOutput.Dock = DockStyle.Fill;
            RtbMessageOutput.Location = new System.Drawing.Point(3, 3);
            RtbMessageOutput.Name = "RtbMessageOutput";
            RtbMessageOutput.Size = new System.Drawing.Size(994, 334);
            RtbMessageOutput.TabIndex = 0;
            RtbMessageOutput.Text = "";
            // 
            // LblVersion
            // 
            LblVersion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LblVersion.Location = new System.Drawing.Point(778, 14);
            LblVersion.Name = "LblVersion";
            LblVersion.Size = new System.Drawing.Size(218, 15);
            LblVersion.TabIndex = 3;
            LblVersion.Text = "Version";
            LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SqlQuery
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1008, 729);
            Controls.Add(SplToolbarAndOther);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "SqlQuery";
            Text = "Access SQL Query Tool";
            FormClosing += SqlQuery_FormClosing;
            Load += SqlQuery_Load;
            SplToolbarAndOther.Panel1.ResumeLayout(false);
            SplToolbarAndOther.Panel1.PerformLayout();
            SplToolbarAndOther.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplToolbarAndOther).EndInit();
            SplToolbarAndOther.ResumeLayout(false);
            SplContainerQueryAndResult.Panel1.ResumeLayout(false);
            SplContainerQueryAndResult.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplContainerQueryAndResult).EndInit();
            SplContainerQueryAndResult.ResumeLayout(false);
            TabOutputAndMessage.ResumeLayout(false);
            TabQueryOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GrdOutput).EndInit();
            TabMessageOutput.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer SplToolbarAndOther;
        private SplitContainer SplContainerQueryAndResult;
        private Button CmdExecute;
        private RichTextBox RtbQuery;
        private TabControl TabOutputAndMessage;
        private TabPage TabQueryOutput;
        private DataGridView GrdOutput;
        private TabPage TabMessageOutput;
        private RichTextBox RtbMessageOutput;
        private Label LblDatabaseFilename;
        private Button CmdExecuteNonQuery;
        private Label LblVersion;
    }
}