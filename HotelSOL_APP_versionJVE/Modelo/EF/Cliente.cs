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
    
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Reserva = new HashSet<Reserva>();
        }
    
        public int cIdCliente { get; set; }
        public string cNombre { get; set; }
        public string cApellido1 { get; set; }
        public string cApellido2 { get; set; }
        public Nullable<int> cEdad { get; set; }
        public string cPais { get; set; }
        public string cCiudad { get; set; }
        public string cCalle { get; set; }
        public string cZipcode { get; set; }
        public string cCorreoElectronico { get; set; }
        public string cTipoCliente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
