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
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            LoginNegocio loginNegocio = new LoginNegocio();

            //Paso a variables lo que tenemos en el textbox
            String usuarioTxt = txtUsuario.Text;

            String contraseñaTxt = txtPassword.Text;

            //Validaciones de negocio

            if (string.IsNullOrWhiteSpace(usuarioTxt)) // Validamos que se haya ingresado un usuario
            {
                MessageBox.Show("Debe ingresar el usuario para poder ingresar.");
                return;
            }
            if (string.IsNullOrWhiteSpace(contraseñaTxt)) // Validamos que se haya ingresado una contraseña
            {
                MessageBox.Show("Debe ingresar la contraseña para poder ingresar.");
                return;
            }

            if (contraseñaTxt.Length < 8) //Longitud de password (mayor igual a 8) 
            {
                MessageBox.Show("La contraseña debe tener 8 o más caracteres.");
                return;
            }

            List<string> usuarios = BuscarRegistro(); //Llamo al método que lee el archivo csv y devuelve una lista de lineas. Cada linea representa un usuario.

            //Creo variable para saber si encontramos o no un usuario valido
            bool loginCorrecto = false; 
            bool primeraLinea = true;
            bool usuarioEncontrado = false;

            foreach (string linea in usuarios) // Recorremos la lista de todos los usuarios que nos devolvió el método BuscarRegistro();
            {
                // Validación ver cada línea que se lee
                if (primeraLinea)
                {
                    primeraLinea = false;
                    continue; // Saltar encabezado del archivo
                }
                string[] datos = linea.Split(';'); // Partimos cada linea con ; para poder separar los campos

                if (datos.Length < 5) // Evita errores si el archivo tiene alguna linea mal escrita (ej. que falte algun campo) y la saltea para leer otra linea.
                {
                    continue;
                }
                string legajoCredencial = datos[0]; // Guardamos el legajo del usuario
                string usuarioCredencial = datos[1]; // Guardamos el 'usuario'
                string contraseñaCredencial = datos[2]; // Guardamos la contraseña del usuario
                DateTime fechaAltaCredencial = DateTime.ParseExact(datos[3], "d/M/yyyy", CultureInfo.InvariantCulture); 
                DateTime fechaUltimoLoginCredencial = DateTime.ParseExact(datos[4], "d/M/yyyy", CultureInfo.InvariantCulture);

                if (usuarioTxt == usuarioCredencial) // Comparamos usuario ingresado vs. credenciales.csv
                {
                    usuarioEncontrado = true;

                    List<string> listaBloqueados = BuscarBloqueados();
                   
                    foreach (string legajoBloqueado in listaBloqueados)
                    {
                        if (legajoCredencial == legajoBloqueado)
                        {
                            MessageBox.Show("No puede ingresar, su usario se encuantra bloqueado.");
                            return;
                        }
                    }
                    
                    if (contraseñaTxt == contraseñaCredencial) // Comparamos contraseña ingresada vs. credenciales.csv
                    {
                        loginCorrecto = true;

                        TimeSpan diferenciasFechas = DateTime.Now - fechaUltimoLoginCredencial;
                        if (diferenciasFechas.Days > 30) // Verificamos si el usuario cambio la contraseña hace más de 30 dias.
                        {
                            MessageBox.Show("La contraseña ha expirado. Por favor, actualízala.");
                            this.Hide(); //Oculta el formulario actual.
                            CambioContraseña formContraseña = new CambioContraseña(); //Crea una instancia del formulario contraseña.
                            formContraseña.ShowDialog(); // Muestra el menú contraseña de forma modal.
                        }
                        else
                        {
                            EliminarIntentosDelDia(legajoCredencial);
                            MessageBox.Show("¡Acceso concedido!"); 
                        }
                        break; // Salgo del loop porque encontré al usuario.

                    }
                    else // Usuario encontrado, pero la contraseña es incorrecta.
                    {
                        RegistrarIntento(legajoCredencial); // Llamo al método RegistrarIntento para agregar los datos al archivo 'login_intentos'
                        MessageBox.Show("Se guardo el legajo " + legajoCredencial + " a la lista de intentos fallidos");

                        List<string> listaIntentos = ListaIntentos(); // Creo una lista en base a la lista que devuelve el método ListaIntentos()
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
                            BloquearUsuario(legajoCredencial); // Agrego el legajo del usuario al archivo 'usuario_bloqueado' usando el método BloquearUsuario
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

        public List<String> BuscarRegistro()
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            List<string> registros = dbUtils.BuscarRegistro("Credenciales.csv");
            return registros;
        }

        public void RegistrarIntento(string legajo)
        {
            // Guardo la fecha actual
            string fechaActual = DateTime.Now.ToString("d/M/yyyy");

            // Creo la línea que se va a agregar
            string registro = $"{legajo};{fechaActual}";

            // Uso el método AgregarRegistro (del DataBaseUtils) para sumar el registro al archivo "login_intentos.csv"
            DataBaseUtils dbUtils = new DataBaseUtils();
            dbUtils.AgregarRegistro("login_intentos.csv", registro);
        }

        public void BloquearUsuario(string legajo)
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            dbUtils.AgregarRegistro("usuario_bloqueado.csv", legajo); // Agrego el legajo al archivo 'usuario_bloqueado.csv'
        }

        public List<string> ListaIntentos()
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            List<string> intentos = dbUtils.BuscarRegistro("login_intentos.csv"); // Crea una lista en base a los datos que trae el método BuscarRegistro.
            return intentos; 
        }

        public List<string> BuscarBloqueados() // Este método busca en el archivo usuario_bloqueado.csv
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            List<string> listaBloqueados = dbUtils.BuscarRegistro("usuario_bloqueado.csv");
       
            if (File.Exists("usuario_bloqueado.csv"))
            {
                string[] lineas = File.ReadAllLines("usuario_bloqueado.csv");
                
                for (int i = 1; i < lineas.Length; i++) 
                {
                    string legajo = lineas[i].Trim(); // Salta el encabezado del archivo usuario_bloqueado.csv
                    if (!string.IsNullOrEmpty(legajo))
                    {
                        listaBloqueados.Add(legajo);
                    }
                }
            }
            return listaBloqueados;
        }
        public void EliminarIntentosDelDia(string legajo) // Método para que se borren los intentos fallidos del día.
        {
            string nombreArchivo = "login_intentos.csv";
            DateTime fechaActual = DateTime.Now;

            try
            {
                DataBaseUtils dbUtils = new DataBaseUtils();
                dbUtils.BorrarIntentos(nombreArchivo, legajo, fechaActual);
                MessageBox.Show("Se han eliminado los intentos de hoy, para el usuario " + legajo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar los intentos " + ex.Message);
            }

        } 
    }

}

