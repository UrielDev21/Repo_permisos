using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Acceso_datos; 

namespace Manejador
{
    public class ManejadorTaller
    {
        Funciones f = new Funciones(); // Se crea el objeto para la usar la clase de funciones

        // Metodo para guardar las herramientas en la tabla de taller
        public void GuardarHerramientas(TextBox CodigoHerramienta, TextBox Nombre, TextBox Medida, TextBox Marca, TextBox Descripcion)
        {
            MessageBox.Show(f.Guardar($"call p_insertar_herramienta('{CodigoHerramienta.Text}', '{Nombre.Text}', '{Medida.Text}', '{Marca.Text}', '{Descripcion.Text}')"),
                "ATENCIÓN!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Metodo para modificar las herramientas en la tabla de taller
        public void ModificarHerramienta(TextBox CodigoHerramienta, TextBox Nombre, TextBox Medida, TextBox Marca, TextBox Descripcion)
        {
            MessageBox.Show(f.Modificar($" call p_modificar_herramienta('{CodigoHerramienta.Text}', '{Nombre.Text}', '{Medida.Text}', '{Marca.Text}', '{Descripcion.Text}')"),
                "ATENCIÓN!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        // Metodo para borrar las herramientas de la tabla de taller
        public void BorrarHerramienta(string CodigoHerramienta, string Dato)
        {
            DialogResult rs = MessageBox.Show($"Estas seguro de borrar {Dato}?", "ATENCIÓN!!!!", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning); 
            if (rs == DialogResult.Yes)
            {
                f.Borrar($"call p_eliminar_herramienta('{CodigoHerramienta}')");
                MessageBox.Show("SE HA ELIMINADO EL REGISTRO", "ATENCIÓN!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
        }

        // Metodo para mostrar la informacion de la tabla en el datagrid
        public void MostrarHerramienta(DataGridView Tabla, string Filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = f.Mostrar($"select * from v_vista_taller where nombre like '%{Filtro}%'", "taller").Tables[0];
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows(); 
        }
    }
}
