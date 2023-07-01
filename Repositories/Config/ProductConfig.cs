using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product() { Id = 1, CategoryId = 2, ImageUrl = "/images/1.jpg", ProductName = "Computer", Price = 17000 },
                new Product() { Id = 2, CategoryId = 2, ImageUrl = "/images/2.jpg", ProductName = "Keyboard", Price = 1000 },
                new Product() { Id = 3, CategoryId = 2, ImageUrl = "/images/3.jpg", ProductName = "Mouse", Price = 500 },
                new Product() { Id = 4, CategoryId = 2, ImageUrl = "/images/4.jpg", ProductName = "Monitor", Price = 7000 },
                new Product() { Id = 5, CategoryId = 2, ImageUrl = "/images/5.jpg", ProductName = "Deck", Price = 1500 },
                new Product() { Id = 6, CategoryId = 1, ImageUrl = "/images/6.jpg", ProductName = "Tarih", Price = 750 },
                new Product() { Id = 7, CategoryId = 1, ImageUrl = "/images/7.jpg", ProductName = "Hamlet", Price = 2000 }

                );
        }
    }
}
