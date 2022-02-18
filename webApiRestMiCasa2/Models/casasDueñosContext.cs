using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace webApiRestMiCasa2.Models
{
    public partial class casasDueñosContext : DbContext
    {
        public casasDueñosContext()
            : base("name=casasDueñosContext")
        {
        }

        public virtual DbSet<Casas> Casas { get; set; }
        public virtual DbSet<Dueños> Dueños { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Casas>()
                .Property(e => e.tipodeCasa)
                .IsUnicode(false);

            modelBuilder.Entity<Casas>()
                .Property(e => e.Ubicacion)
                .IsUnicode(false);

            modelBuilder.Entity<Casas>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Dueños>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Dueños>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Dueños>()
                .HasMany(e => e.Casas)
                .WithOptional(e => e.Dueños)
                .HasForeignKey(e => e.Dueño)
                .WillCascadeOnDelete();
        }
    }
}
