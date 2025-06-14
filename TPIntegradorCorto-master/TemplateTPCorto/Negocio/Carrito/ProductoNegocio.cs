using Datos.Ventas;
using Persistencia.CarritoPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Carrito
{
    public class ProductoNegocio
    {

        public ProductoPersistencia productoPersistencia = new ProductoPersistencia();
        public List<Producto> obtenerProductosPorCategoria(String categoria)
        {
            List<Producto> productosValidos = new List<Producto>();

            // Obtener productos desde la persistencia
            List<Producto> productos = productoPersistencia.obtenerProductosPorCategoria(categoria);

            // Filtrar manualmente los productos con stock > 0 y sin fecha de baja
            foreach (Producto p in productos)
            {
                if (p.Stock > 0 && p.FechaBaja == null)
                {
                    productosValidos.Add(p);
                }
            }

            return productosValidos;
        }
        public List<Producto> ObtenerProductos()
        {
            ProductoPersistencia persistencia = new ProductoPersistencia();
            return persistencia.ObtenerTodos();
        }

        public Producto BuscarPorId(Guid idProducto)
        {
            List<Producto> productos = ObtenerProductos(); 

            return productos.FirstOrDefault(p => p.Id == idProducto);
        }
        public Producto BuscarPorNombre(string nombre)
        {
            return ObtenerProductos().FirstOrDefault(p => p.Nombre == nombre);
        }

    }
}
