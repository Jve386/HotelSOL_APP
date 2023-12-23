using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Diagnostics;
using Modelo.EF;
using System.Data;
using System.Linq;

namespace Modelo
{
    public partial class FormOdooHub : Form
    {
        public FormOdooHub()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si hay una opción seleccionada
            if (checkedListBox1.SelectedIndex != -1)
            {
                // Desmarca todas las demás opciones
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i != checkedListBox1.SelectedIndex)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            // Verifica si "Clientes" o "Habitaciones" está marcado en el CheckedListBox
            if (checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf("Clientes")) ||
                checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf("Habitaciones")))
            {
                try
                {
                    // Utiliza la conexión a la base de datos con Entity Framework
                    using (Modelo.EF.HotelSol_03Entities6 db = new Modelo.EF.HotelSol_03Entities6())
                    {
                        // Ruta del archivo XML en la carpeta "xml" dentro de la carpeta "Modelo"
                        string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                        string xmlFolderPath = Path.Combine(currentDirectory, "..", "Modelo", "xml");

                        // Si el directorio no existe, créalo
                        if (!Directory.Exists(xmlFolderPath))
                        {
                            Directory.CreateDirectory(xmlFolderPath);
                        }

                        if (checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf("Clientes")))
                        {
                            // Recupera los datos de la tabla Cliente
                            List<Cliente> clientes = db.Cliente.ToList();

                            // Crea un objeto para almacenar los datos que se van a serializar a XML
                            List<ClienteXmlItem> clientesXmlData = new List<ClienteXmlItem>();

                            // Convierte cada objeto Cliente a ClienteXmlItem
                            foreach (var cliente in clientes)
                            {
                                ClienteXmlItem clienteXmlItem = new ClienteXmlItem
                                {
                                    cIdCliente = cliente.cIdCliente,
                                    cNombre = cliente.cNombre,
                                    cApellido1 = cliente.cApellido1,
                                    cApellido2 = cliente.cApellido2,
                                    cEdad = cliente.cEdad,
                                    cPais = cliente.cPais,
                                    cCiudad = cliente.cCiudad,
                                    cCalle = cliente.cCalle,
                                    cZipcode = cliente.cZipcode,
                                    cCorreoElectronico = cliente.cCorreoElectronico,
                                    cTipoCliente = cliente.cTipoCliente
                                };

                                clientesXmlData.Add(clienteXmlItem);
                            }

                            // Serializa los datos a XML y escribe en el archivo
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ClienteXmlItem>));
                            using (TextWriter writer = new StreamWriter(Path.Combine(xmlFolderPath, "clientes.xml")))
                            {
                                xmlSerializer.Serialize(writer, clientesXmlData);
                            }
                        }

                        if (checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf("Habitaciones")))
                        {
                            // Recupera los datos de la tabla Habitaciones
                            List<Habitacion> habitaciones = db.Habitacion.ToList();

                            // Crea un objeto para almacenar los datos que se van a serializar a XML
                            List<HabitacionXmlItem> habitacionesXmlData = new List<HabitacionXmlItem>();

                            // Convierte cada objeto Habitacion a HabitacionXmlItem
                            foreach (var habitacion in habitaciones)
                            {
                                HabitacionXmlItem habitacionXmlItem = new HabitacionXmlItem
                                {
                                    idHabitacion = habitacion.idHabitacion,
                                    numero = habitacion.numero,
                                    tipo = habitacion.tipo,
                                    capacidad = habitacion.capacidad,
                                    precio = habitacion.precio,
                                    estado_id = habitacion.estado_id,
                                    servicio_id = habitacion.servicio_id,
                                    pension_id = habitacion.pension_id
                                };

                                habitacionesXmlData.Add(habitacionXmlItem);
                            }

                            // Serializa los datos a XML y escribe en el archivo
                            XmlSerializer habitacionXmlSerializer = new XmlSerializer(typeof(List<HabitacionXmlItem>));
                            using (TextWriter writer = new StreamWriter(Path.Combine(xmlFolderPath, "habitaciones.xml")))
                            {
                                habitacionXmlSerializer.Serialize(writer, habitacionesXmlData);
                            }
                        }

                        // Mostrar contenido del archivo XML en el DataGridView
                        if (checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf("Clientes")))
                        {
                            MostrarContenidoXML(Path.Combine(xmlFolderPath, "clientes.xml"));
                        }
                        else if (checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf("Habitaciones")))
                        {
                            MostrarContenidoXML(Path.Combine(xmlFolderPath, "habitaciones.xml"));
                        }

                        MessageBox.Show($"Datos exportados a {xmlFolderPath}");
                    }
                }
                catch (UnauthorizedAccessException uae)
                {
                    MessageBox.Show($"Error de acceso no autorizado: {uae.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La opción 'Clientes' o 'Habitaciones' no está marcada en el CheckedListBox.");
            }
        }

        private void btnExportarOdoo_Click(object sender, EventArgs e)
        {
            string pythonPath = @"C:\Users\Naguru\AppData\Local\Programs\Python\Python312\python.exe";
            string clientesScriptPath = @"C:\Users\Naguru\source\repos\HotelSOL_APP\HotelSOL_APP_versionJVE\Modelo\CargarClientesOdoo.py";
            string habitacionesScriptPath = @"C:\Users\Naguru\source\repos\HotelSOL_APP\HotelSOL_APP_versionJVE\Modelo\CargarHabitacionesOdoo.py";

            try
            {
                // Verifica si "Clientes" o "Habitaciones" está marcado en el CheckedListBox
                if (checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf("Clientes")))
                {
                    // Ejecutar script de Python con el archivo CargarClientesOdoo.py
                    Process.Start(pythonPath, clientesScriptPath);
                }
                else if (checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf("Habitaciones")))
                {
                    // Ejecutar script de Python con el archivo CargarHabitacionesOdoo.py
                    Process.Start(pythonPath, habitacionesScriptPath);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione 'Clientes' o 'Habitaciones' en el CheckedListBox.");
                }

                MessageBox.Show("Script de Python ejecutado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el script de Python: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MostrarContenidoXML(string xmlFilePath)
        {
            try
            {
                // Cargar el contenido del archivo XML en el DataGridView
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFilePath);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el contenido del archivo XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Clase auxiliar para almacenar datos de clientes que se van a serializar a XML
    [Serializable]
    public class ClienteXmlItem
    {
        public int cIdCliente { get; set; }
        public string cNombre { get; set; }
        public string cApellido1 { get; set; }
        public string cApellido2 { get; set; }
        public int? cEdad { get; set; }
        public string cPais { get; set; }
        public string cCiudad { get; set; }
        public string cCalle { get; set; }
        public string cZipcode { get; set; }
        public string cCorreoElectronico { get; set; }
        public string cTipoCliente { get; set; }
    }

    // Clase auxiliar para almacenar datos de habitaciones que se van a serializar a XML
    [Serializable]
    public class HabitacionXmlItem
    {
        public int idHabitacion { get; set; }
        public int? numero { get; set; }
        public string tipo { get; set; }
        public int? capacidad { get; set; }
        public decimal? precio { get; set; }
        public int? estado_id { get; set; }
        public int? servicio_id { get; set; }
        public int? pension_id { get; set; }
    }
}
