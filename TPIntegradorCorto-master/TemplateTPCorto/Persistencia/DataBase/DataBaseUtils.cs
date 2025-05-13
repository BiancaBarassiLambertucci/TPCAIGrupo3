using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DataBase
{
    public class DataBaseUtils
    {

        // Definimos la ruta base relativa al directorio actual de ejecución: "Tablas"

        //private readonly string baseFolderPath = @"C:\Users\Administrator\OneDrive\Documentos\GitHub\CAI\TPCAIGrupo 3\TPCAIGrupo3\TPIntegradorCorto-master\TemplateTPCorto\Persistencia\DataBase\Tablas\";
        //private readonly string baseFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tablas");
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
                    Console.WriteLine("El usuario y la contraseña no pueden estar vacíos.");
                    return;
                }
                using (StreamWriter sw = new StreamWriter(rutaArchivo, append: true))
                {
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
    }
    
}