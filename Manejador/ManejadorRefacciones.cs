using Acceso_datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador
{
    public class ManejadorRefacciones
    {
        Funciones f = new Funciones(); // Se crea el objeto para poder usar los metodos de funciones

        // Metodo para guardar refacciones en la tabla de refacciones
        public void GuardarRefacciones(TextBox CodigoBarras, TextBox Nombre, TextBox Descripcion,  TextBox Marca)
        {
            MessageBox.Show(f.Guardar($"call p_insertar_refacciones('{CodigoBarras.Text}', '{Nombre.Text}', '{Descripcion.Text}', '{Marca.Text}')"), 
                "ATENCIÓN!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }
        // Metodo para modificar las refacciones en la tabla de refacciones
        public void ModificarRefacciones(TextBox CodigoBarras, TextBox Nombre, TextBox Descripcion, TextBox Marca)
        {
            MessageBox.Show(f.Modificar($"call p_modificar_refacciones('{CodigoBarras.Text}', '{Nombre.Text}', '{Descripcion.Text}', '{Marca.Text}')"), 
                "ATENCIÓN!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Metodo para eliminar refacciones de la tabla de refacciones 
        public void EliminarRefacciones(string CodigoBarras, string Dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de borrar {Dato}?", "ATENCIÓN!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
            if (rs == DialogResult.Yes)
            {
                f.Borrar($"call p_eliminar_refacciones('{CodigoBarras}')");
                MessageBox.Show("El registro se ha eliminado correctamente", "ATENCIÓN!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
        }
        // Metodo para mostrar la informacion de la tabla de refacciones en un datagrid
        public void MostrarRefacciones(DataGridView Tabla, string Filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = f.Mostrar($"select * from v_vista_refacciones where nombre like '%{Filtro}%'", "refacciones").Tables[0];
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows(); 
        }
    }
}
