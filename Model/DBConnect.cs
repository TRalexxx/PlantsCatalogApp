using Microsoft.EntityFrameworkCore;

namespace PlantsCatalogApp.Model
{
    class DBConnect :DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O6O2RKO;Database=Plants_db;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
