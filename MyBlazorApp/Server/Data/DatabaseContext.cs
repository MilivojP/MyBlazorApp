using MyBlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Server.Entities;

namespace MyBlazorApp.Server.Data
{
    public partial class DatabaseContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkTime> WorkTimes { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }
        public virtual DbSet<UserVacationBudget> UserVacationsBudget { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>(entity =>
            //{
            //    //entity.ToTable("Users");
            //    //entity.HasIndex(e => e.Email)
            //    //    .IsUnique();
            //});

            modelBuilder.Entity<WorkTime>(entity =>
            {
                entity.ToTable("WorkTimes");
                entity.Property(e => e.Id);
                entity.Property(e => e.UserId);
                entity.Property(e => e.Day)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();
                entity.Property(e => e.StartTime)
                    .HasConversion<TimeOnlyConverter, TimeOnlyComparer>()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.EndTime)
                    .HasConversion<TimeOnlyConverter, TimeOnlyComparer>()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.BreakTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Notes)
                    .HasMaxLength(50)
                    .IsUnicode(false);


                //entity.ToTable("WorkTimes");
                entity.HasIndex(e => new { e.UserId, e.Day })
                    .IsUnique();   
                
             });
            modelBuilder.Entity<Vacation>(entity=>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.UserId);
                entity.Property(e=> e.DateFrom)
                    .HasConversion<DateOnlyConverter,DateOnlyComparer>();
                entity.Property(e => e.DateTo)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });

            modelBuilder.Entity<UserVacationBudget>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.Year })
                    .IsUnique();
            });
        }
    }
}