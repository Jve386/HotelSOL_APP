using Modelo;
using Modelo.DBFR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class MainControler
    {

       
        /// <summary>
        /// Funcion que devuelve la lista de usuario y cliente, modelo UserClienteViewModel, MOSTRAR USUARIOS CLIENTES
        /// </summary>
        /// <returns>Devuelve una lista UserClienteViewModel</returns>
        public IEnumerable<UserViewModel> GetListaUsuario()
        {
            using (Modelo.DBFR.HotelSol_03Entities db = new Modelo.DBFR.HotelSol_03Entities())
            {
                var data = db.UsuarioLogin
                             .Select(u => new UserViewModel
                             {
                                Id = u.idUsuario,
                                Correo = u.uCorreo_electronico,
                                Contrasena = u.uContrasena,
                                NivelUsuario=u.nivelUsuario
                             })
                             .ToList();

                // Verificar si data está vacío
                if (data.Count == 0)
                {
                    

                    // No ejecutar el return, simplemente regresar una lista vacía
                    return new List<UserViewModel>();
                }

                return data;
            }
        }

        /// <summary>
        /// Funcion comprueba si existe el usuario devuleve usuario objeto con todas las opciones
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public UserViewModel VerificarUsuario(UserViewModel usuario)
        {
          
            //COMPROBAR USUARIO Y DECOLVER
            using (Modelo.DBFR.HotelSol_03Entities db = new Modelo.DBFR.HotelSol_03Entities())
            {
                try
                {
                    if (usuario != null && !string.IsNullOrEmpty(usuario.Correo) && !string.IsNullOrEmpty(usuario.Contrasena))
                    {
                        // Realizar una consulta para verificar si el usuario con el correo y contraseña existe
                        var usuarioDb = db.UsuarioLogin.FirstOrDefault(u => u.uCorreo_electronico == usuario.Correo);

                        if (usuarioDb != null && VerificarContraseña(usuario.Contrasena, usuarioDb.uContrasena))
                        {
                            // El usuario existe, devolver el objeto UserViewModel
                            return new UserViewModel
                            {
                                Id = usuarioDb.idUsuario,
                                Correo = usuarioDb.uCorreo_electronico,
                                NivelUsuario = (int)usuarioDb.nivelUsuario
                                // Puedes asignar otras propiedades según sea necesario
                            };
                        }
                        else
                        {
                            // El usuario no existe
                            return null;
                        }
                    }
                    else
                    {
                        // El objeto usuario, la confirmación de la contraseña, el correo o la contraseña están en blanco o no coinciden
                        return null;
                    }
                }
                catch (Exception ex)
                {
                   
                    return null;
                }
            }
            
           
        }
        private bool VerificarContraseña(string contrasenaIngresada, string contrasenaAlmacenada)
        {
            // Setea la contraseña ingresada y compara para registrar tambien hay que setarla
            String str = ConvertirSha256(contrasenaIngresada);
            return  str==contrasenaAlmacenada ;
        }
        //-----------------------------------------------FIN LOGIN
        // CONVERSION DE CONTRASEÑA PARA INGRESADA Y CODIFICA LA CONTRASEÑA, PARA COMPARAR
        public static string ConvertirSha256(string texto)
        {
            //using System.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }






    }
}
