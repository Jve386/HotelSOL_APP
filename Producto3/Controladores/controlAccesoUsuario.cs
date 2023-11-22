using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    internal class controlAccesoUsuario
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
