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
            this.bienvenidaOperador = new System.Windows.Forms.Label();
            this.cambiarContraseña = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bienvenidaOperador
            // 
            this.bienvenidaOperador.AutoSize = true;
            this.bienvenidaOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bienvenidaOperador.Location = new System.Drawing.Point(5, 20);
            this.bienvenidaOperador.Name = "bienvenidaOperador";
            this.bienvenidaOperador.Size = new System.Drawing.Size(551, 39);
            this.bienvenidaOperador.TabIndex = 0;
            this.bienvenidaOperador.Text = "Bienvenido al sistema, Operador.";
            // 
            // cambiarContraseña
            // 
            this.cambiarContraseña.Location = new System.Drawing.Point(12, 107);
            this.cambiarContraseña.Name = "cambiarContraseña";
            this.cambiarContraseña.Size = new System.Drawing.Size(157, 56);
            this.cambiarContraseña.TabIndex = 1;
            this.cambiarContraseña.Text = "Cambiar Contraseña";
            this.cambiarContraseña.UseVisualStyleBackColor = true;
            // 
            // FormOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cambiarContraseña);
            this.Controls.Add(this.bienvenidaOperador);
            this.Name = "FormOperador";
            this.Text = "FormOperador";
            this.Load += new System.EventHandler(this.FormOperador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bienvenidaOperador;
        private System.Windows.Forms.Button cambiarContraseña;
    }
}