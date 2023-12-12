using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyAuthentication.Models.Entity;

namespace EasyAuthentication.Configurations.Entities
{
    public class UserInRoleConfiguration : IEntityTypeConfiguration<UserInRole>
    {
        public void Configure(EntityTypeBuilder<UserInRole> builder)
        {
            builder.HasData(new UserInRole
            {
                UserId = Guid.Parse("05446344-f9cc-4566-bd2c-36791b4e28ed"),
                RoleId = 1,
                IsActive = true,
                Id = 1,
            });
        }
    }
}
