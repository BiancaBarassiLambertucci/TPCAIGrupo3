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

        public FormSupervisor(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
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
    }
}
