namespace TemplateTPCorto
{
    partial class FormCambioContraseña
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
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.labelNuevaContraseña = new System.Windows.Forms.Label();
            this.textBoxNuevaContraseña = new System.Windows.Forms.TextBox();
            this.labelMensaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(22, 158);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(102, 32);
            this.buttonConfirmar.TabIndex = 0;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // labelNuevaContraseña
            // 
            this.labelNuevaContraseña.AutoSize = true;
            this.labelNuevaContraseña.Location = new System.Drawing.Point(20, 94);
            this.labelNuevaContraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNuevaContraseña.Name = "labelNuevaContraseña";
            this.labelNuevaContraseña.Size = new System.Drawing.Size(98, 13);
            this.labelNuevaContraseña.TabIndex = 1;
            this.labelNuevaContraseña.Text = "Nueva contraseña:";
            this.labelNuevaContraseña.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxNuevaContraseña
            // 
            this.textBoxNuevaContraseña.Location = new System.Drawing.Point(22, 119);
            this.textBoxNuevaContraseña.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNuevaContraseña.Name = "textBoxNuevaContraseña";
            this.textBoxNuevaContraseña.Size = new System.Drawing.Size(141, 20);
            this.textBoxNuevaContraseña.TabIndex = 2;
            this.textBoxNuevaContraseña.TextChanged += new System.EventHandler(this.textBoxNuevaContraseña_TextChanged);
            // 
            // labelMensaje
            // 
            this.labelMensaje.Location = new System.Drawing.Point(20, 21);
            this.labelMensaje.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMensaje.Name = "labelMensaje";
            this.labelMensaje.Size = new System.Drawing.Size(352, 48);
            this.labelMensaje.TabIndex = 3;
            this.labelMensaje.Text = "Por motivos de seguridad, debe cambiar su contraseña. Este requisito aplica si es" +
    " su primer inicio de sesión o si han transcurrido más de 30 días desde su último" +
    " acceso.";
            // 
            // FormCambioContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 306);
            this.Controls.Add(this.labelMensaje);
            this.Controls.Add(this.textBoxNuevaContraseña);
            this.Controls.Add(this.labelNuevaContraseña);
            this.Controls.Add(this.buttonConfirmar);
            this.Name = "FormCambioContraseña";
            this.Text = "CambioContraseña";
            this.Load += new System.EventHandler(this.CambioContraseña_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Label labelNuevaContraseña;
        private System.Windows.Forms.TextBox textBoxNuevaContraseña;
        private System.Windows.Forms.Label labelMensaje;
    }
}