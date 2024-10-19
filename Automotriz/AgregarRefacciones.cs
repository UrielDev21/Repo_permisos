using Manejador;
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
    public partial class AgregarRefacciones : Form
    {
        ManejadorRefacciones mr; 
        public AgregarRefacciones()
        {
            InitializeComponent();
            mr = new ManejadorRefacciones();
        }
        public void DatosRefacciones(string CodigoBarras, string Nombre, string Descripcion, string Marca)
        {
            txtCodigoBarras.Text = CodigoBarras;
            txtNombre.Text = Nombre;    
            txtDescripcion.Text = Descripcion;
            txtMarca.Text = Marca;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(BuscarRefacciones.codigoBarras != null && BuscarRefacciones.codigoBarras.Length > 0)
            {
                mr.ModificarRefacciones(txtCodigoBarras, txtNombre, txtDescripcion, txtMarca);
                MessageBox.Show("El registro se ha modificado correctamente", "ATENCIÓN!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mr.GuardarRefacciones(txtCodigoBarras, txtNombre, txtDescripcion, txtMarca);
                MessageBox.Show("El registro se ha guardado correctamente", "ATENCIÓN!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LimpiarFormulario();  
            Close(); 
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close(); 
        }
        private void LimpiarFormulario()
        {
            BuscarRefacciones.codigoBarras = null; 
            BuscarRefacciones.nombre = null; ; 
            BuscarRefacciones.descripcion = null;
            BuscarRefacciones.marca = null;
        }
    }
}
