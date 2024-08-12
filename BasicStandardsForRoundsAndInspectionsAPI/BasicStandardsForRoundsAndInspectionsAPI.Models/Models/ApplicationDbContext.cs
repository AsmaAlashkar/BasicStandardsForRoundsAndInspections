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
        public DbSet<ResultType> ResultTypes { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Governorate> Governorates { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
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

            modelBuilder.Entity<SubStandard>()
                .HasOne(s => s.ResultType)
                .WithMany(rt => rt.SubStandards)
                .HasForeignKey(s => s.ResultTypeId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => new { e.HospitalId, e.ReportDate, e.SubstandardId })
                  .IsUnique()
                  .HasDatabaseName("UQ_Hospital_ReportDate_SubstandardId");

                entity.Property(e => e.ReportDate).HasColumnType("datetime");
            });


            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(5);
                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 8)");
                entity.Property(e => e.Longtitude).HasColumnType("decimal(18, 8)");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.NameAr).HasMaxLength(50);

                entity.HasOne(d => d.Governorate).WithMany(p => p.Cities).HasForeignKey(d => d.GovernorateId);
            });

            modelBuilder.Entity<Governorate>(entity =>
            {
                entity.Property(e => e.Area).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Code).HasMaxLength(5);
                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 8)");
                entity.Property(e => e.Logo).HasMaxLength(50);
                entity.Property(e => e.Longtitude).HasColumnType("decimal(18, 8)");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.NameAr).HasMaxLength(50);
                entity.Property(e => e.Population).HasColumnType("decimal(18, 3)");
            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(5);
                entity.Property(e => e.Email).HasMaxLength(320);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                entity.Property(e => e.Position).HasMaxLength(100);
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(5);
                entity.Property(e => e.Email).HasMaxLength(320);
                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Longtitude).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ManagerName).HasMaxLength(50);
                entity.Property(e => e.ManagerNameAr).HasMaxLength(50);
                entity.Property(e => e.Mobile).HasMaxLength(20);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.NameAr).HasMaxLength(50);
            });

        }
    }
}
 