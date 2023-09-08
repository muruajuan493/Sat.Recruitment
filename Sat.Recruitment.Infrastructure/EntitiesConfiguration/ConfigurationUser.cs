using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sat.Recruitment.Core.Entities.User;

namespace Sat.Recruitment.Infrastructure.EntitiesConfiguration
{
    internal class ConfigurationUser : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            //builder.HasData(
            //    new UserEntity
            //    {
            //        Id = 1,
            //        Name = "Juan",
            //        Email = "Juan@marmol.com",
            //        Address = "Peru 2464",
            //        Phone = "+5491154762312",
            //        UserType = "Normal",
            //        Money = "1234"
            //    },
            //    new UserEntity
            //    {
            //        Id = 2,
            //        Name = "Franco",
            //        Email = "Franco.Perez@gmail.com",
            //        Address = "Alvear y Colombres",
            //        Phone = "+534645213542",
            //        UserType = "Premium",
            //        Money = "112234"
            //    },
            //    new UserEntity
            //    {
            //        Id = 3,
            //        Name = "Agustina",
            //        Email = "Agustina@gmail.com",
            //        Address = "Garay y Otra Calle",
            //        Phone = "+534645213542",
            //        UserType = "SuperUser",
            //        Money = "112234"
            //    }
            //);
        }
    }
}
