using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Ventas
{
    public class AddVenta
    {
        public Guid IdCliente { get; set; }
        public Guid IdUsuario { get; set; }
        public List<ItemVenta> Productos { get; set; }
    }
}
