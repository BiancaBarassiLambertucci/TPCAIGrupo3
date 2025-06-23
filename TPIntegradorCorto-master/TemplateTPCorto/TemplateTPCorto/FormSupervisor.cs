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
    public partial class FormSupervisor : Form
    {
        public string usuario;
        public string legajoUsuario;

        public FormSupervisor(string usuario, string legajoUsuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.legajoUsuario = legajoUsuario;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDesbloquearCredencial formCambio3 = new FormDesbloquearCredencial();
            formCambio3.ShowDialog();
            this.Show();
        }

        private void btnCambiarContraseñaPropia_Click(object sender, EventArgs e)
        {
            FormCambioContraseña formCambio = new FormCambioContraseña(usuario);
            formCambio.ShowDialog();
        }

        private void FormSupervisor_Load(object sender, EventArgs e)
        {

        }

        private void btnModificarPersona_Click(object sender, EventArgs e)
        {
            FormModificarPersona formModificar = new FormModificarPersona(legajoUsuario);
            formModificar.ShowDialog();
        }

        private void btnCerrarSesión_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin login = new FormLogin();
            login.ShowDialog();
        }
    }
}
