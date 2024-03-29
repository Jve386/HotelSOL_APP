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
    
    public partial class Habitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habitacion()
        {
            this.Reserva = new HashSet<Reserva>();
        }
    
        public int idHabitacion { get; set; }
        public int numero { get; set; }
        public string tipo { get; set; }
        public Nullable<int> capacidad { get; set; }
        public Nullable<decimal> precio { get; set; }
        public Nullable<int> estado_id { get; set; }
        public Nullable<int> servicio_id { get; set; }
        public Nullable<int> pension_id { get; set; }
    
        public virtual EstadoHabitacion EstadoHabitacion { get; set; }
        public virtual Pension Pension { get; set; }
        public virtual ServicioHabitacion ServicioHabitacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
