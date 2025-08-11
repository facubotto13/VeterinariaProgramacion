using AdmVeterinaria.Datos.Clases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AdmVeterinaria.Datos
{
    public class TodoContext : DbContext
    {
        public TodoContext()
        {
        }
        public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; } = default!;
        public DbSet<TipoAnimal> TiposAnimals { get; set; } = default!;
        public DbSet<Duenio> Duenios { get; set; } = default!;
        public DbSet<Medicamento> Medicamentos { get; set; } = default!;
        public DbSet<Atencion> Atencions { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Veterinaria;Integrated Security=True;TrustServerCertificate=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal)
                      .HasName("PK_ID_ANIMAL");

                entity.HasMany(e => e.Atenciones)
                      .WithOne(e => e.Animal)
                      .HasForeignKey("IdAnimal")
                      .IsRequired();
            });

            modelBuilder.Entity<Duenio>(entity =>
            {
                entity.HasKey(e => e.IdDuenio)
                      .HasName("PK_ID_DUENIO");

                entity.HasMany(e => e.Animales)
                      .WithOne(e => e.Duenio)
                     .HasForeignKey("IdDuenio")
                     .IsRequired(false);
            });

            modelBuilder.Entity<Atencion>(entity =>
            {
                entity.HasKey(e => e.IdAtencion)
                      .HasName("PK_ID_ATENCION");
            });

            modelBuilder.Entity<TipoAnimal>(entity =>
            {
                entity.HasKey(e => e.IdTipoAnimal)
                      .HasName("PK_ID_TIPOANIMAL");

                entity.HasMany(e => e.Animal)
                      .WithOne(a => a.TipoAnimal)
                      .HasForeignKey("IdTipoAnimal")
                      .IsRequired();
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.IdMedicamento)
                      .HasName("PK_ID_MEDICAMENTO");
            });
        }

    }
}
