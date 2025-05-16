namespace TemplateTPCorto
{
    partial class FormMenu
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
            this.buttonCambiarContraseña = new System.Windows.Forms.Button();
            this.labelAgradecimiento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCambiarContraseña
            // 
            this.buttonCambiarContraseña.Location = new System.Drawing.Point(45, 93);
            this.buttonCambiarContraseña.Name = "buttonCambiarContraseña";
            this.buttonCambiarContraseña.Size = new System.Drawing.Size(206, 58);
            this.buttonCambiarContraseña.TabIndex = 1;
            this.buttonCambiarContraseña.Text = "Cambiar Contraseña";
            this.buttonCambiarContraseña.UseVisualStyleBackColor = true;
            this.buttonCambiarContraseña.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelAgradecimiento
            // 
            this.labelAgradecimiento.AutoSize = true;
            this.labelAgradecimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgradecimiento.Location = new System.Drawing.Point(42, 51);
            this.labelAgradecimiento.Name = "labelAgradecimiento";
            this.labelAgradecimiento.Size = new System.Drawing.Size(596, 18);
            this.labelAgradecimiento.TabIndex = 2;
            this.labelAgradecimiento.Text = "Gracias por autenticarse en el sistema. Por favor, actualice su contraseña para c" +
    "ontinuar.";
            this.labelAgradecimiento.Click += new System.EventHandler(this.labelAgradecimiento_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 380);
            this.Controls.Add(this.labelAgradecimiento);
            this.Controls.Add(this.buttonCambiarContraseña);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCambiarContraseña;
        private System.Windows.Forms.Label labelAgradecimiento;
    }
}