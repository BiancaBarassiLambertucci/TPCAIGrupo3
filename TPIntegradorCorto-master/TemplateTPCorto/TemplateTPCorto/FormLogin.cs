using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Persistencia.DataBase;

namespace TemplateTPCorto
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)

        {

            LoginNegocio loginNegocio = new LoginNegocio();

            String usuario = txtUsuario.Text;

            String password = txtPassword.Text;

            String usuarioE;

            String passwordE;

            int intentosFallidos = 0;



            Credencial credencial = loginNegocio.login(usuario, password);

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))

            {

                MessageBox.Show("Debe ingresar usuario y contraseña para poder continuar");

                return;

            }
            else

            {

                MessageBox.Show("Llegamos hasta aca");


                List<string> registros = BuscarRegistro();

                if (registros.Count == 0)

                {

                    MessageBox.Show("La lista esta vacía");

                    return;

                }

                /*for (int i = 0; i < BuscarRegistro().Count; i++) // NO ESTA ACCEDIENDO A ESTO

                {

                    string[] datos = BuscarRegistro()[i].Split(';');

                    usuarioE = datos[1];

                    passwordE = datos[2];

                    if (usuario != usuarioE || password != passwordE)

                    {

                        MessageBox.Show("Usuario y Contraseña incorrectos, intente nuevamente");

                        intentosFallidos++;

                    } else

                    {

                        MessageBox.Show("login EXITOSO");

                        break;

                    }

                }*/

            }




            /*if (credencial == null) //NUEVO

            {

                MessageBox.Show("Dio null");

            } else

            {

                MessageBox.Show("funca");

            }*/


        }


        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
        //Revisar cómo llamar al método en Persistencia llamado BuscarRegistro()
        public List<String> BuscarRegistro()
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            List<string> registros = dbUtils.BuscarRegistro("Credenciales.csv");
            return registros;
        }
    }
}
