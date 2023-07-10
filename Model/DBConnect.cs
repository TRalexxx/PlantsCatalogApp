using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantsCatalogApp.Model
{
    class DBConnect :DbContext
    {
        public DbSet<Plant> Plants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O6O2RKO;Database=Plants_db;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
