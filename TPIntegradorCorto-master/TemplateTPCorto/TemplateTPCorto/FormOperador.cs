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
    public partial class FormOperador : Form
    {
        private string usuario;
        private string legajoUsuario;
        public FormOperador(string usuario, string legajoUsuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.legajoUsuario = legajoUsuario;
        }

        private void FormOperador_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnCargarVenta;
        }

        private void btnCargarVenta_Click(object sender, EventArgs e)
        {
            FormVentas formVentas = new FormVentas();
            this.Hide();
            formVentas.ShowDialog();
        }

        private void cambiarContraseña_Click(object sender, EventArgs e)
        {
            FormCambioContraseña formCambio = new FormCambioContraseña(usuario);
            this.Hide();
            formCambio.ShowDialog();
        }     

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
