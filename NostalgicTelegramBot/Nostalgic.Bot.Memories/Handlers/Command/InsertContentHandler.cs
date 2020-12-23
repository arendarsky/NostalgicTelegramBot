using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nostalgic.Bot.Memories.Commands;
using Nostalgic.Bot.Memories.Data;
using Nostalgic.Bot.Memories.Entities;

namespace Nostalgic.Bot.Memories.Handlers.Command
{
    internal class DescriptionUpdateHandler: BaseHandler<InsertContent, Unit>
    {
        public DescriptionUpdateHandler(MemoriesContext memoriesContext) : base(memoriesContext)
        {
        }

        public override Task<Unit> Handle(InsertContent request, CancellationToken cancellationToken)
        {
            var content = request.Content;
            content.MemoryId = request.MemoryId;
            MemoriesContext.Contents.Add(content);
            MemoriesContext.SaveChanges();
            return Task.FromResult(Unit.Value);
        }
    }
}
