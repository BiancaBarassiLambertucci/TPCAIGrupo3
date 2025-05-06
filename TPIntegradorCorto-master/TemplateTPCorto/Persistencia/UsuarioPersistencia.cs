using Datos;
using Persistencia.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class UsuarioPersistencia
    {
        public Credencial login(String username)
        {
            DataBaseUtils dataBaseUtils = new DataBaseUtils();
            Credencial credencial = null; 
            List<String> registros = dataBaseUtils.BuscarRegistro("credenciales.csv");
            foreach (String reg in registros) 
            {
                String[] datos = reg.Split(';');
                if (datos[1].Equals(username))
                {
                    credencial = new Credencial(reg);
                    break;
                }
            }
            return credencial;
        }
    }
}
