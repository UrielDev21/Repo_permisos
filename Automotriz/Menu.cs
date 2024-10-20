using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            Verificar(); 
        }

        private void optBuscarUsuarios_Click(object sender, EventArgs e)
        {
            BuscarUsuarios bu = new BuscarUsuarios();
            bu.MdiParent = this;
            bu.Show(); 
        }

        private void optBuscarHerramientas_Click(object sender, EventArgs e)
        {
            BuscarHerramientas bh = new BuscarHerramientas();
            bh.MdiParent = this;
            bh.Show();
        }

        private void optBuscarRefacciones_Click(object sender, EventArgs e)
        {
            BuscarRefacciones br = new BuscarRefacciones();
            br.MdiParent = this;
            br.Show();
        }

        private void optSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
        public void Verificar()
        {
            optBuscarUsuarios.Visible = Permisos.Usuarios_Lectura;
            optBuscarRefacciones.Visible = Permisos.Refacciones_Lectura;
            optBuscarHerramientas.Visible = Permisos.Taller_Lectura; 
        }
    }
}
