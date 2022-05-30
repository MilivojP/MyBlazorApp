using MyBlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Server.Entities;

namespace MyBlazorApp.Server.Data
{
    public partial class DatabaseContext : DbContext
    {
        public virtual DbSet<UserDto> Users { get; set; }
        public virtual DbSet<WorkTime> WorkTimes { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDto>(entity =>
            {
                entity.ToTable("userdetails");
                entity.Property(e => e.Id).HasColumnName("Userid");
                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkTimeDto>(entity =>
            {
                entity.ToTable("worktimedetails");
                entity.Property(e => e.UserId).HasColumnName("Userid");
                entity.Property(e => e.StartTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.EndTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.BreakTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Notes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

             });
        }
    }
}