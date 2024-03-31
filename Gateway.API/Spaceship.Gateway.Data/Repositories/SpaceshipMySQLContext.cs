using Microsoft.EntityFrameworkCore;
using Spaceship.Gateway.Domain.Entities;

namespace Spaceship.Gateway.Data.Repositories
{
    public class SpaceshipMySQLContext : DbContext
    {
        public SpaceshipMySQLContext(DbContextOptions<SpaceshipMySQLContext> options) : base(options)
        {
        }

        public DbSet<Spaceships> Spaceships { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spaceships>().HasOne(c => c.User).WithMany(e => e.Spaceships).HasForeignKey(f => f.UserId).HasPrincipalKey(g => g.Id);

            modelBuilder.Entity<Spaceships>().HasKey(c => c.Id);
            modelBuilder.Entity<Spaceships>().OwnsOne(c => c.Status);
            modelBuilder.Entity<Spaceships>().OwnsOne(c => c.BaseRankUpMaterial);

            modelBuilder.Entity<User>().HasKey(c => c.Id);
            modelBuilder.Entity<User>().OwnsOne(c => c.Login);
            modelBuilder.Entity<User>().OwnsOne(c => c.Email);
            modelBuilder.Entity<User>().OwnsOne(c => c.Address);
            modelBuilder.Entity<User>().OwnsOne(c => c.Material);
            modelBuilder.Entity<User>().OwnsOne(c => c.Name);

        }
    }
}
