using RaceConditions.Api.Models;

namespace RaceConditions.Api.Features
{
    public static class PlayerExtensions
    {
        public static PlayerDto ToDto(this Player player)
        {
            return new()
            {
                PlayerId = player.PlayerId,
                Name = player.Name,
                Description = player.Description
            };
        }
    }
}
