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
    public partial class AgregarUsuarios : Form
    {
        ManejadorUsuarios mu;

        public AgregarUsuarios()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();
            Cargar(); 
        }
        public void DatosUsuarios(string Username, string Password, string Nombre, string ApellidoP, string ApellidoM, string FechaNacimiento, string RFC)
        {
            txttNombreUsuario.Text = Username;
            txtPassword.Text = Password;
            txtNombre.Text = Nombre;
            txtApellidoP.Text = ApellidoP;
            txtApellidoM.Text = ApellidoM;
            dtpFechaNacimiento.Value = DateTime.Parse(FechaNacimiento);
            txtRFC.Text = RFC;

            var permisos = mu.ObtenerPermisos(Username); 
            dtgvPermisos.Rows.Clear();

            foreach (var permiso in permisos)
            {
                dtgvPermisos.Rows.Add(permiso.Formulario, permiso.Lectura, permiso.Escritura, permiso.Actualizacion, permiso.Eliminacion);
            }
        }
        public void Cargar()
        {
            dtgvPermisos.Rows.Clear();

            string[] formularios = { "Usuarios", "Taller", "Refacciones" };

            foreach (var formulario in formularios)
            {
                dtgvPermisos.Rows.Add(formulario, false, false, false, false);
            }
            dtgvPermisos.AutoResizeColumns();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(BuscarUsuarios.username))
            {
                mu.Guardar(txttNombreUsuario, txtPassword, txtNombre, txtApellidoP, txtApellidoM, dtpFechaNacimiento, txtRFC, dtgvPermisos);
                MessageBox.Show("Se ha realizado el registro"); 
            }
            else
            {
                mu.Modificar(txttNombreUsuario, txtPassword, txtNombre, txtApellidoP, txtApellidoM, dtpFechaNacimiento, txtRFC, dtgvPermisos);
                MessageBox.Show("Se ha modificado el registro"); 
            }
            Close(); 
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

