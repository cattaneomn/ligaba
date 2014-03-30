using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Text.RegularExpressions;

namespace AplicationDesktop1.Mail
{
    public partial class MailForm : Form
    {
        public MailForm()
        {
            InitializeComponent();
        }

        private string Dir;
        private string Dir2;
        private string Dir3;
        private string Dir4;

        private static bool IsValidEmail(string strMailAddress)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strMailAddress, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        private void EnviarButton_Click(object sender, EventArgs e)
        {
            if( this.ParaTextBox.Text == "")
            {
                MessageBox.Show("Ingrese un mail en el campo 'Para:'.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ParaTextBox.Focus();
                return;
            }
            string[] words = this.ParaTextBox.Text.Split(';');
            foreach (string mail in words)
            {
                if (IsValidEmail(mail) == false)
                {
                    MessageBox.Show("Ingrese un mail valido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ParaTextBox.Focus();
                    return;
                }
            }

            //HOST
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.live.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("luza_03@hotmail.com", "*31.ari90-13na23");

            //CLIENT
            MailMessage email = new MailMessage();

            foreach (string mail in words)
            {
                email.To.Add(new MailAddress(mail));
            } 
            email.From = new MailAddress("luza_03@hotmail.com");
            email.Subject = this.TextBoxAsunto.Text;
            email.Body = this.RichTextBoxMensaje.Text;

            if (Dir != null)
            {
                email.Attachments.Add(new Attachment(Dir));
            }
            if (Dir2 != null)
            {
                email.Attachments.Add(new Attachment(Dir2));
            }
            if (Dir3 != null)
            {
                email.Attachments.Add(new Attachment(Dir3));
            }
            if (Dir4 != null)
            {
                email.Attachments.Add(new Attachment(Dir4));
            }
            
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;


            //SEND
            try{
                 smtp.Send(email);
                 email.Dispose();

                 MensajeMailForm abrir = new MensajeMailForm();
                 abrir.ShowDialog();

                 foreach (Control objeto in this.GroupBoxMail.Controls)
                 {
                     if (objeto is TextBox)
                     {
                         ((TextBox)objeto).Clear();
                         ((TextBox)objeto).Enabled = true;
                     }
                     if (objeto is RichTextBox)
                     {
                         ((RichTextBox)objeto).Clear();
                     }
                 }

            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void MailForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void AdjuntarButton_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirDialog);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();

        }

        private void AbrirDialog2()
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.InitialDirectory = "C:/Users/sa/Escritorio";
            
           if (abrir.ShowDialog() == DialogResult.OK)
            {
                
               Dir2 = abrir.FileName;
               this.TextBoxAdjunto2.Text = Dir2;
               this.TextBoxAdjunto2.Enabled = false;
            }
        }

        private void AbrirDialog3()
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.InitialDirectory = "C:/Users/sa/Escritorio";

            if (abrir.ShowDialog() == DialogResult.OK)
            {

                Dir3 = abrir.FileName;
                this.TextBoxAdjunto3.Text = Dir3;
                this.TextBoxAdjunto3.Enabled = false;
            }
        }

        private void AbrirDialog4()
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.InitialDirectory = "C:/Users/sa/Escritorio";

            if (abrir.ShowDialog() == DialogResult.OK)
            {

                Dir4 = abrir.FileName;
                this.TextBoxAdjunto4.Text = Dir4;
                this.TextBoxAdjunto4.Enabled = false;
            }
        }

        private void AbrirDialog()
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.InitialDirectory = "C:/Users/sa/Escritorio";

            if (abrir.ShowDialog() == DialogResult.OK)
            {

                Dir = abrir.FileName;
                this.TextBoxAdjunto.Text = Dir;
                this.TextBoxAdjunto.Enabled = false;
            }
        }

        private void AdjuntarButton2_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirDialog2);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();
        }

        private void AdjuntarButton3_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirDialog3);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();
        }

        private void AdjuntarButton4_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirDialog4);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            this.TextBoxAdjunto.Clear();
            this.TextBoxAdjunto2.Clear();
            this.TextBoxAdjunto3.Clear();
            this.TextBoxAdjunto4.Clear();
            this.TextBoxAdjunto.Enabled = true;
            this.TextBoxAdjunto2.Enabled = true;
            this.TextBoxAdjunto3.Enabled = true;
            this.TextBoxAdjunto4.Enabled = true;
            Dir = null;
            Dir2 = null;
            Dir3 = null;
            Dir4 = null;
        }

    

    }
}

