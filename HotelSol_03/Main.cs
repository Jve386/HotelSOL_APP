using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSol_03
{
    public partial class Main : Form
    {
        Controladores.MainController oMainController = new Controladores.MainController();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource = oMainController.GetList();
        }

    }
}
