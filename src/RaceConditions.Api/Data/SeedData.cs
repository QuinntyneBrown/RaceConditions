using RaceConditions.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RaceConditions.Api.Data
{
    public static class SeedData
    {
        public static void Seed(RaceConditionsDbContext context)
        {
            PlayerConfiguration.Seed(context);
        }

        internal static class PlayerConfiguration
        {
            internal static void Seed(RaceConditionsDbContext context)
            {
                foreach(var player in new List<Player>() {
                    new ("Michael Jordan","Scorer"),                    
                    new ("Steph Curry", "Shooter"),
                    new ("Dennis Rodman", "Rebounder"),
                    new ("Gary Payton", "Defender")
                })
                {
                    AddIfDoesntExist(player);
                }

                void AddIfDoesntExist(Player player)
                {
                    if(!context.Players.Where(x => x.Name == player.Name).Any())
                    {
                        context.Add(player);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
