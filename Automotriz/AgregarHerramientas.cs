using Manejador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class AgregarHerramientas : Form
    {
        ManejadorTaller mt = new ManejadorTaller();

        public AgregarHerramientas()
        {
            InitializeComponent();
            mt = new ManejadorTaller(); 
        }
        public void DatosTaller(string CodigoHerramienta, string Nombre, string Medida, string Marca, string Descripcion)
        {
            txtCodigoHerramienta.Text = CodigoHerramienta;
            txtMedida.Text = Nombre;
            txtMedida.Text = Medida;
            txtMarca.Text = Marca;
            txtDescripcion.Text = Descripcion; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(BuscarHerramientas.codigoHerramienta != null && BuscarHerramientas.codigoHerramienta.Length > 0)
            {
                mt.ModificarHerramienta(txtCodigoHerramienta, txtNombre, txtMedida, txtMarca, txtDescripcion);
                MessageBox.Show("Se modifico el registro correctamente", "ATENCIÓN!!!", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            else
            {
                mt.GuardarHerramientas(txtCodigoHerramienta, txtNombre, txtMedida, txtMarca, txtDescripcion);
                MessageBox.Show("Se guardo el registro correctamente", "ATENCIÓN!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close(); 
        }
    }
}
