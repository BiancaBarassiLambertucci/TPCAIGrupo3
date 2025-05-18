using Datos;
using Persistencia;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
    }
}
