namespace TemplateTPCorto
{
    partial class FormModificarPersona
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModificarPersona));
            this.label1 = new System.Windows.Forms.Label();
            this.labelFechaDeIngreso = new System.Windows.Forms.Label();
            this.labelLegajo = new System.Windows.Forms.Label();
            this.textBoxLegajo = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.buscarLegajo = new System.Windows.Forms.Button();
            this.guardarCambios = new System.Windows.Forms.Button();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelDNI = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.dateTimePickerFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.btnMenuPrincipal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Por favor, ingrese el Legajo del usuario para modificar sus datos.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelFechaDeIngreso
            // 
            this.labelFechaDeIngreso.AutoSize = true;
            this.labelFechaDeIngreso.Location = new System.Drawing.Point(24, 272);
            this.labelFechaDeIngreso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFechaDeIngreso.Name = "labelFechaDeIngreso";
            this.labelFechaDeIngreso.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelFechaDeIngreso.Size = new System.Drawing.Size(90, 13);
            this.labelFechaDeIngreso.TabIndex = 9;
            this.labelFechaDeIngreso.Text = "Fecha de Ingreso";
            // 
            // labelLegajo
            // 
            this.labelLegajo.AutoSize = true;
            this.labelLegajo.Location = new System.Drawing.Point(24, 72);
            this.labelLegajo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLegajo.Name = "labelLegajo";
            this.labelLegajo.Size = new System.Drawing.Size(39, 13);
            this.labelLegajo.TabIndex = 10;
            this.labelLegajo.Text = "Legajo";
            // 
            // textBoxLegajo
            // 
            this.textBoxLegajo.Location = new System.Drawing.Point(155, 72);
            this.textBoxLegajo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxLegajo.Name = "textBoxLegajo";
            this.textBoxLegajo.Size = new System.Drawing.Size(113, 20);
            this.textBoxLegajo.TabIndex = 11;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(155, 152);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(113, 20);
            this.textBoxNombre.TabIndex = 13;
            // 
            // buscarLegajo
            // 
            this.buscarLegajo.Location = new System.Drawing.Point(26, 104);
            this.buscarLegajo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buscarLegajo.Name = "buscarLegajo";
            this.buscarLegajo.Size = new System.Drawing.Size(83, 26);
            this.buscarLegajo.TabIndex = 15;
            this.buscarLegajo.Text = "Buscar";
            this.buscarLegajo.UseVisualStyleBackColor = true;
            this.buscarLegajo.Click += new System.EventHandler(this.buscarLegajo_Click);
            // 
            // guardarCambios
            // 
            this.guardarCambios.Location = new System.Drawing.Point(25, 309);
            this.guardarCambios.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.guardarCambios.Name = "guardarCambios";
            this.guardarCambios.Size = new System.Drawing.Size(83, 26);
            this.guardarCambios.TabIndex = 16;
            this.guardarCambios.Text = "Guardar";
            this.guardarCambios.UseVisualStyleBackColor = true;
            this.guardarCambios.Click += new System.EventHandler(this.guardarCambios_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(24, 157);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 19;
            this.labelNombre.Text = "Nombre";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(24, 195);
            this.labelApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelApellido.Size = new System.Drawing.Size(44, 13);
            this.labelApellido.TabIndex = 20;
            this.labelApellido.Text = "Apellido";
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Location = new System.Drawing.Point(24, 234);
            this.labelDNI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelDNI.Size = new System.Drawing.Size(26, 13);
            this.labelDNI.TabIndex = 21;
            this.labelDNI.Text = "DNI";
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(155, 192);
            this.textBoxApellido.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(113, 20);
            this.textBoxApellido.TabIndex = 22;
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(155, 234);
            this.textBoxDNI.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(113, 20);
            this.textBoxDNI.TabIndex = 23;
            // 
            // dateTimePickerFechaIngreso
            // 
            this.dateTimePickerFechaIngreso.Location = new System.Drawing.Point(155, 272);
            this.dateTimePickerFechaIngreso.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateTimePickerFechaIngreso.Name = "dateTimePickerFechaIngreso";
            this.dateTimePickerFechaIngreso.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerFechaIngreso.TabIndex = 24;
            // 
            // btnMenuPrincipal
            // 
            this.btnMenuPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.btnMenuPrincipal.Location = new System.Drawing.Point(447, 12);
            this.btnMenuPrincipal.Name = "btnMenuPrincipal";
            this.btnMenuPrincipal.Size = new System.Drawing.Size(89, 23);
            this.btnMenuPrincipal.TabIndex = 25;
            this.btnMenuPrincipal.Text = "Menú Principal";
            this.btnMenuPrincipal.UseVisualStyleBackColor = false;
            this.btnMenuPrincipal.Click += new System.EventHandler(this.btnMenuPrincipal_Click);
            // 
            // FormModificarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 367);
            this.Controls.Add(this.btnMenuPrincipal);
            this.Controls.Add(this.dateTimePickerFechaIngreso);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.labelDNI);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.guardarCambios);
            this.Controls.Add(this.buscarLegajo);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.textBoxLegajo);
            this.Controls.Add(this.labelLegajo);
            this.Controls.Add(this.labelFechaDeIngreso);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormModificarPersona";
            this.Text = "Modificar Persona";
            this.Load += new System.EventHandler(this.FormModificarPersona_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFechaDeIngreso;
        private System.Windows.Forms.Label labelLegajo;
        private System.Windows.Forms.TextBox textBoxLegajo;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Button buscarLegajo;
        private System.Windows.Forms.Button guardarCambios;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaIngreso;
        private System.Windows.Forms.Button btnMenuPrincipal;
    }
}