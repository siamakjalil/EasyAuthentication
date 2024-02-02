using EasyAuthentication.Models.Entity;
using EasyAuthentication.Models.Entity.Common;
using Microsoft.EntityFrameworkCore;

namespace EasyAuthentication.Configurations
{
    public class SampleDbContext : DbContext
    {
        //public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        //    : base(options)
        //{ 
        //}
        public SampleDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInRole> UserInRoles { get; set; }
        public virtual DbSet<UserSession> UserSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(SampleDbContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseIdentity>())
            {
                entry.Entity.UpdateDateTime = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.IsActive = true;
                    entry.Entity.DateTime = DateTime.Now;
                }
            }


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseIdentity>())
            {
                entry.Entity.UpdateDateTime = DateTime.Now;

                if (entry.State != EntityState.Added) continue;
                entry.Entity.IsActive = true;
                entry.Entity.DateTime = DateTime.Now;
            }
            return base.SaveChanges();
        }
    }
}
