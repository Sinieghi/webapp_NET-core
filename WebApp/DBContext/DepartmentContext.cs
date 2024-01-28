using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class DepartmentContext : DbContext
    {
        public DbSet<Department> Department { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=YOURDBSERVERNAME;database=YOURDBNAME;user=YOURUSER;password=YOURPASS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
            });
        }

    }
}