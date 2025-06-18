using Datos;
using Persistencia;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Negocio
{
    public class LoginNegocio
    {
        public Credencial login(String usuario, String password)
        {
            UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();

            Credencial credencial = usuarioPersistencia.login(usuario);

            if (credencial.Contrasena.Equals(password))
            {
                return credencial;
            }
            return null;
        }

        private DataBaseUtils db = new DataBaseUtils();

        public string ObtenerPerfil(string nombreUsuario)
        {
            string legajo = db.BuscarValorEnCSV("credenciales.csv", 1, nombreUsuario, 0);
            if (string.IsNullOrEmpty(legajo))
                return null; //Si no hay legajo, termino el método
            string idPerfil = db.BuscarValorEnCSV("usuario_perfil.csv", 0, legajo, 1);
            if (string.IsNullOrEmpty(idPerfil))
                return null; //Si no hay perfil, termino el método
            string nombrePerfil = db.BuscarValorEnCSV("perfil.csv", 0, idPerfil, 1);
            return nombrePerfil;
        }

        public void EliminarIntentosDelDia(string legajo) 
        {
            string nombreArchivo = "login_intentos.csv";
            DateTime fechaActual = DateTime.Now;

            try
            {
                DataBaseUtils dbUtils = new DataBaseUtils();
                dbUtils.BorrarIntentos(nombreArchivo, legajo, fechaActual);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al eliminar los intentos " + ex.Message);
            }

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

        public List<String> BuscarRegistro()
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            List<string> registros = dbUtils.BuscarRegistro("credenciales.csv");
            return registros;
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

        public string ValidacionesNegocio (string usuario, string contraseña)
        {
            string mensaje = null;

            if (string.IsNullOrWhiteSpace(usuario)) // Validamos que se haya ingresado un usuario
            {
                mensaje = "Debe ingresar el usuario para poder ingresar.";

            } else if (string.IsNullOrWhiteSpace(contraseña)) // Validamos que se haya ingresado una contraseña
            {
                mensaje = "Debe ingresar la contraseña para poder ingresar.";

            } else if (contraseña.Length < 8) //Longitud de password (mayor igual a 8) 
            {
              mensaje = "La contraseña debe tener 8 o más caracteres.";
            }

            return mensaje;
        }

       
    }
}
