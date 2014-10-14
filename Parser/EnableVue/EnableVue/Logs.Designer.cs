namespace EnableVue
{
    partial class Logs
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
            this.components = new System.ComponentModel.Container();
            this.tabLOGS = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgrdDetailedLog = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgrdSimpleLog = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabLOGS.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdDetailedLog)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdSimpleLog)).BeginInit();
            this.SuspendLayout();
            // 
            // tabLOGS
            // 
            this.tabLOGS.Controls.Add(this.tabPage1);
            this.tabLOGS.Controls.Add(this.tabPage2);
            this.tabLOGS.Location = new System.Drawing.Point(3, 3);
            this.tabLOGS.Name = "tabLOGS";
            this.tabLOGS.SelectedIndex = 0;
            this.tabLOGS.Size = new System.Drawing.Size(379, 339);
            this.tabLOGS.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dtgrdDetailedLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(371, 313);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detailed LOG";
            // 
            // dtgrdDetailedLog
            // 
            this.dtgrdDetailedLog.AllowUserToAddRows = false;
            this.dtgrdDetailedLog.AllowUserToDeleteRows = false;
            this.dtgrdDetailedLog.AllowUserToOrderColumns = true;
            this.dtgrdDetailedLog.AllowUserToResizeRows = false;
            this.dtgrdDetailedLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrdDetailedLog.BackgroundColor = System.Drawing.Color.White;
            this.dtgrdDetailedLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdDetailedLog.Location = new System.Drawing.Point(2, 2);
            this.dtgrdDetailedLog.Name = "dtgrdDetailedLog";
            this.dtgrdDetailedLog.Size = new System.Drawing.Size(369, 308);
            this.dtgrdDetailedLog.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.dtgrdSimpleLog);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(371, 313);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Simple LOG";
            // 
            // dtgrdSimpleLog
            // 
            this.dtgrdSimpleLog.AllowUserToAddRows = false;
            this.dtgrdSimpleLog.AllowUserToDeleteRows = false;
            this.dtgrdSimpleLog.AllowUserToOrderColumns = true;
            this.dtgrdSimpleLog.AllowUserToResizeRows = false;
            this.dtgrdSimpleLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrdSimpleLog.BackgroundColor = System.Drawing.Color.White;
            this.dtgrdSimpleLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdSimpleLog.Location = new System.Drawing.Point(0, 0);
            this.dtgrdSimpleLog.Name = "dtgrdSimpleLog";
            this.dtgrdSimpleLog.ReadOnly = true;
            this.dtgrdSimpleLog.Size = new System.Drawing.Size(371, 313);
            this.dtgrdSimpleLog.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 345);
            this.Controls.Add(this.tabLOGS);
            this.Name = "Logs";
            this.Text = "Logs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Logs_FormClosed);
            this.Load += new System.EventHandler(this.Logs_Load);
            this.tabLOGS.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdDetailedLog)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdSimpleLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabLOGS;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dtgrdSimpleLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dtgrdDetailedLog;

    }
}