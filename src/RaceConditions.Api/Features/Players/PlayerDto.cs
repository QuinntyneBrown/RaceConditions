using System;

namespace RaceConditions.Api.Features
{
    public class PlayerDto
    {
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
