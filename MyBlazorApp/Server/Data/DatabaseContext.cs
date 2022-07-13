using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Server.Entities;
using MyBlazorApp.Shared.Converters;

namespace MyBlazorApp.Server.Data
{
    public partial class DatabaseContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkTime> WorkTimes { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }
        public virtual DbSet<UserVacationBudget> UserVacationsBudgets { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<SickLeave> SickLeaves { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkTime>(entity =>
            {
                entity.Property(e => e.Day)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();
                entity.Property(e => e.StartTime)
                    .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
                entity.Property(e => e.EndTime)
                    .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
                entity.Property(e => e.TotalWork)
                    .HasComputedColumnSql("DATEDIFF(MINUTE,DATEDIFF(MINUTE,EndTime,StartTime),BreakTime)+30");

                entity.HasIndex(e => new { e.UserId, e.Day })
                    .IsUnique();  
             });

            modelBuilder.Entity<Vacation>(entity=>
            {
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
            
            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.Property(e => e.HolidayDate)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });

            modelBuilder.Entity<SickLeave>(entity =>
            {
                entity.Property(e => e.StartDate)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();
                entity.Property(e => e.EndDate)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });
        }
    }
}