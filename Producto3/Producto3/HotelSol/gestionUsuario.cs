using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSol
{
    public partial class gestionUsuario : Form
    {
        Controladores.controlador oControlGestionUsuarios = new Controladores.controlador();
        public gestionUsuario()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gestionUsuario_Load(object sender, EventArgs e)
        {
           //dataGridView1.DataSource = oControlGestionUsuarios.GetList();   Esto en el boton de mostrar

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
