using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Core.Entities.User;
using Sat.Recruitment.Infrastructure.Data;
using System;
using System.Linq;

namespace Sat.Recruitment.Api
{
    public static class SeedData
    {
        public static readonly UserEntity User1 = new()
        {
            Id = 1,
            Name = "Juan",
            Email = "Juan@marmol.com",
            Address = "Peru 2464",
            Phone = "+5491154762312",
            UserType = "Normal",
            Money = Convert.ToDecimal("1234")
        };
        public static readonly UserEntity User2 = new()
        {
            Id = 2,
            Name = "Franco",
            Email = "Franco.Perez@gmail.com",
            Address = "Alvear y Colombres",
            Phone = "+534645213542",
            UserType = "Premium",
            Money = Convert.ToDecimal("112234")
        };
        public static readonly UserEntity User3 = new()
        {
            Id = 3,
            Name = "Agustina",
            Email = "Agustina@gmail.com",
            Address = "Garay y Otra Calle",
            Phone = "+534645213542",
            UserType = "SuperUser",
            Money = Convert.ToDecimal("112234")
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var dbContext = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
            if (dbContext.Users.Any())
            {
                return;
            }

            PopulateTestData(dbContext);
        }

        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Users)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            dbContext.Users.Add(User1);
            dbContext.Users.Add(User2);
            dbContext.Users.Add(User3);

            dbContext.SaveChanges();
        }
    }
}