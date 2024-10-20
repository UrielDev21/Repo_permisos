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
    public partial class Login : Form
    {
        ManejadorLogin ml; 

        public Login()
        {
            InitializeComponent();
            ml = new ManejadorLogin();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string[] r = ml.Validar(txtUser.Text, txtPass.Text);
            if (r[0].Equals("Correcto"))
            {
                this.Hide();

                Menu men = new Menu();
                men.Show();
            }
            else
            {
                MessageBox.Show("Nombre o contraseña incorrectos", "ATENCIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
