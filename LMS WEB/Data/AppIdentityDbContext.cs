using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LMS_WEB.Models.IdentityModels;

namespace LMS_Web.Data
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext()
        {

        }

        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
       : base(options)
        {
        }

        public virtual DbSet<VwRole> VwRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<VwRole>(entity =>
            {
                entity.ToView("VwRoles");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
