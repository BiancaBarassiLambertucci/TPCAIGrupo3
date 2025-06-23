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
            this.Hide();
            FormVentas formVentas = new FormVentas();
            formVentas.ShowDialog();
            this.Show();
        }

        private void cambiarContraseña_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCambioContraseña formCambio = new FormCambioContraseña(usuario);
            formCambio.ShowDialog();
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin login = new FormLogin();
            login.ShowDialog();
        }
    }
}
