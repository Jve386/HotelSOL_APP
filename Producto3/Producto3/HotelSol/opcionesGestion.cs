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
    public partial class opcionesGestion : Form
    {
        public opcionesGestion()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gestionUsuario gu = new gestionUsuario();
            this.Hide();
            gu.Show();
        }
    }
}
