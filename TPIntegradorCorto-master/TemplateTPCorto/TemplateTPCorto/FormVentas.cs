using Datos;
using Datos.Ventas;
using Negocio;
using Negocio.Carrito;
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

        private void FormVentas_Load_1(object sender, EventArgs e)
        {
            CargarClientes();
            CargarCategoriasProductos();
            IniciarTotales();
            dgvCarrito.DataSource = productosCarritoDinamico;
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

            productosCarritoDinamico.Clear();
            foreach (var item in ventasNegocio.ObtenerCarrito())
            {
                var prod = productoNegocio.BuscarPorId(item.IdProducto);
                productosCarritoDinamico.Add(new CarritoDisplay
                {
                    Nombre = prod?.Nombre ?? "Desconocido",
                    Precio = prod?.Precio ?? 0,
                    Cantidad = item.Cantidad
                });
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

        public void ActualizarGrillaCarrito()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<ProductoCarrito> carrito = ventasNegocio.ObtenerCarrito();

            var datosParaMostrar = carrito.Select(p =>
            {
                var producto = productoNegocio.BuscarPorId(p.IdProducto);
                return new CarritoDisplay
                {
                    Nombre = producto?.Nombre ?? "Desconocido",
                    Precio = producto?.Precio ?? 0,
                    Cantidad = p.Cantidad
                };
            }).ToList();

            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = datosParaMostrar;

            dgvCarrito.ReadOnly = true;
            dgvCarrito.AllowUserToAddRows = false;
        }


    }
}
