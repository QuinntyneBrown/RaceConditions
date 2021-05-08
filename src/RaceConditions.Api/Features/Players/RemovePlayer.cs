using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using RaceConditions.Api.Models;
using RaceConditions.Api.Core;
using RaceConditions.Api.Interfaces;

namespace RaceConditions.Api.Features
{
    public class RemovePlayer
    {
        public class Request : IRequest<Response>
        {
            public Guid PlayerId { get; set; }
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
                var player = await _context.Players.SingleAsync(x => x.PlayerId == request.PlayerId);

                _context.Players.Remove(player);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Player = player.ToDto()
                };
            }

        }
    }
}
