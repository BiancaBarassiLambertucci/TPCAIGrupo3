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
            String usuario = txtUsuario.Text;
            String password = txtPassword.Text;

            LoginNegocio loginNegocio = new LoginNegocio();
            Credencial credencial = loginNegocio.login(usuario, password);
            if (credencial != null) //NUEVO
            {

            }
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
