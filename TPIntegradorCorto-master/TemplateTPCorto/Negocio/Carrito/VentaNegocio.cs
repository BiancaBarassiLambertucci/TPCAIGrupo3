using Datos;
using Datos.Ventas;
using Persistencia;
using Persistencia.CarritoPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Carrito
{
    public class VentaNegocio
    {
        public List<Cliente> obtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            ClientePersistencia clientePersistencia = new ClientePersistencia();

            clientes = clientePersistencia.obtenerClientes();

            return clientes;
        }

        public List<CategoriaProductos> obtenerCategoriaProductos()
        {
            List<CategoriaProductos> categoriaProductos = new List<CategoriaProductos>();

            CategoriaProductos p1 = new CategoriaProductos("1", "Audio");
            categoriaProductos.Add(p1);

            CategoriaProductos p2 = new CategoriaProductos("2", "Celulares");
            categoriaProductos.Add(p2);

            CategoriaProductos p3 = new CategoriaProductos("3", "Electro Hogar");
            categoriaProductos.Add(p3);

            CategoriaProductos p4 = new CategoriaProductos("4", "Informática");
            categoriaProductos.Add(p4);

            CategoriaProductos p5 = new CategoriaProductos("5", "Smart TV");
            categoriaProductos.Add(p5);

            return categoriaProductos;
        }

        public List<ProductoCarrito> productosCarrito = new List<ProductoCarrito>();

        public void AgregarProductoCarrito(Producto producto, int cantidad)
        {
            if (producto == null)
                throw new Exception("Debe seleccionar un producto.");
            if (cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor a cero.");

            // Buscar si el producto ya está en el carrito
            foreach (var item in productosCarrito)
            {
                if (item.IdProducto == producto.Id)
                {
                    int nuevaCantidadTotal = item.Cantidad + cantidad;

                    if (nuevaCantidadTotal > producto.Stock)
                        throw new Exception("No hay suficiente stock disponible para esta cantidad.");

                    item.Cantidad = nuevaCantidadTotal;
                    return; // Ya se actualizó, no se agrega uno nuevo
                }
            }

            // Si no estaba en el carrito, verifico el stock y lo agrego
            if (cantidad > producto.Stock)
                throw new Exception("No hay suficiente stock disponible.");

            ProductoCarrito nuevoItem = new ProductoCarrito
            {
                IdProducto = producto.Id,
                Cantidad = cantidad
            };

            productosCarrito.Add(nuevoItem);
        }


        public void LimpiarCarrito()
        {
            productosCarrito.Clear();
        }

        public List<ProductoCarrito> ObtenerCarrito()
        {
            return productosCarrito;
        }

        public void QuitarProducto(Guid idProducto)
        {
            for (int i = 0; i < productosCarrito.Count; i++)
            {
                if (productosCarrito[i].IdProducto == idProducto)
                {
                    productosCarrito.RemoveAt(i);
                    return;
                }
            }
        }

        public decimal ObtenerSubtotal(List<ProductoCarrito> carrito, List<Producto> productosDisponibles)
        {
            decimal subtotal = 0;

            foreach (var item in carrito)
            {
                Producto producto = productosDisponibles.Find(p => p.Id == item.IdProducto);
                if (producto != null)
                {
                    subtotal += producto.Precio * item.Cantidad;
                }
            }

            return subtotal;
        }

        public decimal ObtenerTotalConDescuento(List<ProductoCarrito> carrito, List<Producto> productosDisponibles)
        {
            decimal total = 0;
            decimal totalElectroHogar = 0;

            foreach (var item in carrito)
            {
                Producto producto = productosDisponibles.Find(p => p.Id == item.IdProducto);
                if (producto != null)
                {
                    decimal monto = producto.Precio * item.Cantidad;

                    if (producto.IdCategoria == 3) // Electro Hogar
                    {
                        totalElectroHogar += monto;
                    }

                    total += monto;
                }
            }

            if (totalElectroHogar > 1000000)
            {
                total -= totalElectroHogar * 0.15m; // Aplicar 15% de descuento solo a Electro Hogar
            }

            return total;
        }


    }

}

