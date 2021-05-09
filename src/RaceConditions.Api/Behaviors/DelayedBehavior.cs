using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RaceConditions.Api.Behaviors
{
    public class DelayedBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await Task.Delay(new Random().Next(0, 3) * 1000);

            return await next();
        }
    }
}
