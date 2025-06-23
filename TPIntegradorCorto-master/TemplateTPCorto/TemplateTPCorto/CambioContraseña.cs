using Negocio;
using Persistencia.DataBase;
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
        private string usuario;
        public FormCambioContraseña(string nombreUsuario)
        {
            InitializeComponent();
            usuario = nombreUsuario;
            textBoxNuevaContraseña.UseSystemPasswordChar = true;
        }

        private void CambioContraseña_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private LoginNegocio neg = new LoginNegocio();

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            string nuevaContraseña = textBoxNuevaContraseña.Text;

            string mensajeValidacion = neg.ValidarNuevaContraseña(usuario, nuevaContraseña);
            if (mensajeValidacion != null)
            {
                MessageBox.Show(mensajeValidacion);
                textBoxNuevaContraseña.Clear();
                return;
            }

            neg.ActualizarCredencial(usuario, nuevaContraseña);
            neg.ActualizarUltimoLogin(usuario);

            MessageBox.Show("Contraseña actualizada con éxito. Ingrese nuevamente.");
            this.Hide();
            new FormLogin().ShowDialog();
            
        }
        
        private void textBoxNuevaContraseña_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
