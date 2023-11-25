using Controladores;
using System;
using System.Windows.Forms;

namespace HotelSol
{
    public partial class accesoUsuario : Form
    {
        private controlador controladorAcceso = new controlador();

        public accesoUsuario()
        {
            InitializeComponent();
        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contraseña = textBox2.Text;

            if (controladorAcceso.ValidarUsuario(usuario, contraseña))
            {
                // La validación fue exitosa, abre la siguiente ventana (opcionesGestion)
                opcionesGestion opcionesGestion = new opcionesGestion();
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
