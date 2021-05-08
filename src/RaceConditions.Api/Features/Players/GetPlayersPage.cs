using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using RaceConditions.Api.Extensions;
using RaceConditions.Api.Core;
using RaceConditions.Api.Interfaces;
using RaceConditions.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace RaceConditions.Api.Features
{
    public class GetPlayersPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<PlayerDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IRaceConditionsDbContext _context;

            public Handler(IRaceConditionsDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from player in _context.Players
                            select player;

                var length = await _context.Players.CountAsync();

                var players = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = players
                };
            }

        }
    }
}
