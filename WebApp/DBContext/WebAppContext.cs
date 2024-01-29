using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class WebAppContext : DbContext
    {
        public DbSet<Department> Department { get; set; }

        public DbSet<Seller> Seller { get; set; }

        public DbSet<SalesRecords> SalesRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //You can ignore this URL class if you want. Just make sure to have your connection string on UseMySQL for now, i will figure out how to use appsettings.json only.
            URL dbLink = new();
            optionsBuilder.UseMySQL(dbLink.url);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.Email);
                entity.Property(e => e.BirthDay);
                entity.Property(e => e.BaseSalary);
                entity.HasOne(e => e.Department);
            });

            modelBuilder.Entity<SalesRecords>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Status);
                entity.HasOne(e => e.Seller);
                entity.Property(e => e.Amount);
                entity.Property(e => e.Date);
            });

        }

    }
}