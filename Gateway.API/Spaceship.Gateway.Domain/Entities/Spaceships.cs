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
                         bool idle,
                         Guid userId,
                         User user,
                         Material baseRankUpMaterial)
        {
            Idle = idle;
            UserId = userId;
            User = user;
            Status = status;
            BaseRankUpMaterial = baseRankUpMaterial;
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
            //if (Status.Rank == 5)
            //    AddNotification(Status.Rank.ToString() ,"O Rank ja esta bo maximo");
            //else
            //{
            //    Status.RankUp();
            //}
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



    }
}
