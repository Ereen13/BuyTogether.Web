using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BuyTogether.Core.Entities;

namespace BuyTogether.Data.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Apply migrations automatically
            await context.Database.MigrateAsync();

            // Seed Roles
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await roleManager.RoleExistsAsync("Customer"))
                await roleManager.CreateAsync(new IdentityRole("Customer"));

            // Seed Admin User
            var admin = await userManager.FindByEmailAsync("admin@buytogether.com");
            if (admin == null)
            {
                admin = new IdentityUser
                {
                    UserName = "admin@buytogether.com",
                    Email = "admin@buytogether.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            // Seed Category
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category
                {
                    Name = "Electronics"
                });

                await context.SaveChangesAsync();
            }

            // Seed Product
            if (!context.Products.Any())
            {
                context.Products.Add(new Product
                {
                    Title = "Seeded Test Product",
                    Description = "Testing seed",
                    IndividualPrice = 2000,
                    CategoryId = context.Categories.First().Id
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
