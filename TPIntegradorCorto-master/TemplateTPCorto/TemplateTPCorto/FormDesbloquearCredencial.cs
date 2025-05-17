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
    public partial class FormDesbloquearCredencial : Form
    {
        public FormDesbloquearCredencial()
        {
            InitializeComponent();
            textBoxNuevaContraseña.UseSystemPasswordChar = true;
        }

        private void btnCContraseña_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text;
            string nuevaContraseña = textBoxNuevaContraseña.Text;

            if(string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(nuevaContraseña)) // Valido que nop pueda confirmar sin rellenar ambos campos.
            {
                MessageBox.Show("Debe completar ambos campos para poder realizar el cambio. ");
                return;
            }

            if(!ExisteUsuario(usuario))
            {
                MessageBox.Show("El usuario no existe. ");
                return;
            }

            ActualizarCredencial(usuario, nuevaContraseña);
            MessageBox.Show("Contraseña modificada con éxito. ");

            this.Close();
        }

        private void ActualizarCredencial(string usuario, string nuevaContraseña) // Método que llama a 2 métodos, reutiliza el método ActualizarContraseña() y llama al método VaciarFechaUltimoLogin() que están ambos en DataBaseUtils.
        {
            string archivo = "credenciales.csv";
            DataBaseUtils dbUtils = new DataBaseUtils();

            dbUtils.ActualizarContraseña(archivo, usuario, nuevaContraseña);
            dbUtils.VaciarFechaUltimoLogin(archivo, usuario);
        }

        private bool ExisteUsuario(string usuario) // Método para contrastar el usuario con el archivo credenciales.csv
        {
            string[] lineas = File.ReadAllLines("credenciales.csv");

            foreach (string linea in lineas)
            {
                string[] partes = linea.Split(';');

                if (partes[0] == usuario)
                {
                    return true;
                }
            }
            return false;
        }

        private void FormDesbloquearCredencial_Load(object sender, EventArgs e)
        {

        }
    }
    
}
