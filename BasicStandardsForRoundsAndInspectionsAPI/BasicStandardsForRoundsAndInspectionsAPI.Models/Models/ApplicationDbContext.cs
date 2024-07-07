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
        public DbSet<Setting> Settings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
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

            // Configure the relationships and foreign keys
            modelBuilder.Entity<SubStandard>()
                .HasOne(s => s.ResultType)
                .WithMany(rt => rt.SubStandards)
                .HasForeignKey(s => s.ResultTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.ResultType)
                .WithMany(rt => rt.Results)
                .HasForeignKey(r => r.ResultTypeId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
 