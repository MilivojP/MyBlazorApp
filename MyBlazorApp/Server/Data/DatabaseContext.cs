﻿using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Server.Entities;

namespace MyBlazorApp.Server.Data
{
    public partial class DatabaseContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkTime> WorkTimes { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }
        public virtual DbSet<UserVacationBudget> UserVacationsBudget { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }

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
                    .HasComputedColumnSql("DATEDIFF(\"hour\",DATEDIFF(\"hour\",EndTime,StartTime),BreakTime)");

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
        }
    }
}