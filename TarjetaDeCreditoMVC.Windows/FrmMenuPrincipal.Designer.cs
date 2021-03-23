
namespace TarjetaDeCreditoMVC.Windows
{
    partial class FrmMenuPrincipal
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
            this.btnCarteraConsumo = new System.Windows.Forms.Button();
            this.btnProvincia = new System.Windows.Forms.Button();
            this.btnTipoDocumento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCarteraConsumo
            // 
            this.btnCarteraConsumo.Location = new System.Drawing.Point(28, 25);
            this.btnCarteraConsumo.Margin = new System.Windows.Forms.Padding(4);
            this.btnCarteraConsumo.Name = "btnCarteraConsumo";
            this.btnCarteraConsumo.Size = new System.Drawing.Size(189, 49);
            this.btnCarteraConsumo.TabIndex = 1;
            this.btnCarteraConsumo.Text = "Cartera de consumo";
            this.btnCarteraConsumo.UseVisualStyleBackColor = true;
            this.btnCarteraConsumo.Click += new System.EventHandler(this.btnCarteraConsumo_Click);
            // 
            // btnProvincia
            // 
            this.btnProvincia.Location = new System.Drawing.Point(28, 103);
            this.btnProvincia.Margin = new System.Windows.Forms.Padding(4);
            this.btnProvincia.Name = "btnProvincia";
            this.btnProvincia.Size = new System.Drawing.Size(189, 49);
            this.btnProvincia.TabIndex = 2;
            this.btnProvincia.Text = "Provincias";
            this.btnProvincia.UseVisualStyleBackColor = true;
            this.btnProvincia.Click += new System.EventHandler(this.btnProvincia_Click);
            // 
            // btnTipoDocumento
            // 
            this.btnTipoDocumento.Location = new System.Drawing.Point(28, 189);
            this.btnTipoDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.btnTipoDocumento.Name = "btnTipoDocumento";
            this.btnTipoDocumento.Size = new System.Drawing.Size(189, 49);
            this.btnTipoDocumento.TabIndex = 3;
            this.btnTipoDocumento.Text = "Tipos de documentos";
            this.btnTipoDocumento.UseVisualStyleBackColor = true;
            this.btnTipoDocumento.Click += new System.EventHandler(this.btnTipoDocumento_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 450);
            this.Controls.Add(this.btnTipoDocumento);
            this.Controls.Add(this.btnProvincia);
            this.Controls.Add(this.btnCarteraConsumo);
            this.Name = "FrmMenuPrincipal";
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCarteraConsumo;
        private System.Windows.Forms.Button btnProvincia;
        private System.Windows.Forms.Button btnTipoDocumento;
    }
}