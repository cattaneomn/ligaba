using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace LigaBA.Back_Up
{
    public partial class BackUpForm : Form
    {
        public BackUpForm()
        {
            InitializeComponent();
        }

        private void GenerarButton_Click(object sender, EventArgs e)
        {
            //if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@directorio", "hola"));


            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_BackUp", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha generado el back up correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int Validaciones()
        {

                if (this.DirTextBox.Text == "" )
                {
                    MessageBox.Show("Debe elegir un directorio para guardar el back up.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }

            return 1;
        }

        private void SeleccionarButton_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(AbrirDialog);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();
        }

        private void AbrirDialog()
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.InitialDirectory = "C:/Users/";

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                this.DirTextBox.Text = abrir.FileName;
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            this.DirTextBox.Clear();
        }

    }
}
