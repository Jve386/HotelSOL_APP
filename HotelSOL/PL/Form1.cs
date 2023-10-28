using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using HotelSOL.PL;

namespace HotelSOL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-IJ8D8R0\SQLEXPRESS;Initial Catalog=HotelSOL;Integrated Security=True");

        private void aceptarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_usuario.Clear();
            txt_contrasena.Clear();

            txt_usuario.Focus();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //uso de entity framekwork

            using (Models.HotelSOLEntities2 db = new Models.HotelSOLEntities2())
            {
                var lst = from query_usuario in db.login_test
                          where query_usuario.usuario == txt_usuario.Text
                          && query_usuario.contrasena == txt_contrasena.Text
                          select query_usuario;
                if (lst.Count() > 0)
                {
                    MenuForm form2 = new MenuForm();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("error de acceso");
                }
            }


            //CONEXIÓN DIRECTA SIN FRAMEWORK

            //String usuario, contrasena;

            //usuario = txt_usuario.Text;
            //contrasena = txt_contrasena.Text;


            //try
            //{
            //    String querry = "SELECT * FROM login_test WHERE usuario = '" + txt_usuario.Text + "' AND contrasena = '" + txt_contrasena.Text + "'";
            //    SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

            //    DataTable dTable = new DataTable();
            //    sda.Fill(dTable);

            //    if (dTable.Rows.Count > 0)
            //    {
            //        usuario = txt_usuario.Text;
            //        contrasena = txt_contrasena.Text;

            //        //pagina que confirma el acceso.
            //        MenuForm form2 = new MenuForm();
            //        form2.Show();
            //        this.Hide();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error de acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txt_usuario.Clear();
            //        txt_contrasena.Clear();

            //        //focus a usuario
            //        txt_usuario.Focus();
            //    }

            //}
            //catch
            //{
            //    MessageBox.Show("Error");
            //}
            //finally
            //{
            //    conn.Close();
            //}
        }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void groupBox1_Enter(object sender, EventArgs e)
            {

            }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Quieres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }
    }
}
