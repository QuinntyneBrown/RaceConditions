using RaceConditions.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace RaceConditions.Api.Interfaces
{
    public interface IRaceConditionsDbContext
    {
        DbSet<Player> Players { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
