namespace TemplateTPCorto
{
    partial class FormSupervisor
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
            this.btnModificarPersona = new System.Windows.Forms.Button();
            this.btnDesbloquearCredencial = new System.Windows.Forms.Button();
            this.btnCambiarContraseñaPropia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModificarPersona
            // 
            this.btnModificarPersona.Location = new System.Drawing.Point(231, 107);
            this.btnModificarPersona.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificarPersona.Name = "btnModificarPersona";
            this.btnModificarPersona.Size = new System.Drawing.Size(192, 28);
            this.btnModificarPersona.TabIndex = 0;
            this.btnModificarPersona.Text = "Modificar Persona";
            this.btnModificarPersona.UseVisualStyleBackColor = true;
            this.btnModificarPersona.Click += new System.EventHandler(this.btnModificarPersona_Click);
            // 
            // btnDesbloquearCredencial
            // 
            this.btnDesbloquearCredencial.Location = new System.Drawing.Point(231, 162);
            this.btnDesbloquearCredencial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDesbloquearCredencial.Name = "btnDesbloquearCredencial";
            this.btnDesbloquearCredencial.Size = new System.Drawing.Size(192, 28);
            this.btnDesbloquearCredencial.TabIndex = 1;
            this.btnDesbloquearCredencial.Text = "Desbloquear Credencial";
            this.btnDesbloquearCredencial.UseVisualStyleBackColor = true;
            this.btnDesbloquearCredencial.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCambiarContraseñaPropia
            // 
            this.btnCambiarContraseñaPropia.Location = new System.Drawing.Point(231, 219);
            this.btnCambiarContraseñaPropia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCambiarContraseñaPropia.Name = "btnCambiarContraseñaPropia";
            this.btnCambiarContraseñaPropia.Size = new System.Drawing.Size(192, 28);
            this.btnCambiarContraseñaPropia.TabIndex = 2;
            this.btnCambiarContraseñaPropia.Text = "Cambiar Contraseña";
            this.btnCambiarContraseñaPropia.UseVisualStyleBackColor = true;
            this.btnCambiarContraseñaPropia.Click += new System.EventHandler(this.btnCambiarContraseñaPropia_Click);
            // 
            // FormSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 375);
            this.Controls.Add(this.btnCambiarContraseñaPropia);
            this.Controls.Add(this.btnDesbloquearCredencial);
            this.Controls.Add(this.btnModificarPersona);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormSupervisor";
            this.Text = "FormSupervisor";
            this.Load += new System.EventHandler(this.FormSupervisor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModificarPersona;
        private System.Windows.Forms.Button btnDesbloquearCredencial;
        private System.Windows.Forms.Button btnCambiarContraseñaPropia;
    }
}