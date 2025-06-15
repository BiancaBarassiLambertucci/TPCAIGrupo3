using Datos.Ventas;
using Newtonsoft.Json;
using Persistencia.WebService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.CarritoPersistencia
{
    public class VentaPersistencia
    {
        public Guid idUsuario = new Guid("784c07f2-2b26-4973-9235-4064e94832b5");

        public string AgregarVenta(ProductoCarrito venta)
        {
            string jsonRequest = JsonConvert.SerializeObject(venta);

            HttpResponseMessage response = WebHelper.Post("/api/Venta/AgregarVenta", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }

            return null;
        }


    }
}
