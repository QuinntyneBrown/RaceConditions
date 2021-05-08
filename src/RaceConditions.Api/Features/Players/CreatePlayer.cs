using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using RaceConditions.Api.Models;
using RaceConditions.Api.Core;
using RaceConditions.Api.Interfaces;

namespace RaceConditions.Api.Features
{
    public class CreatePlayer
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Player).NotNull();
                RuleFor(request => request.Player).SetValidator(new PlayerValidator());
            }
        }

        public class Request : IRequest<Response>
        {
            public PlayerDto Player { get; set; }
        }

        public class Response : ResponseBase
        {
            public PlayerDto Player { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRaceConditionsDbContext _context;

            public Handler(IRaceConditionsDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var player = new Player(request.Player.Name, request.Player.Description);

                _context.Players.Add(player);

                await _context.SaveChangesAsync(cancellationToken);

                return new ()
                {
                    Player = player.ToDto()
                };
            }
        }
    }
}
