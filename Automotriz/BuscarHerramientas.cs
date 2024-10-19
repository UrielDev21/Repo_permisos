using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;
using Entidades;

namespace Automotriz
{
    public partial class BuscarHerramientas : Form
    {
        ManejadorTaller mt;

        public static string codigoHerramienta = "";
        public static string medida = "";
        public static string nombre = "";
        public static string descripcion = "";
        public static string marca = ""; 

        public BuscarHerramientas()
        {
            InitializeComponent();
            mt = new ManejadorTaller();
            Verificar(); 
        }
        private void dtgvHerramientas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dtgvHerramientas.Rows[e.RowIndex];

                codigoHerramienta = row.Cells["Codigo_herramienta"].Value.ToString();
                nombre = row.Cells["nombre"].Value.ToString();
                medida = row.Cells["medida"].Value.ToString();
                descripcion = row.Cells["descripcion"].Value.ToString();
                marca = row.Cells["marca"].Value.ToString();

                row.Selected = true;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mt.MostrarHerramienta(dtgvHerramientas, txtBuscar.Text); 
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void Verificar()
        {
            btnAgregar.Enabled = Permisos.Taller_Escritura;
            btnModificar.Enabled = Permisos.Taller_Actualizacion;
            btnEliminar.Enabled = Permisos.Taller_Eliminacion; 
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dtgvHerramientas.SelectedRows.Count > 0)
            {
                codigoHerramienta = dtgvHerramientas.SelectedRows[0].Cells["Codigo_herramienta"].Value.ToString();
                mt.BorrarHerramienta(codigoHerramienta, nombre); 
            }
            else
            {
                MessageBox.Show("No haz seleccionado ninguna fila", "ATENCIÓN!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgvHerramientas.SelectedRows.Count > 0)
            {
                AgregarHerramientas addH = new AgregarHerramientas();
                addH.DatosTaller(codigoHerramienta, nombre, medida, marca, descripcion); 
                addH.ShowDialog();
            }
            else
            {
                MessageBox.Show("No haz seleccionado ninguna fila", "ATENCIÓN!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarHerramientas addH = new AgregarHerramientas();
            addH.ShowDialog(); 
        }
    }
}
