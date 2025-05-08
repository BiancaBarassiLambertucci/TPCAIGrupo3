﻿using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Persistencia.DataBase;
using System.Globalization;

namespace TemplateTPCorto
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)

        {

            LoginNegocio loginNegocio = new LoginNegocio();

            //Paso a variables lo que tenemos en el textbox
            String usuarioTxt = txtUsuario.Text;

            String contraseñaTxt = txtPassword.Text;

            //Validaciones de negocio

            if (string.IsNullOrWhiteSpace(usuarioTxt))
            {
                MessageBox.Show("Debe ingresar el usuario para poder ingresar.");
                return;
            }
            if (string.IsNullOrWhiteSpace(contraseñaTxt))
            {
                MessageBox.Show("Debe ingresar la contraseña para poder ingresar.");
                return;
            }
            //Longitud de password (mayor igual a 8) 

            if (contraseñaTxt.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener 8 o más caracteres.");
                return;
            }

            List<string> usuarios = BuscarRegistro(); //Llamo al método que lee el archivo csv y devuelve una lista de lineas. Cada linea representa un usuario.
           
            bool loginCorrecto = false; //Creo variable para saber si encontramos o no un usuario valido
            bool primeraLinea = true;
            
            foreach (string linea in usuarios)
            {
                //MessageBox.Show(linea); // Validación ver cada línea que se lee
                if (primeraLinea)
                {
                    primeraLinea = false;
                    continue; // Saltar encabezado del archivo
                }
                string[] datos = linea.Split(';'); //Partimos cada linea con ; para poder separar los campos

                if (datos.Length < 5) //Evita errores si el archivo tiene alguna linea mal escrita (ej. que falte algun campo) y la saltea para leer otra linea.
                {
                    continue;
                }
                string legajoCredencial = datos[0];
                string usuarioCredencial = datos[1];
                string contraseñaCredencial = datos[2];
                DateTime fechaAltaCredencial = DateTime.ParseExact(datos[3], "d/M/yyyy", CultureInfo.InvariantCulture);
                DateTime fechaUltimoLoginCredencial = DateTime.ParseExact(datos[4], "d/M/yyyy", CultureInfo.InvariantCulture);

                //Comparar usuario y contraseña ingresada vs. credenciales csv
                if (usuarioTxt == usuarioCredencial && contraseñaTxt == contraseñaCredencial)
                {
                    loginCorrecto = true;

                    TimeSpan diferenciasFechas = DateTime.Now - fechaUltimoLoginCredencial;
                    if (diferenciasFechas.Days > 30) // 1.4) Expira password?
                    {
                        MessageBox.Show("La contraseña ha expirado. Por favor, actualízala.");
                        this.Hide(); //Oculta el formulario actual
                        CambioContraseña formContraseña = new CambioContraseña(); //Crea una instancia del formulario contraseña
                        formContraseña.ShowDialog(); //Muestra el menú contraseña de forma modal
                    }
                    else
                    {
                        MessageBox.Show("¡Acceso concedido!"); // Redirigir
                        //Oculta el formulario actual
                        //Crea una instancia del formulario principal
                        //Muestra el menú principal de forma modal
                    }
                    break; //Salgo del loop porque encontré al usuario
                }
            }
            if (!loginCorrecto)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
        //Revisar cómo llamar al método en Persistencia llamado BuscarRegistro()
        public List<String> BuscarRegistro()
        {
            DataBaseUtils dbUtils = new DataBaseUtils();
            List<string> registros = dbUtils.BuscarRegistro("Credenciales.csv");
            return registros;
        }
        
    }

}

