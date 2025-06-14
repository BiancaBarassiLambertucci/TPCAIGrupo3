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

        private BindingList<ProductoCarrito> productosCarritoDinamico = new BindingList<ProductoCarrito>();

        private void FormVentas_Load_1(object sender, EventArgs e)
        {
            CargarClientes();
            CargarCategoriasProductos();
            IniciarTotales();
            dgvCarrito.DataSource = productosCarritoDinamico;

        }

        private void IniciarTotales()
        {
            lablSubTotal.Text = "0.00";
            lblTotal.Text = "0.00";
        }

        private VentaNegocio ventasNegocio = new VentaNegocio();

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
                lstProducto.DisplayMember = "Nombre"; // Asegurate que Producto tiene esta propiedad
            
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

            ProductoCarrito seleccionado = (ProductoCarrito)dgvCarrito.SelectedRows[0].DataBoundItem;
            ventasNegocio.QuitarProducto(seleccionado.IdProducto);

            productosCarritoDinamico.Clear();
            foreach (var item in ventasNegocio.ObtenerCarrito())
            {
                productosCarritoDinamico.Add(item);
            }

            //ActualizarTotales();
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

                // Refrescar la grilla del carrito
                productosCarritoDinamico.Clear();
                foreach (var item in ventasNegocio.ObtenerCarrito())
                {
                    productosCarritoDinamico.Add(item);
                }

                // Actualizar totales
               // ActualizarTotales();

                // Limpiar campo cantidad
                txtCantidad.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /*private void ActualizarTotales()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> productosDisponibles = productoNegocio.ObtenerProductos(); // o una versión que te devuelva todos

            List<ProductoCarrito> carrito = ventasNegocio.ObtenerCarrito();

            decimal subtotal = ventasNegocio.ObtenerSubtotal(carrito, productosDisponibles);
            decimal total = ventasNegocio.ObtenerTotalConDescuento(carrito, productosDisponibles);

            lablSubTotal.Text = subtotal.ToString("C");
            lblTotal.Text = total.ToString("C");
        }
        */

       
    }
}
