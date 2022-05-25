using MyBlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace MyBlazorApp.Server.Models
{
    public partial class DatabaseContext : DbContext
    {
         public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get ; set ; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
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
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<WorkTime> WorkTimes { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.ToTable("userdetails");
        //        entity.Property(e => e.Id).HasColumnName("Userid");
        //        entity.Property(e => e.UserName)
        //            .HasMaxLength(100)
        //            .IsUnicode(false);
        //        entity.Property(e => e.Email)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);
        //    });
        //    OnModelCreatingPartial(modelBuilder);
        //}

    }
}