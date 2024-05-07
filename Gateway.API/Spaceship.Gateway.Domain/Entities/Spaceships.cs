using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spaceship.Gateway.Domain.Entities
{
    public class Spaceships : Entity
    {
        public Spaceships(Status status,
                         Guid? userId,
                         Material baseRankUpMaterial)
        {
           
            UserId = userId;
            Status = status;
            BaseRankUpMaterial = baseRankUpMaterial;
            IsValid();
        }

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        private Spaceships() { }
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
        public Status Status { get; private set; }
        public Material BaseRankUpMaterial { get; private set; }
        public bool Idle { get; private set; } = true;
        public DateTime? MissionEnd { get; private set; }
        [ForeignKey("User")]
        public Guid? UserId { get; private set; }
        [NotMapped]
        public List<Mission>? Missions { get; set; }
        [NotMapped]
        public List<string> Notifications { get; private set; } =new List<string>();


        public void Repair (int porcentage)
        {
            Status.Repair(porcentage);
            Updated();
        }
        public void TakeDamage (int damage)
        {
            Status.TakeDamadge(damage);
            Updated();
        }

        public Material RankUp()
        {
            if (Status.Rank == 5)
                AddNotification(Status.Rank.ToString() ,"The rank is at max");
            else
            {
                Status.RankUp();
                Updated();
                return new Material(BaseRankUpMaterial.Crystal*Status.Rank,
                    BaseRankUpMaterial.Metal * Status.Rank,
                    BaseRankUpMaterial.Currency * Status.Rank);
            }

            return null;
        }

        public void SendOnMission(Mission mission)
        {
            MissionEnd = mission.EndMission;
            Idle = false; 
            Updated();
        }

        public void ReturnFromMission() 
        {
            Idle = true; 
            Updated(); 
        }

        public void AddNotification(string key, string message)
        {
            Notifications.Add(key + " - " + message);
        }

        public void IsValid()
        {
            if (Status.Rank < 0)
                AddNotification(Status.Rank.ToString(), "The Rank can't be less than 0");
            if (Status.Rank > 5)
                AddNotification(Status.Rank.ToString(), "The rank cant be bigger than 5");
            if (Status.CurrentHP < 0)
                AddNotification(Status.CurrentHP.ToString(), "The Current HP can't be negative");
            if (Status.CurrentHP > Status.TotalHP)
                AddNotification(Status.CurrentHP.ToString(), "The Current HP can't be bigger than Total HP");
            if (BaseRankUpMaterial.Crystal <= 0)
                AddNotification(BaseRankUpMaterial.Crystal.ToString(), "The Crystal can't be less than 1");
            if(BaseRankUpMaterial.Metal <= 0)
                AddNotification(BaseRankUpMaterial.Metal.ToString(), "The Metal can't be less than 1");
            if(BaseRankUpMaterial.Currency <= 0)
                AddNotification(BaseRankUpMaterial.Currency.ToString(), "The Currency can't be less than 1");
        }



    }
}
