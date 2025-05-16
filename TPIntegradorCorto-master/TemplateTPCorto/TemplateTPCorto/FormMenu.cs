﻿using System;
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
    public partial class FormMenu : Form
    {
        private string usuario;
        public FormMenu(string nombreUsuario)
        {
            InitializeComponent();
            usuario = nombreUsuario;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCambioContraseña formCambioContra = new FormCambioContraseña(usuario);
            formCambioContra.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelAgradecimiento_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
