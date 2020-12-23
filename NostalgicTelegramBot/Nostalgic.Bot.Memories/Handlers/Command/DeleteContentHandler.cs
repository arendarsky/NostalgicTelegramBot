using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using MediatR;
using Nostalgic.Bot.Memories.Commands;
using Nostalgic.Bot.Memories.Data;

namespace Nostalgic.Bot.Memories.Handlers.Command
{
    internal class DeleteContentHandler: BaseHandler<DeleteContent, Unit>
    {
        public DeleteContentHandler(MemoriesContext memoriesContext) : base(memoriesContext)
        {
        }

        public override async Task<Unit> Handle(DeleteContent request, CancellationToken cancellationToken)
        {
            await MemoriesContext.Contents.Where(request.Expression).BatchDeleteAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
