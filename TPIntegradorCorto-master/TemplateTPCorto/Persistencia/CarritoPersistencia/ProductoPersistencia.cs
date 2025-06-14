using Datos.Ventas;
using Newtonsoft.Json;
using Persistencia.WebService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using MongoDB.Bson.IO;

namespace Persistencia.CarritoPersistencia
{
    public class ProductoPersistencia
    {
        public List<Producto> obtenerProductosPorCategoria(String categoria)
        {
            List<Producto> listadoProductos = new List<Producto>();

            // Llamo al WS
            HttpResponseMessage response = WebHelper.Get("/api/Producto/TraerProductosPorCategoria?catnum=" + categoria);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var contentStream = response.Content.ReadAsStringAsync().Result;
                listadoProductos = JsonConvert.DeserializeObject<List<Producto>>(contentStream);
            }

            return listadoProductos;
        }

        public List<Producto> ObtenerTodos()
        {
            List<Producto> productos = new List<Producto>();
            HttpResponseMessage response = WebHelper.Get("/api/Producto/TraerProductos");

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var contentStream = response.Content.ReadAsStringAsync().Result;
                productos = JsonConvert.DeserializeObject<List<Producto>>(contentStream);
            }

            return productos;
        }
    }
}
