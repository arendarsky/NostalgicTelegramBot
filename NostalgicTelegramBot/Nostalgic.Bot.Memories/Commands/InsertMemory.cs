using MediatR;
using Nostalgic.Bot.Memories.Entities;

namespace Nostalgic.Bot.Memories.Commands
{
    internal class InsertMemory: IRequest
    {
        public InsertMemory(Memory memory)
        {
            Memory = memory;
        }

        public Memory Memory { get; }
    }
}
