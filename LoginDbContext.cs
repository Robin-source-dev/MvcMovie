using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options)
           : base(options)
        {
        }
        public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountUser>(entity =>
            {
                
                entity.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("varchar(50)");
                entity.Property(e => e.Password)
                   .IsRequired()
                   .HasMaxLength(10)
                   .HasColumnType("nchar(10)");

                entity.HasKey(e => e.Email);

                entity.ToTable("AccountUsers");

            });
        }
    }
            
}
