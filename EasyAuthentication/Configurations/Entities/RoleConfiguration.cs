using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasyAuthentication.Constants;
using EasyAuthentication.Models.Entity;

namespace EasyAuthentication.Configurations.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = 1,
                    IsActive = true,
                    Title = RoleNames.Admin
                },
                new Role
                {
                    Id = 2,
                    IsActive = true,
                    Title = RoleNames.User
                }
                );
        }
    }
}
