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
                    IsActive = true,
                    Title = RoleNames.Admin
                },
                new Role
                {
                    IsActive = true,
                    Title = RoleNames.User
                }
                );
        }
    }
}
