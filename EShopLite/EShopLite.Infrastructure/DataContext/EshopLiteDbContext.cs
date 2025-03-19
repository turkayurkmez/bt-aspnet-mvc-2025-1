using EShopLite.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Infrastructure.DataContext
{
    public class EshopLiteDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .Property(c=>c.Name).IsRequired().HasMaxLength(150);

            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().Property(p => p.ImageUrl).HasDefaultValue("https://picsum.photos/200");
            modelBuilder.Entity<Product>().Property(p => p.Stock).HasDefaultValue(0);


            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryId)
                        .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Category>()
                        .HasData(
                            new Category { Id = 1, Name = "Elektronik" },
                            new Category { Id = 2, Name = "Giyim" },
                            new Category { Id = 3, Name = "Mobilya" }
                        );

            //product seed:

            modelBuilder.Entity<Product>().HasData(
               new Product { Id = 1, Name = "Iphone 12", Description = "Apple Iphone 12 64 GB", Price = 10000, ImageUrl = "https://picsum.photos/200", Stock = 100, CreatedDate = DateTime.Now, CategoryId = 1 },
               new Product { Id = 2, Name = "Samsung S21", Description = "Samsung", Price = 9000, ImageUrl = "https://picsum.photos/200", Stock = 100, CreatedDate = DateTime.Now, CategoryId = 1 },
               new Product { Id = 3, Name = "Tshirt", Description = "Tshirt", Price = 100, ImageUrl = "https://picsum.photos/200", Stock = 100, CreatedDate = DateTime.Now, CategoryId = 2 },
               new Product { Id = 4, Name = "Pantolon", Description = "Pantolon", Price = 200, ImageUrl = "https://picsum.photos/200", Stock = 100, CreatedDate = DateTime.Now, CategoryId = 2 },
               new Product { Id = 5, Name = "Masa", Description = "Masa", Price = 500, ImageUrl = "https://picsum.photos/200", Stock = 100, CreatedDate = DateTime.Now, CategoryId = 3 },
               new Product { Id = 6, Name = "Sandalye", Description = "Sandalye", Price = 200, ImageUrl = "https://picsum.photos/200", Stock = 100, CreatedDate = DateTime.Now, CategoryId = 3 },
               new Product { Id = 7, Name = "Laptop", Description = "Laptop", Price = 15000, ImageUrl = "https://picsum.photos/200", Stock = 50, CreatedDate = DateTime.Now, CategoryId = 1 },
               new Product { Id = 8, Name = "Tablet", Description = "Tablet", Price = 5000, ImageUrl = "https://picsum.photos/200", Stock = 70, CreatedDate = DateTime.Now, CategoryId = 1 },
               new Product { Id = 9, Name = "Kulaklık", Description = "Kulaklık", Price = 500, ImageUrl = "https://picsum.photos/200", Stock = 200, CreatedDate = DateTime.Now, CategoryId = 1 },
               new Product { Id = 10, Name = "Televizyon", Description = "Televizyon", Price = 8000, ImageUrl = "https://picsum.photos/200", Stock = 30, CreatedDate = DateTime.Now, CategoryId = 1 },
               new Product { Id = 11, Name = "Kazak", Description = "Kazak", Price = 150, ImageUrl = "https://picsum.photos/200", Stock = 100, CreatedDate = DateTime.Now, CategoryId = 2 },
               new Product { Id = 12, Name = "Mont", Description = "Mont", Price = 300, ImageUrl = "https://picsum.photos/200", Stock = 80, CreatedDate = DateTime.Now, CategoryId = 2 },
               new Product { Id = 13, Name = "Ayakkabı", Description = "Ayakkabı", Price = 250, ImageUrl = "https://picsum.photos/200", Stock = 120, CreatedDate = DateTime.Now, CategoryId = 2 },
               new Product { Id = 14, Name = "Şapka", Description = "Şapka", Price = 50, ImageUrl = "https://picsum.photos/200", Stock = 150, CreatedDate = DateTime.Now, CategoryId = 2 },
               new Product { Id = 15, Name = "Ceket", Description = "Ceket", Price = 400, ImageUrl = "https://picsum.photos/200", Stock = 60, CreatedDate = DateTime.Now, CategoryId = 2 },
               new Product { Id = 16, Name = "Elbise", Description = "Elbise", Price = 350, ImageUrl = "https://picsum.photos/200", Stock = 90, CreatedDate = DateTime.Now, CategoryId = 2 },
               new Product { Id = 17, Name = "Dolap", Description = "Dolap", Price = 2000, ImageUrl = "https://picsum.photos/200", Stock = 40, CreatedDate = DateTime.Now, CategoryId = 3 },
               new Product { Id = 18, Name = "Koltuk", Description = "Koltuk", Price = 3000, ImageUrl = "https://picsum.photos/200", Stock = 20, CreatedDate = DateTime.Now, CategoryId = 3 },
               new Product { Id = 19, Name = "Sehpa", Description = "Sehpa", Price = 400, ImageUrl = "https://picsum.photos/200", Stock = 70, CreatedDate = DateTime.Now, CategoryId = 3 },
               new Product { Id = 20, Name = "Kitaplık", Description = "Kitaplık", Price = 600, ImageUrl = "https://picsum.photos/200", Stock = 50, CreatedDate = DateTime.Now, CategoryId = 3 },
               new Product { Id = 21, Name = "Yatak", Description = "Yatak", Price = 2500, ImageUrl = "https://picsum.photos/200", Stock = 30, CreatedDate = DateTime.Now, CategoryId = 3 },
               new Product { Id = 22, Name = "Komodin", Description = "Komodin", Price = 300, ImageUrl = "https://picsum.photos/200", Stock = 60, CreatedDate = DateTime.Now, CategoryId = 3 },
               new Product { Id = 23, Name = "Lamba", Description = "Lamba", Price = 150, ImageUrl = "https://picsum.photos/200", Stock = 100, CreatedDate = DateTime.Now, CategoryId = 3 },
               new Product { Id = 24, Name = "Raf", Description = "Raf", Price = 200, ImageUrl = "https://picsum.photos/200", Stock = 80, CreatedDate = DateTime.Now, CategoryId = 3 },
               new Product { Id = 25, Name = "Baza", Description = "Baza", Price = 1000, ImageUrl = "https://picsum.photos/200", Stock = 40, CreatedDate = DateTime.Now, CategoryId = 3 },
               new Product { Id = 26, Name = "Perde", Description = "Perde", Price = 200, ImageUrl = "https://picsum.photos/200", Stock = 70, CreatedDate = DateTime.Now, CategoryId = 3 }
           );

        }

       


    }
}
