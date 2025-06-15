using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Carrito
{
    public class CarritoDisplay
    {
        Guid _idProducto;
        string _nombre;
        decimal _precio;
        int _cantidad;

        public Guid IdProducto { get => _idProducto; set => _idProducto = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public decimal Precio { get => _precio; set => _precio = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }

    }
}
