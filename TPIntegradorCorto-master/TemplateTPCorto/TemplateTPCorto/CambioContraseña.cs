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
using System.IO;

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

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            string nuevaContraseña = textBoxNuevaContraseña.Text;

            if (!ValidarIntegridad(nuevaContraseña))
            {
                return; // Si la contraseña no pasa la validación, no continúa.
            }

            string contraseñaActual = ObtenerContraseña("credenciales.csv", usuario);

            if(nuevaContraseña == contraseñaActual) // Valida que la contraseña ingresada no puede ser igual a la anterior.
            {
                MessageBox.Show("La nueva contraseña debe ser distinta a la anterior. Ingrese una nueva.");
                textBoxNuevaContraseña.Clear();
                return;
            }
            bool actualizado = ActualizarCredencial("credenciales.csv", usuario, nuevaContraseña);

            if (actualizado)
            {
                MessageBox.Show("Contraseña actualizada con éxito. Debe volver a ingresar.");
                this.Hide();
                FormLogin loginForm = new FormLogin();
                loginForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se puedo actualizar la contraseña. Verifique que el usuario exista.");
            }

        }

        private bool ValidarIntegridad(string contraseñaLogin)
        {
            if (string.IsNullOrWhiteSpace(contraseñaLogin))
            {
                MessageBox.Show("Debe ingresar una nueva contraseña para ingresar.");
                return false;
            }
            else if (contraseñaLogin.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener 8 o más caracteres.");
                return false;
            }

            return true;

        }

        public string ObtenerContraseña(string nombreArchivo, string nombreUsuario) // Método para poder obtener la contraseña del archivo credenciales.csv
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            List<string> listado = dbUtils.BuscarRegistro(nombreArchivo);

            for (int i = 1; i < listado.Count; i++)
            {
                string linea = listado[i];
                string[] campos = linea.Split(';');

                if (campos.Length < 3)
                {
                    continue;
                }

                string usuarioArchivo = campos[1].Trim();
                string usuarioRecibido = nombreUsuario.Trim();

                if(usuarioArchivo == usuarioRecibido)
                {
                    return campos[2].Trim(); // Contraseña actual
                }
            }
            return "No se encontró el usuario. ";

        }

        public bool ActualizarCredencial(string nombreArchivo, string nombreUsuario, string nuevaContraseña)
        {
            return true;// Falta hacer el código
        }
    }
}
