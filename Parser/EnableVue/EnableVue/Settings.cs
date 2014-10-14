using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library;

namespace EnableVue
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            tbweburl.Text = ApplicationData.serviceSettings.weburl;
            lbsettRes.Text = "";
            lbLogRes.Text = "";
            lbError.Text = "";

            if (ApplicationData.serviceToken != null)
            {
                txtpassword.Text = ApplicationData.serviceToken.password;
                txtUsername.Text = ApplicationData.serviceToken.username;
            }

            if (ApplicationData.serviceSettings.folderpath != null && ApplicationData.serviceSettings.folderpath != "")
            {
                this.folderBrowserDialog1.SelectedPath = ApplicationData.serviceSettings.folderpath;
                tbFolderpath.Text = ApplicationData.serviceSettings.folderpath;
            }
            else
                this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;

            this.BringToFront();
        }



        public void SetErrorLabel(string txt)
        {
            lbError.Text = "Error : " + txt;
            if (txt.Contains("Folder"))
            {
                tbFolderpath.Focus();
            }
            else if (txt.Contains("Username"))
            {
                txtUsername.Focus();
            }
            else if (txt.Contains("Web"))
            {
                tbweburl.Focus();
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // the code here will be executed if the user presses Open in
                // the dialog.
                tbFolderpath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_SettingsUpdate_Click(object sender, EventArgs e)
        {
            tbweburl.Text = tbweburl.Text.Trim();
            if (tbweburl.Text.Trim() == "" || tbFolderpath.Text.Trim() == "")
            {
                if (tbweburl.Text.Trim() == "") MessageBox.Show("Web URL cannot be Empty");
                if (tbFolderpath.Text.Trim() == "") MessageBox.Show("FolderPath cannot be Empty");
                return;
            }
            if (tbweburl.Text.Contains("apihome"))
            {
                string url = tbweburl.Text.Substring(0, tbweburl.Text.IndexOf("apihome"));
                if (!url.EndsWith("/"))
                {
                    url = url + "/";
                }
                tbweburl.Text = url;
            }

            DBCallsManager.UpdateWebURL(tbweburl.Text.Trim());
            DBCallsManager.UpdateFolderPath(tbFolderpath.Text.Trim());
            lbsettRes.Text = " FolderPath and WebURL have been updated";

            if (lbError.Text != "")
            {
                lbError.Text = "";
                ApplicationData.performSettingsProcess_LoadandCheck();
                //       Settings_FormClosed(null, null);
                this.Close();
            }
        }

        private void btn_UpdateLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "" || txtpassword.Text.Trim() == "")
            {
                if (txtUsername.Text.Trim() == "") MessageBox.Show("Username cannot be Empty");
                if (txtpassword.Text.Trim() == "") MessageBox.Show("Password cannot be Empty");
                return;
            }
            DBCallsManager.UpdateUsernamePassword(txtUsername.Text.Trim(), txtpassword.Text.Trim());

            if (lbError.Text != "")
            {
                lbError.Text = "";
                ApplicationData.performTokenProcess_LoadandCheck();
                //    Settings_FormClosed(null, null);
                this.Close();
            }
        }

        private void Settings_ParentChanged(object sender, EventArgs e)
        {
            this.BringToFront();
        }



    }
}
