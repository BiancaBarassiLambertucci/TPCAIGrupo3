namespace TemplateTPCorto
{
    partial class CambioContraseña3_
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
            this.btnCContraseña = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsuario3 = new System.Windows.Forms.TextBox();
            this.txtContraseña3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCContraseña
            // 
            this.btnCContraseña.Location = new System.Drawing.Point(92, 271);
            this.btnCContraseña.Name = "btnCContraseña";
            this.btnCContraseña.Size = new System.Drawing.Size(337, 37);
            this.btnCContraseña.TabIndex = 0;
            this.btnCContraseña.Text = "Cambiar Contraseña";
            this.btnCContraseña.UseVisualStyleBackColor = true;
            this.btnCContraseña.Click += new System.EventHandler(this.btnCContraseña_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Porfavor, ingrese los datos del usuario al que le quiere actualizar la contraseña" +
    ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre De Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nueva Contraseña";
            // 
            // txtUsuario3
            // 
            this.txtUsuario3.Location = new System.Drawing.Point(262, 126);
            this.txtUsuario3.Name = "txtUsuario3";
            this.txtUsuario3.Size = new System.Drawing.Size(167, 26);
            this.txtUsuario3.TabIndex = 4;
            // 
            // txtContraseña3
            // 
            this.txtContraseña3.Location = new System.Drawing.Point(262, 198);
            this.txtContraseña3.Name = "txtContraseña3";
            this.txtContraseña3.Size = new System.Drawing.Size(167, 26);
            this.txtContraseña3.TabIndex = 5;
            // 
            // CambioContraseña3_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 335);
            this.Controls.Add(this.txtContraseña3);
            this.Controls.Add(this.txtUsuario3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCContraseña);
            this.Name = "CambioContraseña3_";
            this.Text = "CambioContraseña3_";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsuario3;
        private System.Windows.Forms.TextBox txtContraseña3;
    }
}