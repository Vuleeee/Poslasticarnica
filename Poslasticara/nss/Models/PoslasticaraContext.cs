using Microsoft.EntityFrameworkCore;

namespace nss.Models
{
    
    public class PoslasticaraContext : DbContext
    {
        public DbSet<Poslasticara> Poslasticare{get;set;}
        public DbSet<Stolovi> Stolovii{get;set;}
        public DbSet<Narudzbina> Narudzbine{get; set;}
        public PoslasticaraContext(DbContextOptions options) : base(options)
        {
            
        }
     /*   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Poslasticara>()
                .HasMany(p => p.Stolovii)
                .WithOne(s => s.Poslasticara);
            modelBuilder.Entity<Stolovi>()
                .HasOne(s => s.Narudzbina)
                .WithOne(n => n.Sto);
        }*/
    }
}