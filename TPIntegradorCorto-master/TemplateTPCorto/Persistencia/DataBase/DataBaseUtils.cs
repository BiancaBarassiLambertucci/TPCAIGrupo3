using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DataBase
{
    public class DataBaseUtils
    {

        // Definimos la ruta base relativa al directorio actual de ejecución: "Tablas"

        private readonly string baseFolderPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Persistencia\DataBase\Tablas"));

        // Método para buscar registros en un archivo CSV
        public List<string> BuscarRegistro(string nombreArchivo)
        {
            // Combina la ruta base con el nombre del archivo
            string rutaArchivo = Path.Combine(baseFolderPath, nombreArchivo);
            Console.WriteLine("Ruta del archivo: " + rutaArchivo);
            List<string> listado = new List<string>();

            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine("El archivo no existe: " + rutaArchivo);
                    return listado;
                }
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        listado.Add(linea);
                    }
                }
                //Verifico que lee todas las lineas
                System.Diagnostics.Debug.WriteLine("Cantidad de líneas leídas:" + listado.Count);
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo leer el archivo:");
                Console.WriteLine(e.Message);
            }

            return listado;
        }

        public void BorrarIntentos(string nombreArchivo, string legajo, DateTime fecha)
        {
            // Construye la ruta para poder acceder al archivo que queremos.
            string rutaArchivo = Path.Combine(baseFolderPath, nombreArchivo);

            try
            {
                if (!File.Exists(rutaArchivo)) // Verifica si el archivo existe.
                {
                    Console.WriteLine("El archivo no existe " + rutaArchivo); 
                    return;
                }

                List<string> listado = BuscarRegistro(nombreArchivo); // Lee los datos usando el métod BuscarRegistro() y lo carga a nuestra lista llamada 'listado'.
                string fechaFormateada = fecha.ToString("d/M/yyyy");
                List<string> registrosRestantes = new List<string> (); // Creamos una nueva lista vacía.
                string combinacion = legajo + "|" + fechaFormateada; // Creamos un string que contiene los 2 datos que necesitamos: legajo y fecha.

                for (int i = 0; i < listado.Count; i++) // Recorremos la lista 'listado' y dividimos los datos por ;
                {
                    string linea = listado[i];
                    string[] campos = linea.Split(';');

                    if(campos.Length < 2) // Verifica que haya datos guardados.
                    {
                        registrosRestantes.Add(linea); // Agrega el dato a nuestra lista 'registrosRestantes'.
                        continue;
                    }

                    if (campos[0].Trim() == "legajo") // Guarda el encabezado.
                    {
                        registrosRestantes.Add(linea);
                        continue;
                    }

                    if (campos[0].Trim() == legajo && campos[1].Trim() == fecha.ToString("d/M/yyyy")) // Verifica el legajo y la fecha del intento.
                    {
                        campos[0] = combinacion; // Reemplaza el legajo por el string que creamos con los datos: legajo|fecha.

                        string nuevaLinea = campos[0].Trim(); // Creamos un string con los datos modificados.

                        for (int a = 1; a < campos.Length; a++) // Recorre los datos salteando el encabezado.
                        {
                            nuevaLinea = nuevaLinea + ";" + campos[a].Trim(); // Divide los datos modificados por ;
                        }
                        registrosRestantes.Add(nuevaLinea); // Agregamos la línea a nuestra lista 'registrosRestantes'.

                    }else
                    {
                        registrosRestantes.Add(linea); // Agregamos los intentos no relacionados al usuario evaluado.
                    }
                }

                File.WriteAllLines(rutaArchivo, registrosRestantes.ToArray()); // Sobreescribe el archivo existente.
                BorrarRegistro(combinacion, nombreArchivo); // Llamamos al método BorrarRegistro()
                Console.WriteLine("Se han borrado los intentos del legajo " + legajo + " de la fecha " + fecha);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar borrar los intentos");
                Console.WriteLine("Mensaje " + ex.Message);
            }

        }

        // Método para borrar un registro (filtrando por ID)
        public void BorrarRegistro(string id, string nombreArchivo)
        {
            string rutaArchivo = Path.Combine(baseFolderPath, nombreArchivo);

            try
            {
                // Verificar si el archivo existe
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine("El archivo no existe: " + rutaArchivo);
                    return;
                }

                // Leer el archivo y obtener las líneas
                List<string> listado = BuscarRegistro(nombreArchivo);

                // Filtrar las líneas que no coinciden con el ID a borrar (comparar solo la primera columna)
                var registrosRestantes = listado.Where(linea =>
                {
                    var campos = linea.Split(';');
                    return campos[0] != id;
                }).ToList();

                // Sobrescribir el archivo con las líneas restantes
                File.WriteAllLines(rutaArchivo, registrosRestantes);
                Console.WriteLine($"Registro con ID {id} borrado correctamente.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar borrar el registro:");
                Console.WriteLine($"Mensaje: {e.Message}");
                Console.WriteLine($"Pila de errores: {e.StackTrace}");
            }
        }

        // Método para agregar un registro al final del archivo
        public void AgregarRegistro(string nombreArchivo, string nuevoRegistro)
        {
            string rutaArchivo = Path.Combine(baseFolderPath, nombreArchivo);

            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine("El archivo no existe: " + rutaArchivo);
                    return;
                }
                if (string.IsNullOrWhiteSpace(nuevoRegistro) || string.IsNullOrWhiteSpace(nuevoRegistro))
                {
                    Console.WriteLine("El registro a modificar no puede estar vacío.");
                    return;
                }
                using (StreamWriter sw = new StreamWriter(rutaArchivo, append: true))
                {
                    //sw.WriteLine(Environment.NewLine);
                    sw.WriteLine(nuevoRegistro);
                }
                Console.WriteLine("Registro agregado correctamente.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar agregar el registro:");
                Console.WriteLine($"Mensaje: {e.Message}");
                Console.WriteLine($"Pila de errores: {e.StackTrace}");
            }
        }

        public void ActualizarContraseña(string nombreArchivo, string usuario, string contraseñaNueva)
        {
            // Construye la ruta para poder acceder al archivo que queremos.
            string rutaArchivo = Path.Combine(baseFolderPath, nombreArchivo);

            List<string> lineas = BuscarRegistro(nombreArchivo);

            List<string> lineasActualizadas = new List<string>();

            for (int i = 0; i < lineas.Count; i++)
            {
                string linea = lineas[i];

                if (i == 0) // Conservo el encabezado del archivo
                {
                    lineasActualizadas.Add(linea);
                    continue;
                }

                string[] campos = linea.Split(';');
                if (campos.Length < 3)
                {
                    lineasActualizadas.Add(linea);
                    continue;
                }

                if (campos[1].Trim().ToLower() == usuario.ToLower())
                {
                    campos[2] = contraseñaNueva.Trim();
                }

                string nuevaLinea = campos[0].Trim();
                for (int j = 1; j < campos.Length; j++)
                {
                    nuevaLinea += ";" + campos[j].Trim();
                }
                lineasActualizadas.Add(nuevaLinea);
            }

            try
            {
                File.WriteAllLines(rutaArchivo, lineasActualizadas.ToArray());
                //Console.WriteLine("Se actualizó la contraseña del usuario " + usuario);
            }
            catch (Exception ex) 
            {
                //Console.WriteLine("error al escribir el archivo " + ex.Message);
            }

        }

        public void VaciarFechaUltimoLogin(string nombreArchivo, string nombreUsuario)
        {
            string rutaArchivo = Path.Combine(baseFolderPath, nombreArchivo);
            List<string> lineas = BuscarRegistro(nombreArchivo);
            List<string> lineasActualizadas = new List<string>();

            foreach (string linea in lineas)
            {
                string[] partes = linea.Split(';');

                if (partes[1] == nombreUsuario)
                {
                    partes[4] = "";
                }

                lineasActualizadas.Add(string.Join(";", partes));
            }

            try
            {
                File.WriteAllLines(rutaArchivo, lineasActualizadas.ToArray());
                //Console.WriteLine("Se actualizó la ultima fecha de login para el usuario " + usuario);
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error al actualizar la ultima fecha de login del usuario " + e.Message);

            }
        }

            public void ActualizarLogin(string nombreArchivo, string usuario, DateTime fechaActual)
        {
            string rutaArchivo = Path.Combine(baseFolderPath, nombreArchivo);

            List<string> lineas = BuscarRegistro(nombreArchivo);
            List<string> lineasActualizadas = new List<string>();

            for (int i = 0; i < lineas.Count; i++)
            {
                string linea = lineas[i];

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
                
                if (campos[1].Trim() == usuario.Trim())
                {
                    campos[4] = fechaActual.ToString("d/M/yyyy");
                }

                string nuevaLinea = campos[0].Trim();
                for (int j = 1; j < campos.Length; j++)
                {
                    nuevaLinea += ";" + campos[j].Trim(); 
                }
                lineasActualizadas.Add(nuevaLinea);

                try
                {
                    File.WriteAllLines(rutaArchivo, lineasActualizadas.ToArray());
                    //Console.WriteLine("Se actualizó la ultima fecha de login para el usuario " + usuario);
                }
                catch (Exception e)
                {
                    //Console.WriteLine("Error al actualizar la ultima fecha de login del usuario " + e.Message);
                }
            }
        }

        //Método para buscar campos inviduales en los archivos CSV
        public string BuscarValorEnCSV(string archivo, int columnaBuscar, string valor, int columnaResultado)
        {
            List<string> registros = BuscarRegistro(archivo);

            foreach (string linea in registros.Skip(1)) //Salteo el encabezado
            {
                string[] campos = linea.Split(';');
                if (campos.Length > Math.Max(columnaBuscar, columnaResultado))//Me aseguro que tenga suficientes columnas el archivo
                {
                    if (campos[columnaBuscar].Trim().ToLower() == valor.Trim().ToLower()) //Busco la fila donde el valor de esta columna sea igual al que estoy buscando
                    {
                        return campos[columnaResultado].Trim();
                    }

                }
            }

            return null;
        }

        public void ActualizarPersonaPorLegajo(string nombreArchivo, string legajo, string nuevoNombre, string nuevoApellido, string nuevoDNI, DateTime nuevaFechaIngreso)
        {
            string rutaArchivo = Path.Combine(baseFolderPath, nombreArchivo);

            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("El archivo no existe.");
                return;
            }

            var lineas = File.ReadAllLines(rutaArchivo).ToList();
            var lineasActualizadas = new List<string>();

            for (int i = 0; i < lineas.Count; i++)
            {
                string linea = lineas[i];

                // Mantener la cabecera sin modificar
                if (i == 0)
                {
                    lineasActualizadas.Add(linea);
                    continue;
                }

                string[] campos = linea.Split(';');
                if (campos.Length < 5)
                {
                    // Línea mal formada, mantenerla tal cual
                    lineasActualizadas.Add(linea);
                    continue;
                }

                if (campos[0].Trim() == legajo.Trim())
                {
                    // Actualizar campos (menos el legajo)
                    campos[1] = nuevoNombre;
                    campos[2] = nuevoApellido;
                    campos[3] = nuevoDNI;
                    campos[4] = nuevaFechaIngreso.ToString("dd/MM/yyyy");
                }

                // Reconstruir la línea y agregarla
                string nuevaLinea = string.Join(";", campos.Select(c => c.Trim()));
                lineasActualizadas.Add(nuevaLinea);
            }

            try
            {
                File.WriteAllLines(rutaArchivo, lineasActualizadas);
                Console.WriteLine("Datos actualizados correctamente para legajo " + legajo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al escribir el archivo: " + ex.Message);
            }
        }
        public string GenerarIdOperacionUnico()
        {
            string[] archivos = new string[] { "operacion_cambio_persona.csv", "operacion_cambio_credencial.csv" };
            HashSet<int> ids = new HashSet<int>();

            for (int i = 0; i < archivos.Length; i++)
            {
                string archivo = archivos[i];
                List<string> lineas = BuscarRegistro(archivo);

                for (int j = 1; j < lineas.Count; j++) // Saltamos encabezado con índice
                {
                    string linea = lineas[j];
                    string[] partes = linea.Split(';');

                    int id;
                    if (partes.Length > 0 && int.TryParse(partes[0], out id))
                    {
                        ids.Add(id);
                    }
                }
            }

            int nuevoId = 1;
            while (ids.Contains(nuevoId)) nuevoId++;
            return nuevoId.ToString();
        }

        public void RegistrarOperacionCambioPersona(string idOperacion, string legajo, string nombre, string apellido, string dni, DateTime fechaIngreso)
        {
            string linea = $"{idOperacion};{legajo};{nombre};{apellido};{dni};{fechaIngreso:yyyy-MM-dd}";
            string encabezado = "idOperacion;legajo;nombre;apellido;dni;fecha_ingreso";
            string archivo = "operacion_cambio_persona.csv";

            if (!File.Exists(Path.Combine(baseFolderPath, archivo)))
                File.WriteAllText(Path.Combine(baseFolderPath, archivo), encabezado + Environment.NewLine);

            AgregarRegistro(archivo, linea);
        }

        public void RegistrarOperacionCambioCredencial(string idOperacion, string legajo, string nombreUsuario, string contrasena, string idPerfil, DateTime fechaAlta, DateTime fechaUltimoLogin)
        {
            string linea = $"{idOperacion};{legajo};{nombreUsuario};{contrasena};{idPerfil};{fechaAlta:d/M/yyyy};{fechaUltimoLogin:d/M/yyyy}";
            string encabezado = "idOperacion;legajo;nombreUsuario;contrasena;idPerfil;fechaAlta;fechaUltimoLogin"; 
            string archivo = "operacion_cambio_credencial.csv";

            if (!File.Exists(Path.Combine(baseFolderPath, archivo)))
                File.WriteAllText(Path.Combine(baseFolderPath, archivo), encabezado + Environment.NewLine);

            AgregarRegistro(archivo, linea);
        }

        public void RegistrarAutorizacion(string idOperacion, string tipoOperacion, string legajoSolicitante)
        {
            string linea = $"{idOperacion};{tipoOperacion};Pendiente;{legajoSolicitante};{DateTime.Now:d/M/yyyy};;";
            string encabezado = "idOperacion;tipoOperacion;estado;legajoSolicitante;fechaSolicitud;legajoAutorizador;fechaAutorizacion";
            string archivo = "autorizacion.csv";

            string ruta = Path.Combine(baseFolderPath, archivo);
            if (!File.Exists(ruta))
            {
                File.WriteAllText(ruta, encabezado + Environment.NewLine);
            }

            File.AppendAllText(ruta, linea + Environment.NewLine);
        }

        public void ActualizarCredencial(string usuario, string nuevaContraseña) // Método que llama a 2 métodos, reutiliza el método ActualizarContraseña() y llama al método VaciarFechaUltimoLogin() que están ambos en DataBaseUtils.
        {
            string archivo = "credenciales.csv";

            ActualizarContraseña(archivo, usuario, nuevaContraseña);
            VaciarFechaUltimoLogin(archivo, usuario);
        }


        public void ActualizarPersona(string legajo, string nombre, string apellido, string dni, string fechaIngreso)
        {
            string archivo = Path.Combine(baseFolderPath, "persona.csv");
            List<string> lineas = BuscarRegistro("persona.csv");
            List<string> nuevasLineas = new List<string>();

            if (lineas.Count > 0)
                nuevasLineas.Add(lineas[0]); // Mantener encabezado

            for (int i = 1; i < lineas.Count; i++)
            {
                string[] partes = lineas[i].Split(';');
                if (partes.Length < 5)
                    continue;

                if (partes[0].Trim() == legajo.Trim())
                {
                    // Reemplazo con los nuevos datos
                    string nuevaLinea = $"{legajo};{nombre};{apellido};{dni};{fechaIngreso}";
                    nuevasLineas.Add(nuevaLinea);
                }
                else
                {
                    nuevasLineas.Add(lineas[i]);
                }
            }

            File.WriteAllLines(archivo, nuevasLineas);
        }

    }
}
    
