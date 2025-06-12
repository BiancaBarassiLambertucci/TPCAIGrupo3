using Datos.Ventas;
using Persistencia.CarritoPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.CarritoPersistencia;

namespace Negocio.Carrito
{
    public class ProductoNegocio
    {

        public ProductoPersistencia productoPersistencia = new ProductoPersistencia();
        public List<Producto> obtenerProductosPorCategoria(String categoria)
        {
            List<Producto> listadoProductos = new List<Producto>();
            // Aplico la logica de negocio

            // 1- Mostrar solo productos que tienen stock positivo

            ProductoPersistencia PPersistencia = new ProductoPersistencia();

            listadoProductos = PPersistencia.obtenerProductosPorCategoria(categoria);

            /*for (int i = 0; i < listadoProductos.Count; i++)
            {
                // COMPLETAR
            }*/

            return listadoProductos; 
        }
    }
}
