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
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cambiarContraseña
            // 
            this.cambiarContraseña.Location = new System.Drawing.Point(68, 64);
            this.cambiarContraseña.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cambiarContraseña.Name = "cambiarContraseña";
            this.cambiarContraseña.Size = new System.Drawing.Size(118, 29);
            this.cambiarContraseña.TabIndex = 1;
            this.cambiarContraseña.Text = "Cambiar Contraseña";
            this.cambiarContraseña.UseVisualStyleBackColor = true;
            this.cambiarContraseña.Click += new System.EventHandler(this.cambiarContraseña_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bienvenido al sistema, Operador.";
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Location = new System.Drawing.Point(68, 117);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(118, 23);
            this.btnRegistrarVenta.TabIndex = 3;
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // FormOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 210);
            this.Controls.Add(this.btnRegistrarVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cambiarContraseña);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormOperador";
            this.Text = "FormOperador";
            this.Load += new System.EventHandler(this.FormOperador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cambiarContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrarVenta;
    }
}