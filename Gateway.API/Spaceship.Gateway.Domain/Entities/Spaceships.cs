﻿using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;

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

        public Status Status { get; private set; }
        public Material BaseRankUpMaterial { get; private set; }
        public bool Idle { get; private set; }
        public DateTime? MissionEnd { get; private set; }

        public Guid UserId { get; private set; }

        public User User { get; private set; }

        public List<Mission>? Missions { get; set; }

        public void Repair ()
        {
            Status.Repair();
            Updated();
        }
        public void TakeDamage (int damage)
        {
            Status.TakeDamadge(damage);
            Updated();
        }

        public void SendOnMission()
        {
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
