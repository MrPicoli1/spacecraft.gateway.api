using Microsoft.EntityFrameworkCore;
using Spaceship.Gateway.Domain.Entities;

namespace Spaceship.Gateway.Data.Repositories
{
    public class SpaceshipMongoDBContext :DbContext
    {
      
        public SpaceshipMongoDBContext(DbContextOptions options) { 
        }

        public DbSet<Mission> Missions { get; set; }

       

    }

}
