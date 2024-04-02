using Microsoft.EntityFrameworkCore;
using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Spaceship.Gateway.Domain.Entities
{
    public class Spaceships : Entity
    {
        public Spaceships(Status status,
                         Guid userId,
                         User user,
                         Material baseRankUpMaterial)
        {
            Idle = true;
            UserId = userId;
            User = user;
            Status = status;
            BaseRankUpMaterial = baseRankUpMaterial;
            IsValid();
        }

        private Spaceships() { }
        public Status Status { get; private set; }
        public Material BaseRankUpMaterial { get; private set; }
        public bool Idle { get; private set; }
        public DateTime? MissionEnd { get; private set; }
        [ForeignKey("User")]
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        [NotMapped]
        public List<Mission>? Missions { get; set; }
        [NotMapped]
        public List<string> Notifications { get; private set; }


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

        public void RankUp()
        {
            if (Status.Rank == 5)
                AddNotification(Status.Rank.ToString() ,"O Rank ja esta bo maximo");
            else
            {
                Status.RankUp();
            }
        }

        public void SendOnMission(Mission mission)
        {
            MissionEnd = mission.EndMission;
            Idle = false; 
            Updated();
        }

        public void ReturnFromMission() 
        {
            //Adicionar mais regras apos criacao da missao
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
