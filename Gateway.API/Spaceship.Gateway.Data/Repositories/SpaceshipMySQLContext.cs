using Microsoft.EntityFrameworkCore;
using Spaceship.Gateway.Domain.Entities;

namespace Spaceship.Gateway.Data.Repositories
{
    public class SpaceshipMySQLContext : DbContext
    {
        public SpaceshipMySQLContext(DbContextOptions<SpaceshipMySQLContext> options): base(options) 
        {
        }
        
        public DbSet<Spaceships> Spaceships { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
