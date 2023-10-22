using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba1
{
    public partial class FrGenerarFactura : Form
    {
        public FrGenerarFactura()
        {
            InitializeComponent();
        }

        private void DTGVisualizarFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*NO TIENE XQ SER UN DTG, PUESTO SOLO PARA EL DISEÑO, SERA UN VISUALIZADOR DE FACTURAS DE PDF X EJEMPLO*/
        }
    }
}
