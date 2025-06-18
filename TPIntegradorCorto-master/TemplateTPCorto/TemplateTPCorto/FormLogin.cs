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
using System.IO;
using Persistencia.DataBase;
using System.Globalization;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.LinkLabel;

namespace TemplateTPCorto
{
    public partial class FormLogin : Form
    {

        LoginNegocio neg = new LoginNegocio();

        public FormLogin()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string usuarioTxt = txtUsuario.Text;

            string contraseñaTxt = txtPassword.Text;

            string perfil = neg.ObtenerPerfil(usuarioTxt); 


            string resultadoValidacion = neg.ValidacionesNegocio(usuarioTxt, contraseñaTxt);

            if (resultadoValidacion != null)
            {
                MessageBox.Show(resultadoValidacion);
            }

            List<string> usuarios = neg.BuscarRegistro(); 

            bool loginCorrecto = false;
            bool usuarioEncontrado = false;

            foreach (string linea in usuarios.Skip(1)) 
            {

                string[] datos = linea.Split(';'); 

                if (datos.Length < 5) 
                {
                    continue;
                }
                string legajoCredencial = datos[0]; // Guardamos el legajo del usuario
                string usuarioCredencial = datos[1]; // Guardamos el 'usuario'
                string contraseñaCredencial = datos[2]; // Guardamos la contraseña del usuario
                DateTime fechaAltaCredencial = DateTime.ParseExact(datos[3], "d/M/yyyy", CultureInfo.InvariantCulture);


                if (usuarioTxt == usuarioCredencial) 
                {
                    usuarioEncontrado = true;

                    List<string> listaBloqueados = neg.BuscarBloqueados();

                    foreach (string legajoBloqueado in listaBloqueados)
                    {
                        if (legajoCredencial == legajoBloqueado)
                        {
                            MessageBox.Show("No puede ingresar, su usario se encuentra bloqueado.");
                            return;
                        }
                    }

                    if (contraseñaTxt == contraseñaCredencial) // Comparamos contraseña ingresada vs. credenciales.csv
                    {
                        loginCorrecto = true;

                        FormCambioContraseña formContraseña = new FormCambioContraseña(usuarioTxt); //Crea una instancia del formulario contraseña.

                        if (datos.Length < 5 || string.IsNullOrWhiteSpace(datos[4]))
                        {
                            // Primer login
                            neg.EliminarIntentosDelDia(legajoCredencial);
                            MessageBox.Show("¡Primer ingreso detectado! Debe cambiar su contraseña.");
                            this.Hide();
                            formContraseña.ShowDialog();

                        }
                        else
                        {
                            DateTime fechaUltimoLoginCredencial = DateTime.ParseExact(datos[4], "d/M/yyyy", CultureInfo.InvariantCulture);

                            TimeSpan diferenciasFechas = DateTime.Now - fechaUltimoLoginCredencial;

                            if (diferenciasFechas.Days > 30) // Verificamos si el usuario cambio la contraseña hace más de 30 dias.
                            {
                                MessageBox.Show("La contraseña ha expirado. Por favor, actualízala.");
                                this.Hide(); //Oculta el formulario actual.
                                formContraseña.ShowDialog(); // Muestra el menú contraseña de forma modal.
                            }
                            else
                            {
                                neg.EliminarIntentosDelDia(legajoCredencial);
                                MessageBox.Show("¡Acceso concedido!");
                                RedirigirPorPefil(perfil, usuarioTxt, legajoCredencial);
                            }
                            break; // Salgo del loop porque encontré al usuario.
                        }

                    }
                    else // Usuario encontrado, pero la contraseña es incorrecta.
                    {
                        neg.RegistrarIntento(legajoCredencial); // Llamo al método RegistrarIntento para agregar los datos al archivo 'login_intentos'
                        MessageBox.Show("Se guardo el legajo " + legajoCredencial + " a la lista de intentos fallidos");

                        List<string> listaIntentos = neg.ListaIntentos(); // Creo una lista en base a la lista que devuelve el método ListaIntentos()
                        int contador = 0;
                        string fechaActual = DateTime.Now.ToString("d/M/yyyy");

                        foreach (string registro in listaIntentos) // Recorro los registros guardados en el archivo 'login_intentos'
                        {
                            string[] campos = registro.Split(';'); // Separo cada uno de los registros 
                            string legajoGuardado = campos[0].Trim(); // Guardo el legajo en la lista de login_intentos 
                            string fechaGuardada = campos[1].Trim(); // Guardo la fecha del login fallido
                            if (legajoGuardado == legajoCredencial && fechaActual == fechaGuardada) // Verifico si el legajo guardado es del usuario queriendo ingresar, y si el fallo es del dia de hoy
                            {
                                contador++;
                            }
                        }

                        if (contador >= 3) // Si tiene 3 intentos fallidos en el dia de hoy.
                        {
                            neg.BloquearUsuario(legajoCredencial); // Agrego el legajo del usuario al archivo 'usuario_bloqueado' usando el método BloquearUsuario
                            MessageBox.Show("Usted superó los intentos de ingreso permitidos. Su usuario ha sido bloqueado");
                            break;

                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.");
                            break;
                        }
                    }

                }

            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        public void RedirigirPorPefil(string perfil, string usuario, string legajo)
        {
            try
            {
                if (perfil == "Supervisor")
                {
                    this.Hide();
                    FormSupervisor formSupervisor = new FormSupervisor(usuario, legajo);
                    formSupervisor.ShowDialog();
                }
                else if (perfil == "Administrador")
                {
                    this.Hide();
                    FormAdministrador formAdministrador = new FormAdministrador(usuario, legajo);
                    formAdministrador.ShowDialog();
                }
                else if (perfil == "Operador")
                {
                    this.Hide();
                    FormOperador formOperador = new FormOperador(usuario, legajo);
                    formOperador.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se pudo determinar el perfil del usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al determinar el perfil del usuario: " + ex.Message);
            }
        }

    }
}
