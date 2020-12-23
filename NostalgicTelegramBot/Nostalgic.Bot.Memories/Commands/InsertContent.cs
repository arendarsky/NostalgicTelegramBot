using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Nostalgic.Bot.Memories.Entities;

namespace Nostalgic.Bot.Memories.Commands
{
    public class InsertContent: IRequest
    {
        public InsertContent(int memoryId, Content content)
        {
            MemoryId = memoryId;
            Content = content;
        }

        public int MemoryId { get; }
        public Content Content { get; }
    }
}
