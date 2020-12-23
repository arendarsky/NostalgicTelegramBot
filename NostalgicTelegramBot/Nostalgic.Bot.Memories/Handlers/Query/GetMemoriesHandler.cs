using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nostalgic.Bot.Memories.Data;
using Nostalgic.Bot.Memories.Entities;
using Nostalgic.Bot.Memories.Queries;

namespace Nostalgic.Bot.Memories.Handlers.Query
{
    internal class GetMemoriesHandler: BaseHandler<GetMemories, IEnumerable<Memory>>
    {
        public GetMemoriesHandler(MemoriesContext memoriesContext) : base(memoriesContext)
        {
        }

        public override Task<IEnumerable<Memory>> Handle(GetMemories request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.Expression == null
                ? MemoriesContext.Memories.Include(memo => memo.Contents)
                    .AsEnumerable()
                : MemoriesContext.Memories.Include(memo => memo.Contents)
                    .Where(request.Expression).AsEnumerable());
        }
    }
}
