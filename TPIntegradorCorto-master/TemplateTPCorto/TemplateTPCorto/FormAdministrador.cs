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
    public partial class FormAdministrador : Form
    {
        private string usuario;
        public FormAdministrador(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {

        }
    }
}
