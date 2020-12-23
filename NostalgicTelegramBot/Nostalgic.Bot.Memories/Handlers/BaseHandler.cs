using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nostalgic.Bot.Memories.Data;

namespace Nostalgic.Bot.Memories.Handlers
{
    internal abstract class BaseHandler<TRequest, TResponse>: IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly MemoriesContext MemoriesContext;

        protected BaseHandler(MemoriesContext memoriesContext)
        {
            MemoriesContext = memoriesContext;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
