﻿using Acceso_datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador
{
    public class ManejadorUsuarios
    {
        Funciones f = new Funciones();

        public void Guardar(TextBox Username, TextBox Contraseña, TextBox Nombre, TextBox ApellidoP, TextBox ApellidoM, DateTimePicker FechaNacimiento, TextBox Rfc, DataGridView permisos)
        {
            string fechaNacimiento = FechaNacimiento.Value.ToString("yyyy-MM-dd");
            string queryGuardarUsuario = $"call p_insertar_usuarios('{Nombre.Text}', '{ApellidoP.Text}', '{ApellidoM.Text}', '{fechaNacimiento}', '{Rfc.Text}', '{Username.Text}', sha1('{Contraseña.Text}'))";

            string resultado = f.Guardar(queryGuardarUsuario);

            if (resultado != "Correcto")
            {
                MessageBox.Show($"Error al guardar el usuario: {resultado}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow row in permisos.Rows)
            {
                string nombreFormulario = row.Cells["Formulario"].Value.ToString();
                bool lectura = Convert.ToBoolean(row.Cells["Lectura"].Value);
                bool escritura = Convert.ToBoolean(row.Cells["Escritura"].Value);
                bool actualizacion = Convert.ToBoolean(row.Cells["Actualizacion"].Value);
                bool eliminacion = Convert.ToBoolean(row.Cells["Eliminacion"].Value);

                string queryGuardarPermisos = $"call p_insertar_permiso('{Username.Text}', '{nombreFormulario}', {lectura}, {escritura}, {actualizacion}, {eliminacion});";

                string resultadoPermisos = f.Guardar(queryGuardarPermisos);

                if (resultadoPermisos != "Correcto")
                {
                    MessageBox.Show($"Error al guardar permisos para {nombreFormulario}: {resultadoPermisos}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Usuario y permisos guardados con éxito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Borrar(string Username)
        {
            DialogResult rs = MessageBox.Show($"¿Estás seguro de borrar a {Username}?", "Atención!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string queryEliminarPermisos = $"call p_eliminar_permisos('{Username}');";
                string resultadoPermisos = f.Guardar(queryEliminarPermisos);

                if (resultadoPermisos != "Correcto")
                {
                    MessageBox.Show($"Error al eliminar permisos para {Username}: {resultadoPermisos}, llame a el administrador para revisar el error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string queryEliminarUsuario = $"call p_eliminar_usuarios('{Username}');";
                string resultadoUsuario = f.Guardar(queryEliminarUsuario);

                if (resultadoUsuario != "Correcto")
                {
                    MessageBox.Show($"Error al eliminar el usuario: {resultadoUsuario}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Registro eliminado con éxito", "Atención!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Modificar(TextBox Username, TextBox Contraseña, TextBox Nombre, TextBox ApellidoP, TextBox ApellidoM, DateTimePicker FechaNacimiento, TextBox Rfc, DataGridView permisos)
        {
            string fechaNacimiento = FechaNacimiento.Value.ToString("yyyy-MM-dd");
            string queryModificarUsuario = $"call p_modificar_usuarios('{Nombre.Text}', '{ApellidoP.Text}', '{ApellidoM.Text}', '{fechaNacimiento}', '{Rfc.Text}', '{Username.Text}', sha1('{Contraseña.Text}'))";
            MessageBox.Show(queryModificarUsuario); 

            string resultado = f.Guardar(queryModificarUsuario);

            if (resultado != "Correcto")
            {
                MessageBox.Show($"Error al modificar el usuario: {resultado}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string queryBorrarPermisos = $"call p_eliminar_permisos('{Username.Text}');";
            f.Guardar(queryBorrarPermisos);
            MessageBox.Show(queryBorrarPermisos); 

            foreach (DataGridViewRow row in permisos.Rows)
            {
                string nombreFormulario = row.Cells["Formulario"].Value.ToString();
                bool lectura = Convert.ToBoolean(row.Cells["Lectura"].Value);
                bool escritura = Convert.ToBoolean(row.Cells["Escritura"].Value);
                bool actualizacion = Convert.ToBoolean(row.Cells["Actualizacion"].Value);
                bool eliminacion = Convert.ToBoolean(row.Cells["Eliminacion"].Value);

                string queryGuardarPermisos = $"call p_insertar_permiso('{Username.Text}', '{nombreFormulario}', {lectura}, {escritura}, {actualizacion}, {eliminacion});";

                string resultadoPermisos = f.Guardar(queryGuardarPermisos);

                if (resultadoPermisos != "Correcto")
                {
                    MessageBox.Show($"Error al guardar permisos para {nombreFormulario}: {resultadoPermisos}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Usuario y permisos actualizados con éxito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MostrarGeneral(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.DataSource = f.Mostrar($"select * from usuarios where nombre like '%{filtro}%'", "usuarios").Tables[0];
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }

        public List<Permiso> ObtenerPermisos(string username)
        {
            List<Permiso> permisos = new List<Permiso>();
            DataSet ds = f.Mostrar($"call p_Obtener('{username}')", "permisos");
            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                permisos.Add(new Permiso
                {
                    Formulario = row["nombre_formulario"].ToString(),
                    Lectura = Convert.ToBoolean(row["Lectura"]),
                    Escritura = Convert.ToBoolean(row["Escritura"]),
                    Actualizacion = Convert.ToBoolean(row["Actualizacion"]),
                    Eliminacion = Convert.ToBoolean(row["Eliminacion"])
                });
            }

            return permisos;
        }
        public class Permiso
        {
            public string Formulario { get; set; }
            public bool Lectura { get; set; }
            public bool Escritura { get; set; }
            public bool Actualizacion { get; set; }
            public bool Eliminacion { get; set; }
        }
    }
}
