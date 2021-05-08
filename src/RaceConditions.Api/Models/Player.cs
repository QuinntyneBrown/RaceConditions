using System;

namespace RaceConditions.Api.Models
{
    public class Player
    {
        public Guid PlayerId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        public Player(string name, string description)
        {
            Name = name;
            Description = description;
        }

        private Player()
        {

        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }
    }
}
