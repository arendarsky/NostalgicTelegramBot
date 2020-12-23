using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nostalgic.Bot.Memories.Data;
using Nostalgic.Bot.Memories.Entities;
using Nostalgic.Bot.Memories.Queries;

namespace Nostalgic.Bot.Memories.Handlers.Query
{
    internal class GetMemoryHandler: BaseHandler<GetMemory, Memory>
    {
        public GetMemoryHandler(MemoriesContext memoriesContext) : base(memoriesContext)
        {
        }

        public override async Task<Memory> Handle(GetMemory request, CancellationToken cancellationToken)
        {
            var memory = await MemoriesContext.Memories.Include(memo => memo.Contents)
                .FirstOrDefaultAsync(request.Expression, cancellationToken);
            return memory;
        }
    }
}
