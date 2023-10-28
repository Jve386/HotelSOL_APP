using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOC_Conexion_ERP_XML
{
    public class Usuario
    {
        [Key] // This specifies that id_usuario is the primary key.
        public int id_usuario { get; set; }

        [Required]
        public string nombre_usuario { get; set; }

        [Required]
        public string apellido1_usuario { get; set; }

        public string apellido2_usuario { get; set; }

        [Required]
        public DateTime fecha_alta_usuario { get; set; }

        [Required]
        public DateTime fecha_baja_usuario { get; set; }

        [Required]
        public DateTime fecha_ultima_conexion_usuario { get; set; }

        [Required]
        public int permisos_usuario { get; set; }
    }
}
