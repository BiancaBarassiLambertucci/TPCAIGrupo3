namespace TemplateTPCorto
{
    partial class FormOperador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperador));
            this.cambiarContraseña = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCargarVenta = new System.Windows.Forms.Button();
            this.btnCerrarSesion1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cambiarContraseña
            // 
            this.cambiarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cambiarContraseña.Location = new System.Drawing.Point(139, 128);
            this.cambiarContraseña.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cambiarContraseña.Name = "cambiarContraseña";
            this.cambiarContraseña.Size = new System.Drawing.Size(124, 31);
            this.cambiarContraseña.TabIndex = 1;
            this.cambiarContraseña.Text = "Cambiar Contraseña";
            this.cambiarContraseña.UseVisualStyleBackColor = true;
            this.cambiarContraseña.Click += new System.EventHandler(this.cambiarContraseña_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bienvenido al sistema, Operador";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCargarVenta
            // 
            this.btnCargarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarVenta.Location = new System.Drawing.Point(139, 93);
            this.btnCargarVenta.Name = "btnCargarVenta";
            this.btnCargarVenta.Size = new System.Drawing.Size(124, 28);
            this.btnCargarVenta.TabIndex = 3;
            this.btnCargarVenta.Text = "Cargar Venta";
            this.btnCargarVenta.UseVisualStyleBackColor = true;
            this.btnCargarVenta.Click += new System.EventHandler(this.btnCargarVenta_Click);
            // 
            // btnCerrarSesion1
            // 
            this.btnCerrarSesion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion1.Location = new System.Drawing.Point(11, 197);
            this.btnCerrarSesion1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCerrarSesion1.Name = "btnCerrarSesion1";
            this.btnCerrarSesion1.Size = new System.Drawing.Size(105, 23);
            this.btnCerrarSesion1.TabIndex = 4;
            this.btnCerrarSesion1.Text = "Cerrar Sesión";
            this.btnCerrarSesion1.UseVisualStyleBackColor = true;
            this.btnCerrarSesion1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 232);
            this.Controls.Add(this.btnCerrarSesion1);
            this.Controls.Add(this.btnCargarVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cambiarContraseña);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormOperador";
            this.Text = "Menú Operador";
            this.Load += new System.EventHandler(this.FormOperador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cambiarContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargarVenta;
        private System.Windows.Forms.Button btnCerrarSesion1;
    }
}