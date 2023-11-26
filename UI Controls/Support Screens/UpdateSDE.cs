using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveHelperWF.UI_Controls.Support_Screens
{
    public partial class UpdateSDE : Objects.FormBase
    {
        public UpdateSDE()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("https://www.fuzzwork.co.uk/dump/");
            processStartInfo.UseShellExecute = true;
            Process.Start(processStartInfo);
        }

        private void UpdateSDEButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog =  new OpenFileDialog();
            fileDialog.DefaultExt = "sqlite";
            fileDialog.CheckFileExists = true;
            
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string incomingFileName = fileDialog.FileName;

                int fileExtensionLenght = incomingFileName.Length - incomingFileName.LastIndexOf('.') - 1;
                if (fileExtensionLenght > 0)
                {
                    string ext = incomingFileName.Substring(incomingFileName.LastIndexOf('.') + 1, fileExtensionLenght);
                    if (ext.ToLowerInvariant().Equals("sqlite"))
                    {
                        byte[] incomingContent = File.ReadAllBytes(incomingFileName);

                        if (incomingContent != null && incomingContent.Length > 0)
                        {
                            string dbDirectory = Database.SQLiteCalls.GetSQLiteDirectory();
                            string dbFileName = Database.SQLiteCalls.GetSQLitePath();

                            FileIO.FileHelper.SaveFileContent(dbDirectory, dbFileName, incomingContent);

                            MessageBox.Show("Database Saved!", "DB Saved");
                        }
                    }
                }

            }

        }
    }
}
