using BasicStandardsForRoundsAndInspectionsAPI.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BasicStandardsForRoundsAndInspectionsAPI.Models
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        public DbSet<MainStandard> MainStandards { get; set; }
        public DbSet<SubStandard> SubStandards { get; set; } 
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultType> ResultTypes { get; set; }
        public DbSet<SubStandardResult> SubStandardResults { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //modelBuilder.Entity<SubStandardResult>()
           //     .HasKey(sr => new {sr.SubStandardId, sr.ResultId});
            base.OnModelCreating(modelBuilder);

            // Ensure the IdentityUserRole primary key is defined
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            // Ensure the IdentityUserLogin primary key is defined
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            // Ensure the IdentityUserToken primary key is defined
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });
        }
    }
}
