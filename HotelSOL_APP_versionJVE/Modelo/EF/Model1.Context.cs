﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelSol_03Entities6 : DbContext
    {
        public HotelSol_03Entities6()
            : base("name=HotelSol_03Entities6")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<EstadoHabitacion> EstadoHabitacion { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Pension> Pension { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<ServicioHabitacion> ServicioHabitacion { get; set; }
        public virtual DbSet<UsuarioLogin> UsuarioLogin { get; set; }
    }
}
