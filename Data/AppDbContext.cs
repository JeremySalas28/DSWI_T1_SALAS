using Microsoft.EntityFrameworkCore;
using DSW1_T1_SALAS_JEREMY.Models;

namespace DSW1_T1_SALAS_JEREMY.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<NivelAcademico> NivelesAcademicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar relación entre Curso y NivelAcademico
            modelBuilder.Entity<Curso>()
                .HasOne(c => c.NivelAcademico)
                .WithMany(n => n.Cursos)
                .HasForeignKey(c => c.NivelAcademicoId);
        }
    }
}