using Datos;
using Datos.Ventas;
using Negocio;
using Negocio.Carrito;
using Newtonsoft.Json;
using Persistencia.CarritoPersistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateTPCorto
{
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        public BindingList<CarritoDisplay> productosCarritoDinamico = new BindingList<CarritoDisplay>();
        private Guid clienteSeleccionadoAnterior = Guid.Empty;
        public bool ignorarCambioCliente = false;

        private void FormVentas_Load_1(object sender, EventArgs e)
        {
            CargarClientes();
            CargarCategoriasProductos();
            IniciarTotales();
            dgvCarrito.DataSource = productosCarritoDinamico;
            // Ocultar columna IdProducto
            if (dgvCarrito.Columns["IdProducto"] != null)
            {
                dgvCarrito.Columns["IdProducto"].Visible = false;
            }
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.ReadOnly = true;

        }

        private void IniciarTotales()
        {
            lablSubTotal.Text = "0.00";
            lblTotal.Text = "0.00";
        }

        public VentaNegocio ventasNegocio = new VentaNegocio();

        private void CargarCategoriasProductos()
        {      
            List<CategoriaProductos> categoriaProductos = ventasNegocio.obtenerCategoriaProductos();

            foreach (CategoriaProductos categoriaProducto in categoriaProductos)
            {
                cboCategoriaProductos.Items.Add(categoriaProducto);
            }
        }

        private void CargarClientes()
        {
            List<Cliente> listadoClientes = ventasNegocio.obtenerClientes();

            foreach (Cliente cliente in listadoClientes)
            {
                cmbClientes.Items.Add(cliente);
            }
        }

        public void CargarProductosValidos()
        {
            if (cmbClientes.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }

            if (cboCategoriaProductos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una categoría.");
                return;
            }

            CategoriaProductos categoriaSeleccionada = (CategoriaProductos)cboCategoriaProductos.SelectedItem;
            string categoriaID = categoriaSeleccionada.Id.ToString();

            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> productosValidos = productoNegocio.obtenerProductosPorCategoria(categoriaID);

            lstProducto.DataSource = null;
            lstProducto.DataSource = productosValidos;
            lstProducto.DisplayMember = "Nombre"; 
            
        }

        private void btnListarProductos_Click(object sender, EventArgs e)
        {
           //Este no se usa
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Este no se usa
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ignorarCambioCliente)
                return;
            List<ProductoCarrito> carritoActual = ventasNegocio.ObtenerCarrito();

            if (carritoActual.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Hay productos cargados en el carrito. ¿Desea cambiar el cliente?",
                    "Confirmar cambio de cliente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (respuesta == DialogResult.Yes)
                {
                    ventasNegocio.LimpiarCarrito();
                    productosCarritoDinamico.Clear();
                    IniciarTotales();
                }
                else
                {
                    ignorarCambioCliente = true;
                    for (int i = 0; i < cmbClientes.Items.Count; i++)
                    {
                        Cliente clienteItem = (Cliente)cmbClientes.Items[i];
                        if (clienteItem.Id == clienteSeleccionadoAnterior)
                        {
                            cmbClientes.SelectedIndex = i;
                            break;
                        }
                    }

                    ignorarCambioCliente = false;
                    return;
                }
            }

            // Si no había productos o el usuario aceptó limpiar, guardamos el nuevo cliente
            if (cmbClientes.SelectedItem != null)
            {
                Cliente clienteNuevo = (Cliente)cmbClientes.SelectedItem;
                clienteSeleccionadoAnterior = clienteNuevo.Id;
            }
        }

        
        private void btnListarProductos_Click_1(object sender, EventArgs e)
        {
            CargarProductosValidos();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto en el carrito.");
                return;
            }

            CarritoDisplay seleccionado = (CarritoDisplay)dgvCarrito.SelectedRows[0].DataBoundItem;

            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = productoNegocio.BuscarPorNombre(seleccionado.Nombre);

            if (producto == null)
            {
                MessageBox.Show("No se pudo identificar el producto para quitar.");
                return;
            }

            ventasNegocio.QuitarProducto(producto.Id);
            Producto productoSeleccionado = (Producto)lstProducto.SelectedItem;

            productosCarritoDinamico.Clear();
            foreach (var item in ventasNegocio.ObtenerCarrito())
            {
                var prod = productoNegocio.BuscarPorId(item.IdProducto);
                productosCarritoDinamico.Add(new CarritoDisplay
                {
                    IdProducto = prod.Id,
                    Nombre = prod?.Nombre ?? "Desconocido",
                    Precio = prod?.Precio ?? 0,
                    Cantidad = item.Cantidad
                });
                ProductoCarrito prodCarrito = new ProductoCarrito();
            }

            ActualizarTotales();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            
            if (lstProducto.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Debe ingresar una cantidad.");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("La cantidad debe ser un número entero.");
                return;
            }

            Producto productoSeleccionado = (Producto)lstProducto.SelectedItem;

            try
            {
                ventasNegocio.AgregarProductoCarrito(productoSeleccionado, cantidad);

                productosCarritoDinamico.Clear();
                ProductoNegocio productoNegocio = new ProductoNegocio();

                foreach (var item in ventasNegocio.ObtenerCarrito())
                {
                    var producto = productoNegocio.BuscarPorId(item.IdProducto);
                    productosCarritoDinamico.Add(new CarritoDisplay
                    {
                        IdProducto = item.IdProducto,
                        Nombre = producto?.Nombre ?? "Desconocido",
                        Precio = producto?.Precio ?? 0,
                        Cantidad = item.Cantidad
                    });
                }

                // Actualizar totales
                ActualizarTotales();

                // Limpiar campo cantidad
                txtCantidad.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ActualizarTotales()
        {
            List<ProductoCarrito> carrito = ventasNegocio.ObtenerCarrito();

            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> productosDisponibles = productoNegocio.ObtenerProductos();

            decimal subtotal = ventasNegocio.ObtenerSubtotal(carrito, productosDisponibles);
            decimal total = ventasNegocio.ObtenerTotalConDescuento(carrito, productosDisponibles);

            lablSubTotal.Text = subtotal.ToString("C");
            lblTotal.Text = total.ToString("C");
        }
        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        public List<ProductoCarrito> GenerarVentaParaWS()
        {

            List<ProductoCarrito> productosParaWS = new List<ProductoCarrito>();
            List<ProductoCarrito> carrito = ventasNegocio.ObtenerCarrito();

            if (cmbClientes.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return productosParaWS;
            }

            Cliente clienteSeleccionado = (Cliente)cmbClientes.SelectedItem;

            for (int i = 0; i < carrito.Count; i++)
            {
                ProductoCarrito item = new ProductoCarrito();
                item.IdProducto = carrito[i].IdProducto;
                item.Cantidad = carrito[i].Cantidad;
                item.IdCliente = clienteSeleccionado.Id; 
                productosParaWS.Add(item);
            }

            return productosParaWS;
        }

        public void btnCargar_Click(object sender, EventArgs e)
        {
            List<ProductoCarrito> productos = GenerarProductosParaWS(); 

            if (productos.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente y al menos un producto.");
                return;
            }
            VentaPersistencia persistencia = new VentaPersistencia();

            Cliente cliente = (Cliente)cmbClientes.SelectedItem;
            Guid idUsuario = new Guid("784c07f2-2b26-4973-9235-4064e94832b5"); // hardcodeado

            foreach (ProductoCarrito prod in productos)
            {
                
                // string json = JsonConvert.SerializeObject(prod, Formatting.Indented);

                string error = persistencia.AgregarVenta(prod);
                

                if (error != null)
                {
                    MessageBox.Show("Error al registrar la venta:\n" + error);
                    return;
                }
                /*
                else
                {
                    // Confirmación con los datos enviados
                    MessageBox.Show($"Producto enviado correctamente a la API:\n\n{json}", "Confirmación API");
                }
                */
            }

            MessageBox.Show("Venta registrada correctamente.");
            productosCarritoDinamico.Clear();
            ventasNegocio.LimpiarCarrito();
            IniciarTotales();
        }

        public List<ProductoCarrito> GenerarProductosParaWS()
        {
            List<ProductoCarrito> lista = new List<ProductoCarrito>();

            if (cmbClientes.SelectedItem == null)
                return lista;

            Cliente cliente = (Cliente)cmbClientes.SelectedItem;
            Guid idUsuario = new Guid("784c07f2-2b26-4973-9235-4064e94832b5"); // Hardcodeado

            foreach (var display in productosCarritoDinamico)
            {
                lista.Add(new ProductoCarrito
                {
                    IdCliente = cliente.Id,
                    IdUsuario = idUsuario,
                    IdProducto = display.IdProducto,
                    Cantidad = display.Cantidad
                });
            }

            return lista;
        }


    }
}
