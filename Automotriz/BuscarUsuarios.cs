using Entidades;
using Manejador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automotriz
{
    public partial class BuscarUsuarios : Form
    {
        ManejadorUsuarios mu;
        public static string nombre = "";
        public static string apellidoP = "";
        public static string apellidoM = "";
        public static string fechaNacimiento = "";
        public static string rfc = ""; 
        public static string username = "";
        public static string password = ""; 

        public BuscarUsuarios()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();
            //Verficar(); 
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mu.MostrarGeneral(dtgvUsuarios, txtBuscar.Text);
        }

        private void dtgvUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvUsuarios.Rows[e.RowIndex];

                username = row.Cells["user"].Value.ToString();
                password = row.Cells["pass"].Value.ToString();
                nombre = row.Cells["nombre"].Value.ToString();
                apellidoP = row.Cells["apellidoP"].Value.ToString();
                apellidoM = row.Cells["apellidoM"].Value.ToString();
                fechaNacimiento = row.Cells["fecha_nacimiento"].Value.ToString();
                rfc = row.Cells["rfc"].Value.ToString();
                row.Selected = true; 
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close(); 
        }
        public void Verficar()
        {
            btnAgregar.Enabled = Permisos.Usuarios_Eliminacion;
            btnModificar.Enabled = Permisos.Usuarios_Actualizacion;
            btnEliminar.Enabled = Permisos.Usuarios_Eliminacion; 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarUsuarios au = new AgregarUsuarios();
            au.Show(); 
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(username))
            {
                AgregarUsuarios au = new AgregarUsuarios();
                au.DatosUsuarios(username, password, nombre, apellidoP, apellidoM, fechaNacimiento, rfc);
                au.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("No haz seleccionado ninguna fila", "ATENCIÓN!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgvUsuarios.SelectedRows.Count > 0)
            {
                string userselect = dtgvUsuarios.SelectedRows[0].Cells["user"].Value.ToString();
                mu.Borrar(userselect);
            }
            else
            {
                MessageBox.Show("No haz seleccionado ninguna fila", "ATENCIÓN!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
