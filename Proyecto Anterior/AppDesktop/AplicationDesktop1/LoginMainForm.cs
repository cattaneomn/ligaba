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



namespace AplicationDesktop1
{
    public partial class LoginForm1 : Form
    {
        public LoginForm1()
        {
            StartImage abrir = new StartImage();
            abrir.Show();
            InitializeComponent();

            WaitSeconds(3);
            abrir.Close();
        }

        private static void WaitSeconds(double nSecs)
        {
            // Esperar los segundos indicados

            // Crear la cadena para convertir en TimeSpan
            string s = "0.00:00:" + nSecs.ToString().Replace(",", ".");
            TimeSpan ts = TimeSpan.Parse(s);

            // Añadirle la diferencia a la hora actual
            DateTime t1 = DateTime.Now.Add(ts);

            // Esta asignación solo es necesaria
            // si la comprobación se hace al principio del bucle
            DateTime t2 = DateTime.Now;

            // Mientras no haya pasado el tiempo indicado
            while (t2 < t1)
            {
                // Un respiro para el sitema
                System.Windows.Forms.Application.DoEvents();
                // Asignar la hora actual
                t2 = DateTime.Now;
            }
        }

        private void deshabilitarUsuario(string usuario)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@user_name", this.usuarioTextBox.Text));
            string query = "UPDATE ingeniar.Usuarios SET estado = 0 where username=@user_name";

            BaseDeDatos.GetInstance.ExecuteCustomQuery(query, param,this.Text);
           
        }

        private void registrarLoginInvalido(string usuario)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@user_name", this.usuarioTextBox.Text));
            string query = "UPDATE ingeniar.Usuarios SET usuario_intentos_fallidos = usuario_intentos_fallidos + 1 where username=@user_name";

            BaseDeDatos.GetInstance.ExecuteCustomQuery(query, param,this.Text);
            
        }

        private void resetIntentos(string usuario)
        {
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@user_name", this.usuarioTextBox.Text));
            string query = "UPDATE ingeniar.Usuarios SET usuario_intentos_fallidos = 0 where username=@user_name";

            BaseDeDatos.GetInstance.ExecuteCustomQuery(query, param,this.Text);

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

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            
            if (Validaciones() == -1) return;

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@user_name", this.usuarioTextBox.Text));
       
            SqlParameter respuestaParametro = new SqlParameter("@respuesta", -1);
            respuestaParametro.Direction = ParameterDirection.Output;
            param.Add(respuestaParametro);

            DataSet ds = BaseDeDatos.GetInstance.ejecutarConsulta("p_login", param,"Usuarios",this.Text);
            
            
            if (ds.Tables["Usuarios"] == null)
            {
                    
                object respuestaSP = respuestaParametro.Value;
                int respuesta = Convert.ToInt32(respuestaSP);
            
                switch (respuesta)
                {
                    case 1:
                        MessageBox.Show("Usuario o contraseña inválidos","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    case 2:
                        MessageBox.Show("El usuario con el que desea ingresar esta inhabilitado", "Usuario Inhabilitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    case 3:
                        this.deshabilitarUsuario(this.usuarioTextBox.Text);
                        MessageBox.Show("Ud. ha sido bloqueado, comuniquese con un administrador para que lo desbloquee", "Usuario bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

            }


            if (ds.Tables["Usuarios"].Rows[0]["password"].ToString() == encriptar(this.passwordTextBox.Text))
            {
                this.resetIntentos(this.usuarioTextBox.Text);
                AplicationDesktop1.Properties.Settings.Default.user = this.usuarioTextBox.Text;

                this.Hide();

                /*Form1 abrir = new Form1();
                abrir.ShowDialog();*/
                MainForm MainAbrir = new MainForm();
                MainAbrir.ShowDialog();
                
                Application.ExitThread();
                Application.Exit();
            }
            else
            {
                this.registrarLoginInvalido(this.usuarioTextBox.Text);
                MessageBox.Show("Usuario o contraseña inválidos");
                return;
            }
            
        }

        
        
        private int Validaciones()
        {
            if (usuarioTextBox.Text == "")
            {
                MessageBox.Show("Debe completar el campo usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            if (passwordTextBox.Text == "")
            {
                MessageBox.Show("Debe completar el campo contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            return 0;
        }

        private void LoginForm1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false; 
        }



    }
}
