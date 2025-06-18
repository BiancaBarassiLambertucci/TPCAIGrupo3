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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Por favor, ingrese el Legajo del usuario para modificar sus datos.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelFechaDeIngreso
            // 
            this.labelFechaDeIngreso.AutoSize = true;
            this.labelFechaDeIngreso.Location = new System.Drawing.Point(36, 418);
            this.labelFechaDeIngreso.Name = "labelFechaDeIngreso";
            this.labelFechaDeIngreso.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelFechaDeIngreso.Size = new System.Drawing.Size(134, 20);
            this.labelFechaDeIngreso.TabIndex = 9;
            this.labelFechaDeIngreso.Text = "Fecha de Ingreso";
            // 
            // labelLegajo
            // 
            this.labelLegajo.AutoSize = true;
            this.labelLegajo.Location = new System.Drawing.Point(36, 110);
            this.labelLegajo.Name = "labelLegajo";
            this.labelLegajo.Size = new System.Drawing.Size(57, 20);
            this.labelLegajo.TabIndex = 10;
            this.labelLegajo.Text = "Legajo";
            // 
            // textBoxLegajo
            // 
            this.textBoxLegajo.Location = new System.Drawing.Point(233, 110);
            this.textBoxLegajo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxLegajo.Name = "textBoxLegajo";
            this.textBoxLegajo.Size = new System.Drawing.Size(167, 26);
            this.textBoxLegajo.TabIndex = 11;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(233, 234);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(167, 26);
            this.textBoxNombre.TabIndex = 13;
            // 
            // buscarLegajo
            // 
            this.buscarLegajo.Location = new System.Drawing.Point(39, 160);
            this.buscarLegajo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buscarLegajo.Name = "buscarLegajo";
            this.buscarLegajo.Size = new System.Drawing.Size(124, 40);
            this.buscarLegajo.TabIndex = 15;
            this.buscarLegajo.Text = "Buscar";
            this.buscarLegajo.UseVisualStyleBackColor = true;
            this.buscarLegajo.Click += new System.EventHandler(this.buscarLegajo_Click);
            // 
            // guardarCambios
            // 
            this.guardarCambios.Location = new System.Drawing.Point(38, 475);
            this.guardarCambios.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guardarCambios.Name = "guardarCambios";
            this.guardarCambios.Size = new System.Drawing.Size(124, 40);
            this.guardarCambios.TabIndex = 16;
            this.guardarCambios.Text = "Guardar";
            this.guardarCambios.UseVisualStyleBackColor = true;
            this.guardarCambios.Click += new System.EventHandler(this.guardarCambios_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(36, 241);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelNombre.Size = new System.Drawing.Size(65, 20);
            this.labelNombre.TabIndex = 19;
            this.labelNombre.Text = "Nombre";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(36, 300);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelApellido.Size = new System.Drawing.Size(65, 20);
            this.labelApellido.TabIndex = 20;
            this.labelApellido.Text = "Apellido";
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Location = new System.Drawing.Point(36, 360);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelDNI.Size = new System.Drawing.Size(37, 20);
            this.labelDNI.TabIndex = 21;
            this.labelDNI.Text = "DNI";
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(233, 296);
            this.textBoxApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(167, 26);
            this.textBoxApellido.TabIndex = 22;
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(233, 360);
            this.textBoxDNI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(167, 26);
            this.textBoxDNI.TabIndex = 23;
            // 
            // dateTimePickerFechaIngreso
            // 
            this.dateTimePickerFechaIngreso.Location = new System.Drawing.Point(233, 418);
            this.dateTimePickerFechaIngreso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerFechaIngreso.Name = "dateTimePickerFechaIngreso";
            this.dateTimePickerFechaIngreso.Size = new System.Drawing.Size(224, 26);
            this.dateTimePickerFechaIngreso.TabIndex = 24;
            // 
            // FormModificarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 565);
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
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormModificarPersona";
            this.Text = "FormModificarPersona";
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
    }
}