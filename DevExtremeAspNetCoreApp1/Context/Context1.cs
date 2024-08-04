using DevExtremeAspNetCoreApp1.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevExtremeAspNetCoreApp1.Context
{
    public class Context1 : DbContext
    {
        public DbSet<Tanim> tanimlar { get; set; }
        public DbSet<Kisi> kisiler { get; set; }
        public DbSet<PersonelGorev> personelGorevler { get; set; }
        public DbSet<Karar> kararlar { get; set; }
        public DbSet<FilePath> filePaths{ get; set; }
        public DbSet<Birim> birim { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 @"Server=ANIL\SQLEXPRESS;Database=Karar;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Birim>().HasKey(e=>e.YoksisId);
            
        }
    }
}
