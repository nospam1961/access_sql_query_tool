using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
namespace Access_SQL_Query_Tool
{
    internal static class Program
    {
        internal static IConfiguration? Config { get; private set; }

        [STAThread]
        static void Main()
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new SqlQuery(Config));
        }
    }
}