/*using System.Linq;

namespace Controladores
{
    internal class controlAccesoUsuario
    {
        private Modelos. dbContext;

        public controlAccesoUsuario(Modelos.HotelSolContext context)
        {
            dbContext = context;
        }

        public bool ValidarUsuario(string usuario, string contraseña)
        {
            // Consultar la base de datos para validar el usuario y contraseña
            return dbContext.Usuarios.Any(u => u.CorreoElectronico == usuario && u.Contraseña == contraseña);
        }
    }
}*/






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class controlAccesoUsuario
    {
        public bool ValidarUsuario(string usuario, string contraseña)
        {
            // Aquí deberías interactuar con la capa de modelos
            // para validar el usuario contra la base de datos o algún otro almacén de datos.

            // Por ahora, hagamos una validación simple.
            return usuario == "usuarioEjemplo" && contraseña == "contraseñaEjemplo";
        }
    }
}
