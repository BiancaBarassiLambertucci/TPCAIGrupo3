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
using System.Globalization;

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
         
            DataBaseUtils dbUtils = new DataBaseUtils();
            string legajo = dbUtils.BuscarValorEnCSV("credenciales.csv", 1, usuario, 0);
            string fechaAltaStr = dbUtils.BuscarValorEnCSV("credenciales.csv", 1, usuario, 3);
            string legajoUsuario;
       
            DateTime fechaAlta = DateTime.ParseExact(fechaAltaStr, "d/M/yyyy", CultureInfo.InvariantCulture);
     
            DateTime fechaUltimoLogin = !string.IsNullOrWhiteSpace(dbUtils.BuscarValorEnCSV("credenciales.csv", 1, usuario, 4))
            ? DateTime.ParseExact(dbUtils.BuscarValorEnCSV("credenciales.csv", 1, usuario, 4), "d/M/yyyy", CultureInfo.InvariantCulture)
            : new DateTime(1900, 1, 1);
            string idPerfil = dbUtils.BuscarValorEnCSV("usuario_perfil.csv", 0, legajo, 1);
            RegistrarOperacionCambio(legajo, usuario, nuevaContraseña, idPerfil, fechaAlta, fechaUltimoLogin);             
            MessageBox.Show($"Autorización de cambios para el usuario {usuario} solicitada."); ;

            this.Close();
        }

        private void RegistrarOperacionCambio(string legajo, string usuario, string nuevaContraseña, string idPerfil, DateTime fechaAlta, DateTime fechaUltimoLogin)
        {
            DataBaseUtils db = new DataBaseUtils();
            string idOperacion = db.GenerarIdOperacionUnico();

            db.RegistrarOperacionCambioCredencial(idOperacion, legajo, usuario, nuevaContraseña, idPerfil, fechaAlta, fechaUltimoLogin);

            db.RegistrarAutorizacion(idOperacion, "Desbloquear credencial", legajo); 
        }

        private bool ExisteUsuario(string usuario) // Método para contrastar el usuario con el archivo credenciales.csv
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            List<string> usuarios = dbUtils.BuscarRegistro("credenciales.csv"); //Llamo al método que lee el archivo csv y devuelve una lista de lineas. Cada linea representa un usuario.

            foreach (string linea in usuarios.Skip(1)) // Recorremos la lista de todos los usuarios que nos devolvió el método BuscarRegistro() y salteamos el encabezado del archivo
            {

                string[] datos = linea.Split(';'); // Partimos cada linea con ; para poder separar los campos

                if (datos.Length < 5) // Evita errores si el archivo tiene alguna linea mal escrita (ej. que falte algun campo) y la saltea para leer otra linea.
                {
                    continue;
                }

                string usuarioCredencial = datos[1]; // Guardamos el 'usuario'

                if (usuario == usuarioCredencial) // Comparamos usuario ingresado vs. credenciales.csv
                {
                    return true;
                }
            }
            return false;
        }

        private void FormDesbloquearCredencial_Load(object sender, EventArgs e)
        {

        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
