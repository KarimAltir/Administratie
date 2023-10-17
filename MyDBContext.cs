using Administratie.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administratie
{
    public class MyDBContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public void InitiateDatabase()
        {
            ProductCategory pc = new ProductCategory() { Name = "Technology" };
            if (!ProductCategories.Any())
            {
                ProductCategories.Add(pc);
            }
            else
            {
                pc = ProductCategories.First();
            }

            if (!Products.Any())
            {
                Product product = new Product() { Name = "Sony", Description = "Electricity", Category = pc };
                Products.Add(product);
            }
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS;"
                                        + "Database = Administatie;"
                                        + "Trusted_Connection = True;"
                                        + "MultipleActiveResultSets = true;"
                                        + "TrustServerCertificate = true");
        }
    }
}
