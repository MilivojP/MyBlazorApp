using MyBlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Server.Entities;

namespace MyBlazorApp.Server.Data
{
    public partial class DatabaseContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkTime> WorkTimes { get; set; }

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
                //entity.ToTable("WorkTimes");
                entity.HasIndex(e => new { e.UserId, e.Day })
                    .IsUnique();   
             });
        }
    }
}