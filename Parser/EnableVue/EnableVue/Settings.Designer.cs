namespace EnableVue
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbweburl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_UpdateLogin = new System.Windows.Forms.Button();
            this.btn_SettingsUpdate = new System.Windows.Forms.Button();
            this.lbsettRes = new System.Windows.Forms.Label();
            this.tbFolderpath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lbLogRes = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Web Url :";
            // 
            // tbweburl
            // 
            this.tbweburl.Location = new System.Drawing.Point(81, 36);
            this.tbweburl.Name = "tbweburl";
            this.tbweburl.Size = new System.Drawing.Size(426, 20);
            this.tbweburl.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folder Path :";
            // 
            // btn_UpdateLogin
            // 
            this.btn_UpdateLogin.BackColor = System.Drawing.Color.LightGray;
            this.btn_UpdateLogin.Location = new System.Drawing.Point(279, 180);
            this.btn_UpdateLogin.Name = "btn_UpdateLogin";
            this.btn_UpdateLogin.Size = new System.Drawing.Size(55, 22);
            this.btn_UpdateLogin.TabIndex = 4;
            this.btn_UpdateLogin.Text = "Update";
            this.btn_UpdateLogin.UseVisualStyleBackColor = false;
            this.btn_UpdateLogin.Click += new System.EventHandler(this.btn_UpdateLogin_Click);
            // 
            // btn_SettingsUpdate
            // 
            this.btn_SettingsUpdate.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_SettingsUpdate.Location = new System.Drawing.Point(81, 119);
            this.btn_SettingsUpdate.Name = "btn_SettingsUpdate";
            this.btn_SettingsUpdate.Size = new System.Drawing.Size(55, 22);
            this.btn_SettingsUpdate.TabIndex = 5;
            this.btn_SettingsUpdate.Text = "Update";
            this.btn_SettingsUpdate.UseVisualStyleBackColor = false;
            this.btn_SettingsUpdate.Click += new System.EventHandler(this.btn_SettingsUpdate_Click);
            // 
            // lbsettRes
            // 
            this.lbsettRes.AutoSize = true;
            this.lbsettRes.Font = new System.Drawing.Font("Perpetua", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsettRes.Location = new System.Drawing.Point(164, 124);
            this.lbsettRes.Name = "lbsettRes";
            this.lbsettRes.Size = new System.Drawing.Size(22, 16);
            this.lbsettRes.TabIndex = 6;
            this.lbsettRes.Text = "lab";
            // 
            // tbFolderpath
            // 
            this.tbFolderpath.Location = new System.Drawing.Point(81, 81);
            this.tbFolderpath.Name = "tbFolderpath";
            this.tbFolderpath.Size = new System.Drawing.Size(384, 20);
            this.tbFolderpath.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightGray;
            this.button3.Location = new System.Drawing.Point(479, 78);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "UserName :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password :";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(81, 168);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(192, 20);
            this.txtUsername.TabIndex = 10;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(81, 199);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(192, 20);
            this.txtpassword.TabIndex = 11;
            // 
            // lbLogRes
            // 
            this.lbLogRes.AutoSize = true;
            this.lbLogRes.Font = new System.Drawing.Font("Perpetua", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogRes.Location = new System.Drawing.Point(340, 186);
            this.lbLogRes.Name = "lbLogRes";
            this.lbLogRes.Size = new System.Drawing.Size(22, 16);
            this.lbLogRes.TabIndex = 12;
            this.lbLogRes.Text = "lab";
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(28, 9);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(47, 15);
            this.lbError.TabIndex = 13;
            this.lbError.Text = "Error :";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 249);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.lbLogRes);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbsettRes);
            this.Controls.Add(this.btn_SettingsUpdate);
            this.Controls.Add(this.btn_UpdateLogin);
            this.Controls.Add(this.tbFolderpath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbweburl);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ParentChanged += new System.EventHandler(this.Settings_ParentChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbweburl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_UpdateLogin;
        private System.Windows.Forms.Button btn_SettingsUpdate;
        private System.Windows.Forms.Label lbsettRes;
        private System.Windows.Forms.TextBox tbFolderpath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label lbLogRes;
        private System.Windows.Forms.Label lbError;

    }
}