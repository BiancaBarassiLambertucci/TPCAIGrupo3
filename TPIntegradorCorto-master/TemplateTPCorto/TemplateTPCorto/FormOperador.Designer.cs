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
            this.cambiarContraseña = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCargarVenta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cambiarContraseña
            // 
            this.cambiarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cambiarContraseña.Location = new System.Drawing.Point(242, 220);
            this.cambiarContraseña.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cambiarContraseña.Name = "cambiarContraseña";
            this.cambiarContraseña.Size = new System.Drawing.Size(198, 53);
            this.cambiarContraseña.TabIndex = 1;
            this.cambiarContraseña.Text = "Cambiar Contraseña";
            this.cambiarContraseña.UseVisualStyleBackColor = true;
            this.cambiarContraseña.Click += new System.EventHandler(this.cambiarContraseña_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bienvenido al sistema, Operador.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCargarVenta
            // 
            this.btnCargarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarVenta.Location = new System.Drawing.Point(242, 146);
            this.btnCargarVenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCargarVenta.Name = "btnCargarVenta";
            this.btnCargarVenta.Size = new System.Drawing.Size(198, 53);
            this.btnCargarVenta.TabIndex = 3;
            this.btnCargarVenta.Text = "Cargar Venta";
            this.btnCargarVenta.UseVisualStyleBackColor = true;
            this.btnCargarVenta.Click += new System.EventHandler(this.btnCargarVenta_Click);
            // 
            // FormOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 369);
            this.Controls.Add(this.btnCargarVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cambiarContraseña);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormOperador";
            this.Text = "FormOperador";
            this.Load += new System.EventHandler(this.FormOperador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cambiarContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargarVenta;
    }
}