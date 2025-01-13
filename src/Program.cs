using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
namespace Access_SQL_Query_Tool
{
    internal static class Program
    {
        internal static IConfiguration? Config { get; private set; }

        [STAThread]
        static void Main()
        {
            CreateSettingsFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new SqlQuery(Config));
        }

        static void CreateSettingsFile(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                var appSettings = new JObject
                (
                    new JProperty
                    (
                        "AppSettings",
                        new JObject
                        (
                            new JProperty("DatabasePath", ""),
                            new JProperty("LastSQL", "")
                        )
                    )
                );

                using (FileStream stream = new(configFilePath, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new(stream, Encoding.UTF8))
                    {
                        writer.Write(appSettings.ToString());
                    }
                }
                            }
        }
    }
}