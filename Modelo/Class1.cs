using Modelo.DBFR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
   

    //Modelo de datos para cliente
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Edad { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public string Zipcode { get; set; }
        public string TipoCliente { get; set; }
        public string CorreoElectronico { get; set; }
    } 
    //Modelo de datos solo el usuario login
    public class UserViewModel
        {
            public int Id { get; set; }
            public string Correo { get; set; }
            public string Contrasena { get; set; }
            public Nullable<int> NivelUsuario { get; set; }
             public string ConfirmarContrasena { get; set; }
        // Propiedad adicional para la validación de confirmación de contraseña
        public bool ConfirmacionContrasena
        {
            get
            {
                // Verificar si la contraseña y la confirmación coinciden
                return Contrasena == ConfirmarContrasena;
            }
        }
        /*public int IdCliente { get; set; }
        public ClienteViewModel oCliente { get; set; }*/
    }

    public class UserClienteViewModel
    {
        public UserViewModel Usuario { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }





}
