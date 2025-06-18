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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSupervisor));
            this.btnModificarPersona = new System.Windows.Forms.Button();
            this.btnDesbloquearCredencial = new System.Windows.Forms.Button();
            this.btnCambiarContraseñaPropia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnModificarPersona
            // 
            this.btnModificarPersona.Location = new System.Drawing.Point(134, 85);
            this.btnModificarPersona.Name = "btnModificarPersona";
            this.btnModificarPersona.Size = new System.Drawing.Size(144, 23);
            this.btnModificarPersona.TabIndex = 0;
            this.btnModificarPersona.Text = "Modificar Persona";
            this.btnModificarPersona.UseVisualStyleBackColor = true;
            this.btnModificarPersona.Click += new System.EventHandler(this.btnModificarPersona_Click);
            // 
            // btnDesbloquearCredencial
            // 
            this.btnDesbloquearCredencial.Location = new System.Drawing.Point(134, 124);
            this.btnDesbloquearCredencial.Name = "btnDesbloquearCredencial";
            this.btnDesbloquearCredencial.Size = new System.Drawing.Size(144, 23);
            this.btnDesbloquearCredencial.TabIndex = 1;
            this.btnDesbloquearCredencial.Text = "Desbloquear Credencial";
            this.btnDesbloquearCredencial.UseVisualStyleBackColor = true;
            this.btnDesbloquearCredencial.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCambiarContraseñaPropia
            // 
            this.btnCambiarContraseñaPropia.Location = new System.Drawing.Point(134, 163);
            this.btnCambiarContraseñaPropia.Name = "btnCambiarContraseñaPropia";
            this.btnCambiarContraseñaPropia.Size = new System.Drawing.Size(144, 23);
            this.btnCambiarContraseñaPropia.TabIndex = 2;
            this.btnCambiarContraseñaPropia.Text = "Cambiar Contraseña";
            this.btnCambiarContraseñaPropia.UseVisualStyleBackColor = true;
            this.btnCambiarContraseñaPropia.Click += new System.EventHandler(this.btnCambiarContraseñaPropia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bienvenido al sistema, Supervisor";
            // 
            // FormSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 243);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCambiarContraseñaPropia);
            this.Controls.Add(this.btnDesbloquearCredencial);
            this.Controls.Add(this.btnModificarPersona);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSupervisor";
            this.Text = "FormSupervisor";
            this.Load += new System.EventHandler(this.FormSupervisor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModificarPersona;
        private System.Windows.Forms.Button btnDesbloquearCredencial;
        private System.Windows.Forms.Button btnCambiarContraseñaPropia;
        private System.Windows.Forms.Label label1;
    }
}