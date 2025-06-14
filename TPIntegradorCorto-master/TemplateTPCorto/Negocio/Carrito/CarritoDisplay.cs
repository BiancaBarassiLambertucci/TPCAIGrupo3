using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Carrito
{
    public class CarritoDisplay
    {
        string _nombre;
        decimal _precio;
        int _cantidad;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public decimal Precio { get => _precio; set => _precio = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
    }
}
