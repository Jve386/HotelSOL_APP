using HotelSOL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace HotelSOL.DAL
{
    public partial class ImportarXML : Form
    {
        private string fileName = "";
        public ImportarXML()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void ImportarXML_Load(object sender, EventArgs e)
        {
            this.btn_importar.Enabled = false;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Escoge un fichero XML";
            openFileDialog.Filter = "XML File|*.xml";
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if(dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.btn_importar.Enabled = true;
                this.fileName = openFileDialog.FileName;
                MessageBox.Show(this.fileName);
            }
        }

        private void btn_importar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    XDocument xDoc = XDocument.Load(fileName);
            //    List<login_test> login_Tests = xDoc.Descendants("login_test").Select().
            //}
            //catch 
            //{
            //    MessageBox.Show("No se pudo importar el fichero XML");
            //}
            {
                if (string.IsNullOrEmpty(this.fileName))
                {
                    MessageBox.Show("Primero selecciona un archivo XML.");
                    return;
                }

                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(this.fileName);

                    XmlNodeList loginNodes = xmlDoc.SelectNodes("//login_test/login");


                    DataTable dt = new DataTable();
                    dt.Columns.Add("Usuario");
                    dt.Columns.Add("Contrasena");

                    foreach (XmlNode loginNode in loginNodes)
                    {
                        string usuario = loginNode.SelectSingleNode("usuario").InnerText;
                        string contrasena = loginNode.SelectSingleNode("contrasena").InnerText;
                        dt.Rows.Add(usuario, contrasena);
                    }

                    // Enlaza los datos al DataGridView
                    dataGridUsuario.DataSource = dt;

                    string connectionString = "Data Source=DESKTOP-IJ8D8R0\\SQLEXPRESS;Initial Catalog=HotelSOL;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        foreach (XmlNode loginNode in loginNodes)
                        {
                            string usuario = loginNode.SelectSingleNode("usuario").InnerText;
                            string contrasena = loginNode.SelectSingleNode("contrasena").InnerText;

                            // Insertar los datos en la base de datos
                            string insertQuery = "INSERT INTO login_test (usuario, contrasena) VALUES (@Usuario, @Contrasena)";

                            using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@Usuario", usuario);
                                cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Datos importados exitosamente a la base de datos.");
                }                
                catch (Exception ex)
                {
                    MessageBox.Show("Error al importar el archivo XML a la base de datos: " + ex.Message);
                }
            }

        }

        private void dataGridUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtén el valor de la celda en la que se hizo clic
                string cellValue = dataGridUsuario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // Realiza alguna acción con el valor, por ejemplo, mostrarlo en un MessageBox
                MessageBox.Show("Valor de la celda: " + cellValue);
            }
        }
    }
}
