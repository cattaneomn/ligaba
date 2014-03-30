using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AplicationDesktop1
{
    public partial class StartImage : Form
    {
        public StartImage()
        {
            InitializeComponent();
        }

        private void StartImage_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(5);
        }
    }
}
