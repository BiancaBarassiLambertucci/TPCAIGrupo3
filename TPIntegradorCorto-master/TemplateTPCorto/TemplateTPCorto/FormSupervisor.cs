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
        private string usuario;
        private string legajoUsuario;

        public FormSupervisor(string usuario, string legajoUsuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.legajoUsuario = legajoUsuario;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDesbloquearCredencial formCambio3 = new FormDesbloquearCredencial();
            formCambio3.ShowDialog();
        }

        private string nombreUsuario;
        private void btnCambiarContraseñaPropia_Click(object sender, EventArgs e)
        {
            FormCambioContraseña formCambio = new FormCambioContraseña(nombreUsuario);
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
    }
}
