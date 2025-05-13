using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormCambioContraseña : Form
    {
        public FormCambioContraseña()
        {
            InitializeComponent();
        }

        private void CambioContraseña_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            string contraseña = textBoxNuevaContraseña.Text;
            bool permiteAvanzar = false;


            permiteAvanzar = ValidarIntegridad(contraseña);

            
        }

        private bool ValidarIntegridad(string contraseñaLogin)
        {
            if (string.IsNullOrEmpty(contraseñaLogin))
            {
                MessageBox.Show("Debe ingresar una nueva Contraseña para ingresar");
                return false;
            }
            else if (contraseñaLogin.Length < 8)
            {
                MessageBox.Show("La Contraseña debe tener al menos 8 caracteres");
                return false;
            }

            return true;

        }
    }
}
