//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hotel
    {
        public int idHotel { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string ubicacion { get; set; }
        public Nullable<int> idUsuarioLogin { get; set; }
    
        public virtual UsuarioLogin UsuarioLogin { get; set; }
    }
}
