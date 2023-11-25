using Modelo.DBFR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class HotelSol_03Entities : DbContext
    {
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the relationship between Factura and Reservas
            modelBuilder.Entity<Factura>()
                .HasRequired(f => f.Reserva)
                .WithMany()
                .HasForeignKey(f => f.IdReserva_id)
                .WillCascadeOnDelete(false);  // Adjust cascade delete behavior as needed

            // ... other configurations

            base.OnModelCreating(modelBuilder);
        }
    }
}
