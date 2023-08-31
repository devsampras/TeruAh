using Data.DTO;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DiarioContext : DbContext
    {
        public DbSet<Gruppo> Gruppi { get; set; }
        public DbSet<Libro> Libri { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=dp_preg;user=root;password=Katana88*");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gruppo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.descrizione).IsRequired();
                entity.Property(e => e.testamento).IsRequired();
                entity.Property(e => e.colore).IsRequired();
            });


            modelBuilder.Entity<Libro>(entity =>
                {
                    entity.HasKey(e => e.id);
                    entity.Property(e => e.titolo).IsRequired();
                    entity.Property(e => e.sigla).IsRequired();
                    entity.Property(e => e.gruppo).IsRequired();
                });
        }
    }
}