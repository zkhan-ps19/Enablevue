using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnableVue
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();
            
        }

        private void AboutWindow_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void AboutWindow_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        private void AboutWindow_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

        private void AboutWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
        }


    }
}
