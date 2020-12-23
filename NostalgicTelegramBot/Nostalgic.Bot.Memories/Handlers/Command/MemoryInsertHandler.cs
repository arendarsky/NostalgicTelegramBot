using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nostalgic.Bot.Memories.Commands;
using Nostalgic.Bot.Memories.Data;

namespace Nostalgic.Bot.Memories.Handlers.Command
{
    internal class MemoryInsertHandler: BaseHandler<InsertMemory, Unit>
    {
        public MemoryInsertHandler(MemoriesContext memoriesContext) : base(memoriesContext)
        {
        }

        public override Task<Unit> Handle(InsertMemory request, CancellationToken cancellationToken)
        {
            MemoriesContext.Memories.Add(request.Memory);
            MemoriesContext.SaveChanges();
            return Task.FromResult(Unit.Value);
        }
    }
}
