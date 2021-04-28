using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraReports.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Report_Viewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PRNX files|*.prnx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ReportPrintTool printTool = new ReportPrintTool(new XtraReport());

                // Access the Print Tool's Printing System and load the report document.
                if (System.IO.File.Exists(openFileDialog.FileName))
                {
                    printTool.PrintingSystem.LoadDocument(openFileDialog.FileName);
                }
                else
                {
                    System.Console.WriteLine("The source file does not exist.");
                }

                // Load a Print Preview in a dialog window.
                // printTool.ShowPreviewDialog()
                printTool.ShowRibbonPreviewDialog();
            }
        }
    }
}
