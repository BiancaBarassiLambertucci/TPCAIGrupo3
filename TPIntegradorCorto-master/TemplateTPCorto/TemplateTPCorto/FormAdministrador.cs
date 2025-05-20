using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistencia.DataBase;

namespace TemplateTPCorto
{
    public partial class FormAdministrador : Form
    {
        private string usuario;
        private string legajoUsuario;
        public FormAdministrador(string usuario, string legajoUsuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.legajoUsuario = legajoUsuario;
        }

        private void CargarAutorizacionesPendientes()
        {
            string archivo = "autorizacion.csv";
            DataBaseUtils dbUtils = new DataBaseUtils();
            List<string> lineas = dbUtils.BuscarRegistro(archivo);

            CambiosPendientes.Items.Clear();

            // Se asume que la primera línea es el encabezado
            for (int i = 1; i < lineas.Count; i++)
            {
                string linea = lineas[i].Trim();
                if (string.IsNullOrEmpty(linea))
                    continue;

                string[] campos = linea.Split(';');

                if (campos.Length < 7)
                    continue;

                // Si el estado es "pendiente"
                if (campos[2].Trim().Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                {
                    string displayText = string.Format("Id Operacion: {0} - Tipo Operación: {1} - Estado: {2} - Solicitante: {3} - Fecha Solicitud: {4}", campos[0].Trim(), campos[1].Trim(), campos[2].Trim(), campos[3].Trim(), campos[4].Trim());
                    CambiosPendientes.Items.Add(displayText);
                }
            }
        }


        private string ObtenerIdOperacionSeleccionada()
        {
            if (CambiosPendientes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una operación pendiente.");
                return null;
            }

            // Extraer el ID del texto del ListBox (ejemplo: "ID: 1 - Modificar Persona")
            string seleccion = CambiosPendientes.SelectedItem.ToString();
            string[] partes = seleccion.Split('-');

            if (partes.Length < 2)
            {
                MessageBox.Show("Error al obtener el ID de operación.");
                return null;
            }

            return partes[0].Replace("Id Operacion: ", "").Trim(); // Extrae solo el ID
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            CargarAutorizacionesPendientes();
        }

        private void btnAprobar_Click_1(object sender, EventArgs e)
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            string idOperacion = ObtenerIdOperacionSeleccionada();
            if (idOperacion == null) return;

            string tipoOperación = ObtenerTipoOperacion(idOperacion);
            if (idOperacion == null)
            {
                MessageBox.Show("No se encontró la operación en autorizacion.csv");
                return;
            }
            
            try
            {
                AplicarCambio(idOperacion, tipoOperación);
                dbUtils.ActualizarArchivoAutorizaciones(idOperacion, true, legajoUsuario);
                MessageBox.Show("Se aprobó el cambio seleccionado");

            } catch (Exception ex)
            {
                MessageBox.Show("No se pudo aprobar el cambio seleccionado " + ex.Message);
            }

            //MessageBox.Show("ID de operación seleccionada para aprobar: " + idOperacion + " Tipo: " + tipoOperación);
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            string idOperacion = ObtenerIdOperacionSeleccionada();
            if (idOperacion == null) return;

            string tipoOperación = ObtenerTipoOperacion(idOperacion);
            if (idOperacion == null)
            {
                MessageBox.Show("No se encontró la operacioón en autorizacion.csv");
                return;
            }

            //MessageBox.Show("ID de operación seleccionada para rechazar: " + idOperacion + " Tipo: " + tipoOperación);
            MessageBox.Show("Se rechazó el cambio seleccionado");
            dbUtils.ActualizarArchivoAutorizaciones(idOperacion, false, legajoUsuario);
        }

        private string ObtenerTipoOperacion(string idOperacion)
        {
            string archivoAutorizacion = "autorizacion.csv";
            DataBaseUtils dbUtils = new DataBaseUtils();
            List<string> lineas = dbUtils.BuscarRegistro(archivoAutorizacion);

            
            foreach (string linea in lineas.Skip(1)) // Saltamos la cabecera
            {
                string[] campos = linea.Split(';');

                if (campos.Length < 7)
                {
                    MessageBox.Show("Línea con datos insuficientes: " + linea);
                    continue;
                }

                if (campos[0].Trim().Equals(idOperacion.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    //MessageBox.Show("ID encontrado! Tipo de operación: " + campos[1].Trim());
                    return campos[1].Trim();
                }
            }

            MessageBox.Show("No se encontró el ID " + idOperacion + " en autorizacion.csv");
            return null; // No se encontró el ID en autorizaciones.csv
        }

        private void AplicarCambio(string idOperacion, string tipoOperacion)
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            string archivoOperacion = tipoOperacion.Equals("Desbloquear Credencial", StringComparison.OrdinalIgnoreCase)
                ? "operacion_cambio_credencial.csv"
                : "operacion_cambio_persona.csv";

            List<string> lineasOperacion = dbUtils.BuscarRegistro(archivoOperacion);
            List<string> datosCambio = null;

            foreach (string linea in lineasOperacion.Skip(1)) // Saltamos cabecera
            {
                string[] campos = linea.Split(';');
                if (campos.Length < 7)
                    continue;

                if (campos[0].Trim().Equals(idOperacion, StringComparison.OrdinalIgnoreCase))
                {
                    datosCambio = campos.ToList();
                    break;
                }
            }

            if (datosCambio == null)
            {
                //MessageBox.Show("No se encontró la operación en " + archivoOperacion);
                return;
            }

            string archivoDestino = tipoOperacion.Equals("Desbloquear Credencial", StringComparison.OrdinalIgnoreCase)
                ? "credenciales.csv"
                : "persona.csv";

            List<string> lineasDestino = dbUtils.BuscarRegistro(archivoDestino);
            List<string> lineasActualizadas = new List<string>();

            for (int i = 0; i < lineasDestino.Count; i++)
            {
                string linea = lineasDestino[i];
                if (i == 0)
                {
                    lineasActualizadas.Add(linea);
                    continue;
                }

                string[] campos = linea.Split(';');

                if (campos.Length < 5)
                {
                    lineasActualizadas.Add(linea);
                    continue;
                }

                if (tipoOperacion.Equals("Desbloquear Credencial", StringComparison.OrdinalIgnoreCase) && campos[1].Trim() == datosCambio[2].Trim())
                {
                    dbUtils.ActualizarCredencial(campos[1], datosCambio[3].Trim());
                    //campos[2] = datosCambio[3].Trim(); // Actualizar contraseña
                    //campos[6] = ""; // Vaciar fecha último login
                }
                else if (tipoOperacion.Equals("Modificar Persona", StringComparison.OrdinalIgnoreCase) && campos[0].Trim() == datosCambio[1].Trim())
                {
                    dbUtils.ActualizarPersona(campos[0], datosCambio[2].Trim(), datosCambio[3].Trim(), datosCambio[4].Trim(), datosCambio[5].Trim());
                    //campos[1] = datosCambio[2].Trim();
                    //campos[2] = datosCambio[3].Trim();
                    //campos[3] = datosCambio[4].Trim();
                    //campos[4] = datosCambio[5].Trim();
                }

                //string nuevaLinea = string.Join(";", campos);
                //lineasActualizadas.Add(nuevaLinea);
            }

            /*try
            {
                File.WriteAllLines(archivoDestino, lineasActualizadas);
                MessageBox.Show("Cambio aplicado correctamente en " + archivoDestino);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el archivo " + archivoDestino + ": " + ex.Message);
            }*/
        }

        

    }
}
