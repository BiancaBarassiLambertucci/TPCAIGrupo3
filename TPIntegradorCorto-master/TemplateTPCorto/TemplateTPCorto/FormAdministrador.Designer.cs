﻿namespace TemplateTPCorto
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
            this.SuspendLayout();
            // 
            // btnAprobar
            // 
            this.btnAprobar.Location = new System.Drawing.Point(100, 350);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(189, 42);
            this.btnAprobar.TabIndex = 0;
            this.btnAprobar.Text = "Aprobar Cambio";
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click_1);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Location = new System.Drawing.Point(336, 350);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(189, 42);
            this.btnRechazar.TabIndex = 1;
            this.btnRechazar.Text = "Rechazar Cambio";
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // CambiosPendientes
            // 
            this.CambiosPendientes.FormattingEnabled = true;
            this.CambiosPendientes.ItemHeight = 20;
            this.CambiosPendientes.Location = new System.Drawing.Point(39, 36);
            this.CambiosPendientes.Name = "CambiosPendientes";
            this.CambiosPendientes.Size = new System.Drawing.Size(552, 284);
            this.CambiosPendientes.TabIndex = 2;
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 429);
            this.Controls.Add(this.CambiosPendientes);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnAprobar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAdministrador";
            this.Text = "FormAdministrador";
            this.Load += new System.EventHandler(this.FormAdministrador_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.ListBox CambiosPendientes;
    }
}