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
    public partial class FormModificarPersona : Form
    {
        private string legajoBuscado = null;
        private string legajoSolicitante;
        public FormModificarPersona(string legajoSolicitante)
        {
            InitializeComponent();
            this.legajoSolicitante = legajoSolicitante;
        }

        private void FormModificarPersona_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guardarCambios_Click(object sender, EventArgs e)
        {

            string legajo = textBoxLegajo.Text;
            string nombre = textBoxNombre.Text;
            string apellido = textBoxApellido.Text;
            string dni = textBoxDNI.Text;
            DateTime fechaIngreso = dateTimePickerFechaIngreso.Value;

            if (string.IsNullOrEmpty(legajo) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(dni)) // Valido que no pueda confirmar sin rellenar todos los campos.
            {
                MessageBox.Show("Debe completar todos los campos para poder realizar el cambio.");
                return;
            }

            if (!dni.All(char.IsDigit))
            {
                MessageBox.Show("El DNI solo puede contener números.");
                return;
            }

            // Validar que el legajo fue buscado previamente
            if (legajoBuscado == null || legajoBuscado != legajo)
            {
                MessageBox.Show("Debe buscar el legajo antes de guardar los cambios.");
                return;
            }

            if (!ExisteLegajo(legajo))
            {
                MessageBox.Show("El usuario no existe.");
                return;
            }

            // Registrar el cambio en operacion_cambio_persona.csv
            RegistrarOperacionCambio(legajo, nombre, apellido, dni, fechaIngreso, legajoSolicitante);

            MessageBox.Show($"Autorización de cambios para el usuario {nombre} {apellido} solicitada.");

            // Reiniciar estado
            legajoBuscado = null;
            this.Close();
        }

        private bool ExisteLegajo(string legajo) // Método para contrastar el legajo con el archivo credenciales.csv
        {
            DataBaseUtils db = new DataBaseUtils();
            List<string> lineas = db.BuscarRegistro("persona.csv");

            foreach (string linea in lineas.Skip(1))
            {
                string[] partes = linea.Split(';');
                if (partes[0].Trim() == legajo.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        private void RegistrarOperacionCambio(string legajo, string nombre, string apellido, string dni, DateTime fechaIngreso, string legajoSolicitante)
        {
            DataBaseUtils db = new DataBaseUtils();
            string idOperacion = db.GenerarIdOperacionUnico();

            db.RegistrarOperacionCambioPersona(idOperacion, legajo, nombre, apellido, dni, fechaIngreso);
            db.RegistrarAutorizacion(idOperacion, "ModificarPersona", legajoSolicitante);
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buscarLegajo_Click(object sender, EventArgs e)
        {
            string legajo = textBoxLegajo.Text.Trim();

            if (string.IsNullOrWhiteSpace(legajo))
            {
                MessageBox.Show("Por favor, ingrese un legajo.");
                return;
            }

            DataBaseUtils dbUtils = new DataBaseUtils();

            List<string> lineas = dbUtils.BuscarRegistro("persona.csv");


            foreach (string linea in lineas.Skip(1)) // saltamos cabecera
            {
                string[] partes = linea.Split(';');

                if (partes.Length < 5)
                    continue;

                if (partes[0].Trim() == legajo)
                {
                    // Cargar los datos en los controles del formulario
                    textBoxNombre.Text = partes[1];
                    textBoxApellido.Text = partes[2];
                    textBoxDNI.Text = partes[3];

                    if (DateTime.TryParse(partes[4], out DateTime fecha))
                    {
                        dateTimePickerFechaIngreso.Value = fecha;
                    }
                    else
                    {
                        MessageBox.Show("Formato de fecha inválido en el archivo.");
                    }

                    legajoBuscado = legajo; // solo guardás si se encontró

                    return; // Persona encontrada, salimos
                }
            }

            // Si no se encontró ningún registro con ese legajo
            MessageBox.Show("Legajo no encontrado.");
        }
    }
}
