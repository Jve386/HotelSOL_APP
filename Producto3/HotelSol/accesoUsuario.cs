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
    public partial class accesoUsuario : Form
    {
        private ControlAccesoUsuario controladorAcceso = new ControlAccesoUsuario();

        public AccesoUsuario()
        {
            InitializeComponent();
        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (controladorAcceso.ValidarUsuario(usuario, contraseña))
            {
                // La validación fue exitosa, abre la siguiente ventana (opcionesGestion)
                OpcionesGestion opcionesGestion = new OpcionesGestion();
                opcionesGestion.Show();
                this.Hide(); // O cierra esta ventana si no quieres mantenerla abierta
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
