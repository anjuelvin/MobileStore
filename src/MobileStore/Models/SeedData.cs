using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Samsung Galaxy S2",
                        Description = "Flexible to use",
                        Category = "Samsung",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy S3",
                        Description = "Protective and fashionable",
                        Category = "Samsung",
                        Price = 300
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy S4",
                        Description = "protected",
                        Category = "Samsung",
                        Price = 400
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy S5",
                        Description = "Give your playing field a professional touch",
                        Category = "Samsung",
                        Price = 550
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy S6",
                        Description = "black and white",
                        Category = "Samsung",
                        Price = 795
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy S7",
                        Description = "Improve brain efficiency by 75%",
                        Category = "Samsung",
                        Price = 1600
                    },
                    new Product
                    {
                        Name = "Iphone 3s",
                        Description = "Green Covered",
                        Category = "Iphone",
                        Price = 325
                    },
                    new Product
                    {
                        Name = "Iphone 4s",
                        Description = "A fun game for the family",
                        Category = "Iphone",
                        Price = 350
                    },
                    new Product
                    {
                        Name = "Iphone 5s",
                        Description = "Gold-plated",
                        Category = "Iphone",
                        Price = 450
                    },
                     new Product
                     {
                         Name = "Iphone 6s",
                         Description = "White, A fun game for the family",
                         Category = "Iphone",
                         Price = 750
                     },
                    new Product
                    {
                        Name = "Iphone 7s",
                        Description = "Gold-plated",
                        Category = "Iphone",
                        Price = 1200
                    }
                );
                context.SaveChanges();
            }
        }
    }
}