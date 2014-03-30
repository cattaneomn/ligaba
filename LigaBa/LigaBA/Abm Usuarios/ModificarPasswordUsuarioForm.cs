﻿using System;
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

namespace LigaBA.Abm_Usuarios
{
    public partial class ModificarPasswordUsuarioForm : Form
    {
        public ModificarPasswordUsuarioForm(string Usuario)
        {
            InitializeComponent();

            NombreUsuario = Usuario;
        }

        string NombreUsuario;

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@usuario", this.NombreUsuarioTextBox.Text));
            param.Add(new SqlParameter("@password", encriptar(this.ContraseñaTextBox.Text)));

            bool TerminoBien = BaseDeDatos.GetInstance.ejecutarProcedimiento("p_ModificarContraseñaUsuario", param, this.Text);

            if (TerminoBien == true)
            {
                MessageBox.Show("Se ha modificado la contraseña del usuario '" + NombreUsuarioTextBox.Text + "' correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            } 
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int Validaciones()
        {
            foreach (Control objeto in this.UsuariosGroupBox.Controls)
            {
                if (objeto is TextBox && ((TextBox)objeto).Text == "")
                {
                    MessageBox.Show("Debe completar los campos vacios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -1;
                }
            }

            if (ContraseñaTextBox.Text.Length < 6)
            {
                MessageBox.Show("Por razones de seguridad la contraseña debe contener como minimo seis caracteres.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;

            }

            if (ContraseñaTextBox.Text != RepContraseñaTextBox.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden. Por favor vuelva a escribirlas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1;
            }

            return 1;
        }

        //encriptacion SHA256
        static string encriptar(string pass)
        {
            SHA256 ShaM = SHA256.Create();
            byte[] data = ShaM.ComputeHash(Encoding.Default.GetBytes(pass));
            StringBuilder sbuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sbuilder.Append(data[i].ToString("x2"));
            }

            return sbuilder.ToString();
        }

        private void ModificarPasswordUsuarioForm_Load(object sender, EventArgs e)
        {
            this.NombreUsuarioTextBox.Text = NombreUsuario;
            this.ContraseñaTextBox.Select();
        }

    }
}
