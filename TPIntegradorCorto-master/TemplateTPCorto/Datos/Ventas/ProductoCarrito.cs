using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
    public class ProductoCarrito
    {
        Guid idCliente;
        Guid idProducto;
        Guid idUsuario;
        int cantidad;

        public Guid IdCliente { get => idCliente; set => idCliente = value; }
        public Guid IdProducto { get => idProducto; set => idProducto = value; }
        public Guid IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        //testeo de commit
       
    }
}
