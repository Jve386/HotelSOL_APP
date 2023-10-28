using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace UOC_Conexion_ERP_XML
{
    public class Conexion : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public Conexion(DbContextOptions<Conexion> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity relationships and constraints here if needed.
        }
    }
}
