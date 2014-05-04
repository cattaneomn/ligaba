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
            if (Validaciones() == -1) return;

            Thread hilo = new Thread(CrearBackUp);
            hilo.SetApartmentState(System.Threading.ApartmentState.STA);
            hilo.Start();
            //TO DO esperar.REloj
        }

        private void CrearBackUp()
        {
            string Consulta = "BACKUP DATABASE [LigabaDB] TO ";
            Consulta += "DISK = N'" + this.DirTextBox.Text + "\\LigabaDB.bak' ";
            Consulta += "WITH NOFORMAT, NOINIT,  NAME = N'LigabaDB-Back Up',";
            Consulta += "SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

            List<SqlParameter> param = new List<SqlParameter>();

            BaseDeDatos.GetInstance.ExecuteCustomQuery(Consulta, param, this.Text);

            MessageBox.Show("Se ha generado el back up correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            this.DirTextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog abrir = new FolderBrowserDialog();

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                this.DirTextBox.Text = abrir.SelectedPath;
            }
        }

    }
}
