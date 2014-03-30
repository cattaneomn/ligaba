using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AplicationDesktop1.Mail
{
    public partial class MensajeMailForm : Form
    {
        public MensajeMailForm()
        {
            InitializeComponent();
        }

        private void MensajeMailForm_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
