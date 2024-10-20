using Entidades;
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
    public partial class BuscarRefacciones : Form
    {
        ManejadorRefacciones mr;
        public static string codigoBarras = "";
        public static string nombre = "";
        public static string marca = "";
        public static string descripcion = ""; 

        public BuscarRefacciones()
        {
            InitializeComponent();
            mr = new ManejadorRefacciones();
            Verificar(); 
        }

        private void dtgvRefacciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                DataGridViewRow row = dtgvRefacciones.Rows[e.RowIndex];

                codigoBarras = row.Cells["codigo_barras"].Value.ToString();
                nombre = row.Cells["nombre"].Value.ToString();
                descripcion = row.Cells["descripcion"].Value.ToString();
                marca = row.Cells["marca"].Value.ToString();
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mr.MostrarRefacciones(dtgvRefacciones, txtBuscar.Text);
            dtgvRefacciones.Visible = true; 
        }
        public void Verificar()
        {
            btnAgregar.Enabled = Permisos.Refacciones_Escritura;
            btnModificar.Enabled = Permisos.Refacciones_Actualizacion;
            btnEliminar.Enabled = Permisos.Refacciones_Eliminacion; 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarRefacciones ar = new AgregarRefacciones();
            ar.ShowDialog();
            dtgvRefacciones.Visible = false; 
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dtgvRefacciones.SelectedRows.Count > 0)
            {
                AgregarRefacciones ar = new AgregarRefacciones();
                ar.DatosRefacciones(codigoBarras, nombre, descripcion, marca);
                ar.ShowDialog();
                dtgvRefacciones.Visible = false;
            }
            else
            {
                MessageBox.Show("No haz seleccionado ninguna fila", "ATENCIÓN!!!!",MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dtgvRefacciones.SelectedRows.Count > 0)
            {
                codigoBarras = dtgvRefacciones.SelectedRows[0].Cells["codigo_barras"].Value.ToString();
                mr.EliminarRefacciones(codigoBarras, nombre);
                dtgvRefacciones.Visible = false;
            }
            else
            {
                MessageBox.Show("No haz seleccionado ninguna fila", "ATENCIÓN!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
