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
    public partial class CambioContraseña3_ : Form
    {
        public CambioContraseña3_()
        {
            InitializeComponent();
        }

        private void btnCContraseña_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario3.Text;
            string nuevaContraseña = txtContraseña3.Text;

            // USAR EL MÉTODO CAMBIAR CONTRASEÑA, QUE ESTÁ EN EL FORMCAMBIAR CONTRASEÑA

        }
    }
}
