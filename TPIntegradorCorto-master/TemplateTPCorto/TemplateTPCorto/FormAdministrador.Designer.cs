namespace TemplateTPCorto
{
    partial class FormAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdministrador));
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.CambiosPendientes = new System.Windows.Forms.ListBox();
            this.btnCerrarSesión = new System.Windows.Forms.Button();
            this.btnCambiarContraseña = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAprobar
            // 
            this.btnAprobar.Location = new System.Drawing.Point(204, 225);
            this.btnAprobar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(126, 27);
            this.btnAprobar.TabIndex = 0;
            this.btnAprobar.Text = "Aprobar Cambio";
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click_1);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Location = new System.Drawing.Point(361, 225);
            this.btnRechazar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(126, 27);
            this.btnRechazar.TabIndex = 1;
            this.btnRechazar.Text = "Rechazar Cambio";
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // CambiosPendientes
            // 
            this.CambiosPendientes.FormattingEnabled = true;
            this.CambiosPendientes.Location = new System.Drawing.Point(26, 23);
            this.CambiosPendientes.Margin = new System.Windows.Forms.Padding(2);
            this.CambiosPendientes.Name = "CambiosPendientes";
            this.CambiosPendientes.Size = new System.Drawing.Size(638, 186);
            this.CambiosPendientes.TabIndex = 2;
            // 
            // btnCerrarSesión
            // 
            this.btnCerrarSesión.Location = new System.Drawing.Point(11, 277);
            this.btnCerrarSesión.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrarSesión.Name = "btnCerrarSesión";
            this.btnCerrarSesión.Size = new System.Drawing.Size(82, 21);
            this.btnCerrarSesión.TabIndex = 3;
            this.btnCerrarSesión.Text = "Cerrar Sesión";
            this.btnCerrarSesión.UseVisualStyleBackColor = true;
            this.btnCerrarSesión.Click += new System.EventHandler(this.btnCerrarSesión_Click);
            // 
            // btnCambiarContraseña
            // 
            this.btnCambiarContraseña.Location = new System.Drawing.Point(280, 269);
            this.btnCambiarContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.btnCambiarContraseña.Name = "btnCambiarContraseña";
            this.btnCambiarContraseña.Size = new System.Drawing.Size(126, 27);
            this.btnCambiarContraseña.TabIndex = 4;
            this.btnCambiarContraseña.Text = "Cambiar Contraseña";
            this.btnCambiarContraseña.UseVisualStyleBackColor = true;
            this.btnCambiarContraseña.Click += new System.EventHandler(this.btnCambiarContraseña_Click);
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 306);
            this.Controls.Add(this.btnCambiarContraseña);
            this.Controls.Add(this.btnCerrarSesión);
            this.Controls.Add(this.CambiosPendientes);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnAprobar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAdministrador";
            this.Text = "Menú Administrador";
            this.Load += new System.EventHandler(this.FormAdministrador_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.ListBox CambiosPendientes;
        private System.Windows.Forms.Button btnCerrarSesión;
        private System.Windows.Forms.Button btnCambiarContraseña;
    }
}