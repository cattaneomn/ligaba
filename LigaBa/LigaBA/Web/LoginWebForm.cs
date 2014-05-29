using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Threading;
using LigaBA.Clases;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace LigaBA.Web
{
    public partial class LoginWebForm : Form
    {
        public LoginWebForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            if (Validaciones() == -1) return;

            if (loginPost() == "1")
            {
                PublicacionesForm.usernameWeb = this.usuarioTextBox.Text;
                PublicacionesForm.passwordWeb = this.passwordTextBox.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña inválidos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }


        private string loginPost()
        {
            string result ="";
            try
            {
                string address = Properties.Settings.Default.Url;
                string urlAddress = address + "?xx=" + this.usuarioTextBox.Text + "&yy=" + this.passwordTextBox.Text;

                using (WebClient client = new WebClient())
                {
                    // this string contains the webpage's source
                    result = client.DownloadString(urlAddress);
                }

                result = result.Replace("\r\n", string.Empty);
                //MessageBox.Show(result);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                DialogResult = DialogResult.Abort;
            }

            return result;
        }

        private int Validaciones()
        {
            if (usuarioTextBox.Text == "")
            {
                MessageBox.Show("Debe completar el campo usuario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            if (passwordTextBox.Text == "")
            {
                MessageBox.Show("Debe completar el campo contraseña.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            return 0;
        }



        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
