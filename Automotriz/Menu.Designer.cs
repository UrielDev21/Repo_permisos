namespace Automotriz
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optBuscarUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.optBuscarHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.optBuscarRefacciones = new System.Windows.Forms.ToolStripMenuItem();
            this.optSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SlateGray;
            this.menuStrip1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optBuscarUsuarios,
            this.optBuscarHerramientas,
            this.optBuscarRefacciones,
            this.optSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1112, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optBuscarUsuarios
            // 
            this.optBuscarUsuarios.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.optBuscarUsuarios.Name = "optBuscarUsuarios";
            this.optBuscarUsuarios.Size = new System.Drawing.Size(169, 26);
            this.optBuscarUsuarios.Text = "Buscar usuarios";
            this.optBuscarUsuarios.Click += new System.EventHandler(this.optBuscarUsuarios_Click);
            // 
            // optBuscarHerramientas
            // 
            this.optBuscarHerramientas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.optBuscarHerramientas.Name = "optBuscarHerramientas";
            this.optBuscarHerramientas.Size = new System.Drawing.Size(213, 26);
            this.optBuscarHerramientas.Text = "Buscar herramientas";
            this.optBuscarHerramientas.Click += new System.EventHandler(this.optBuscarHerramientas_Click);
            // 
            // optBuscarRefacciones
            // 
            this.optBuscarRefacciones.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.optBuscarRefacciones.Name = "optBuscarRefacciones";
            this.optBuscarRefacciones.Size = new System.Drawing.Size(198, 26);
            this.optBuscarRefacciones.Text = "Buscar refacciones";
            this.optBuscarRefacciones.Click += new System.EventHandler(this.optBuscarRefacciones_Click);
            // 
            // optSalir
            // 
            this.optSalir.BackColor = System.Drawing.Color.Red;
            this.optSalir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.optSalir.Name = "optSalir";
            this.optSalir.Size = new System.Drawing.Size(64, 26);
            this.optSalir.Text = "Salir";
            this.optSalir.Click += new System.EventHandler(this.optSalir_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 806);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optBuscarUsuarios;
        private System.Windows.Forms.ToolStripMenuItem optBuscarHerramientas;
        private System.Windows.Forms.ToolStripMenuItem optBuscarRefacciones;
        private System.Windows.Forms.ToolStripMenuItem optSalir;
    }
}