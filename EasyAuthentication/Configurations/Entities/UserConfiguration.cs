
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyAuthentication.Enums;
using EasyAuthentication.Models.Entity;
using EasyAuthentication.Tools;

namespace EasyAuthentication.Configurations.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var key = 10.GenerateSalt();
            builder.HasData(
                new User
                {
                    Id = Guid.Parse("05446344-f9cc-4566-bd2c-36791b4e28ed"),
                    MobileNumber = "912",
                    ActiveCode = "12345",
                    DateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now,
                    UserType = (int)UserType.Real,
                    Key = key,
                    Password = "1234".EncodePassword(key),
                    Email = "admin@admin.com"
                }
            );
        }
    }
}
