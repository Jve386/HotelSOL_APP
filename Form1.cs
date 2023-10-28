using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;

namespace UOC_Conexion_ERP_XML;

public partial class Form1 : Form
{

    private DbContextOptions<Conexion> options;

    public Form1()
    {
        InitializeComponent();

        string connectionString = "Data Source=ROGER\\SQLSERVER_ERP;Initial Catalog=HotelSOL;Integrated Security=True;Encrypt=False;";

        // Configure DbContextOptions with your connection string
        var optionsBuilder = new DbContextOptionsBuilder<Conexion>();
        optionsBuilder.UseSqlServer(connectionString);

        // Assign the options to the class-level variable
        options = optionsBuilder.Options;
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void InsertDataButton_Click(object sender, EventArgs e)
    {
        // Impedir entrar datos si un textbox esta vacio.
        if (string.IsNullOrWhiteSpace(TxbNombre.Text) ||
            string.IsNullOrWhiteSpace(TxbApellido.Text) ||
            string.IsNullOrWhiteSpace(TxbApellido2.Text))
        {
            MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return; // sale de la funcion.
        }

        
        /* SE UTILIZA UNA UNICA VARIABLE PARA EL CONEXION STRING MAS ARRIBA
        // Conexion string. 
        string connectionString = connectionString;  // = "Data Source=ROGER\\SQLSERVER_ERP;Initial Catalog=HotelSOL;Integrated Security=True;Encrypt=False;";

        // Crear DbContextOptions con la cadena de conexion.
        var options = new DbContextOptionsBuilder<Conexion>()
            .UseSqlServer(connectionString)
            .Options;
       */
        // Conectamos a la BBDD.
        using (var dbContext = new Conexion(options))
        {
            // obtenemos la data para las variables de la textbox

            var usuario = new Usuario
            {
                nombre_usuario = TxbNombre.Text,
                apellido1_usuario = TxbApellido.Text,
                apellido2_usuario = TxbApellido2.Text,
                fecha_alta_usuario = DateTime.Now,       // de momento para la fecha usamos el DateTime.now, se puede configurar mas adelante
                fecha_baja_usuario = DateTime.Now,         // se tiene que poner para que admita NULL
                fecha_ultima_conexion_usuario = DateTime.Now

            };

            if (int.TryParse(TxbPermisos.Text, out int permiso))
            {
                // 'permiso' now contains the integer value, so you can set 'permisos_usuario'.
                usuario.permisos_usuario = permiso;
            }
            else
            {
                MessageBox.Show("Porfavor entre un numero entero para 'Permisos'.");
                // Optionally clear the text box to allow the user to try again.
                TxbPermisos.Text = string.Empty;
            }

            dbContext.Usuarios.Add(usuario);
            dbContext.SaveChanges();

            MessageBox.Show("Data insertada correctamente.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the textboxes if needed.
            TxbNombre.Text = string.Empty;
            TxbApellido.Text = string.Empty;
            TxbApellido2.Text = string.Empty;
        }
    }

    private void BtnCreateXML_Click(object sender, EventArgs e)
    {
        // Leemos los textboxes
        string nombre = TxbNombre.Text;
        string apellido1 = TxbApellido.Text;
        string apellido2 = TxbApellido2.Text;
        DateTime fecha_alta_usuario = DateTime.Now;
        DateTime fecha_baja_usuario = DateTime.Now;
        DateTime fecha_ultima_conexion_usuario = DateTime.Now;

        // Creamos objeto usuario
        Usuario currentUser = new Usuario();

        // Assignamos los valores de las variables
        currentUser.nombre_usuario = nombre;
        currentUser.apellido1_usuario = apellido1;
        currentUser.apellido2_usuario = apellido2;
        currentUser.fecha_alta_usuario = fecha_alta_usuario;
        currentUser.fecha_baja_usuario = fecha_baja_usuario;
        currentUser.fecha_ultima_conexion_usuario = fecha_ultima_conexion_usuario;

        // Llamamos al metodo GenerateXmlDocument con el objeto currentUser
        XmlDocument xmlDocument = GenerateXmlDocument(currentUser);

        // path para guardar el xml, de momento estatica posible variable futura
        string filePath = @"C:\temp\user_data.xml";

        if (File.Exists(filePath))
        {
            // Carga el fichero existente
            XmlDocument existingDocument = new XmlDocument();
            existingDocument.Load(filePath);

            // Añade el nuevo usuario al fichero
            XmlNode root = existingDocument.DocumentElement;
            XmlNode userNode = xmlDocument.SelectSingleNode("/Usuarios/Usuario");
            XmlNode importedUser = existingDocument.ImportNode(userNode, true);
            root.AppendChild(importedUser);

            // guardar y salir
            existingDocument.Save(filePath);
        }
        else
        {
            // Guarda un fichero nuevo en caso de que no exista
            xmlDocument.Save(filePath);
        }

        MessageBox.Show("XML creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


    }

    private XmlDocument GenerateXmlDocument(Usuario usuario)
    {
        // Creamos el XML
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement root = xmlDoc.CreateElement("Usuarios");

        // Creamos un objeto usuario en el XML - sirve para añadir mas de un usuario por fichero
        XmlElement user = xmlDoc.CreateElement("Usuario");

        // Añadimos las propiedades del objeto usuario al texto XML
        XmlElement nombre = xmlDoc.CreateElement("nombre_usuario");
        nombre.InnerText = usuario.nombre_usuario;

        XmlElement apellido1 = xmlDoc.CreateElement("apellido1_usuario");
        apellido1.InnerText = usuario.apellido1_usuario;

        XmlElement apellido2 = xmlDoc.CreateElement("apellido2_usuario");
        apellido2.InnerText = usuario.apellido2_usuario;

        XmlElement fecha_alta_usuario = xmlDoc.CreateElement("fecha_alta_usuario");
        fecha_alta_usuario.InnerText = usuario.fecha_alta_usuario.ToString("yyyy-MM-dd HH:mm:ss");

        XmlElement fecha_baja_usuario = xmlDoc.CreateElement("fecha_baja_usuario");
        fecha_baja_usuario.InnerText = usuario.fecha_baja_usuario.ToString("yyyy-MM-dd HH:mm:ss");

        XmlElement fecha_ultima_conexion_usuario = xmlDoc.CreateElement("fecha_ultima_conexion_usuario");
        fecha_ultima_conexion_usuario.InnerText = usuario.fecha_ultima_conexion_usuario.ToString("yyyy-MM-dd HH:mm:ss");

        XmlElement permiso = xmlDoc.CreateElement("permiso");
        permiso.InnerText = usuario.permisos_usuario.ToString();


        // Añadir mas propiedades

        // Append the elements to the XML document
        user.AppendChild(nombre);
        user.AppendChild(apellido1);
        user.AppendChild(apellido2);
        user.AppendChild(fecha_alta_usuario);
        user.AppendChild(fecha_baja_usuario);
        user.AppendChild(fecha_ultima_conexion_usuario);
        user.AppendChild(permiso);

        // Append the user element to the root
        root.AppendChild(user);

        // Append the root to the XML document
        xmlDoc.AppendChild(root);

        // Devuelve el XMl
        return xmlDoc;
    }

    private void BtnSeleccionarXML_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
        openFileDialog.FilterIndex = 1;
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string selectedFilePath = openFileDialog.FileName;

            try
            {
                // Cargamos el XML para meterlo en la BBDD
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(selectedFilePath);

                // Llamamos la funcion para insertar los datos, pasandole que viene desde un xml
                bool success = InsertDataFromXML(xmlDocument);

                if (success)
                {
                    MessageBox.Show("XML insertado en la BBDD correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al insertar datos desde el fichero xml a la BBDD.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


    // Insertamos data a la BBDD es un booleano que utiliza tanto XML como ENTITY FRAMEWORK
    private bool InsertData(Usuario usuario)
    {
        string connectionString = "Data Source=ROGER\\SQLSERVER_ERP;Initial Catalog=HotelSOL;Integrated Security=True;Encrypt=False;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                string insertQuery = "INSERT INTO usuarios (nombre_usuario, apellido1_usuario, apellido2_usuario, fecha_alta_usuario, fecha_baja_usuario, fecha_ultima_conexion_usuario, permisos_usuario) " +
                                     "VALUES (@nombre, @apellido1, @apellido2, @fecha_alta, @fecha_baja, @fecha_ultima_conexion, @permiso); SELECT SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@nombre", usuario.nombre_usuario);
                    command.Parameters.AddWithValue("@apellido1", usuario.apellido1_usuario);
                    command.Parameters.AddWithValue("@apellido2", usuario.apellido2_usuario);
                    command.Parameters.AddWithValue("@fecha_alta", usuario.fecha_alta_usuario);
                    command.Parameters.AddWithValue("@fecha_baja", usuario.fecha_baja_usuario);
                    command.Parameters.AddWithValue("@fecha_ultima_conexion", usuario.fecha_ultima_conexion_usuario);
                    command.Parameters.AddWithValue("@permiso", usuario.permisos_usuario);

                    int newUserId = Convert.ToInt32(command.ExecuteScalar());

                    return newUserId > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    // Metodo para insertar data
    public bool InsertDataFromUserObject(Usuario usuario)
    {
        return InsertData(usuario);
    }


    private Usuario ParseUsuarioFromXML(XmlDocument xmlDocument)
    {
        Usuario usuario = new Usuario();

        XmlNode usuarioNode = xmlDocument.SelectSingleNode("/Usuarios/Usuario");
        if (usuarioNode != null)
        {
            usuario.nombre_usuario = GetInnerText(usuarioNode, "nombre_usuario");
            usuario.apellido1_usuario = GetInnerText(usuarioNode, "apellido1_usuario");
            usuario.apellido2_usuario = GetInnerText(usuarioNode, "apellido2_usuario");
            usuario.fecha_alta_usuario = DateTime.ParseExact(GetInnerText(usuarioNode, "fecha_alta_usuario"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            usuario.fecha_baja_usuario = DateTime.ParseExact(GetInnerText(usuarioNode, "fecha_baja_usuario"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            usuario.fecha_ultima_conexion_usuario = DateTime.ParseExact(GetInnerText(usuarioNode, "fecha_ultima_conexion_usuario"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);


            return usuario;
        }

        return null;
    }

    private string GetInnerText(XmlNode parentNode, string nodeName)
    {
        XmlNode node = parentNode.SelectSingleNode(nodeName);
        return node != null ? node.InnerText : null;
    }



    // Llama a la funcion de InsertarData desde un xml
    public bool InsertDataFromXML(XmlDocument xmlDocument)
    {
        Usuario usuario = ParseUsuarioFromXML(xmlDocument);
        if (usuario != null)
        {
            return InsertData(usuario);
        }

        return false;
    }

    private void BtnCargarUsuarios_Click(object sender, EventArgs e)
    {
        CargarUsuarios();
    }


    private void CargarUsuarios()
    {
        using (var dbContext = new Conexion(options))
        {
            List<Usuario> usuarios = dbContext.Usuarios.ToList();
            DGridUsuarios.DataSource = usuarios;
        }


    }
}
