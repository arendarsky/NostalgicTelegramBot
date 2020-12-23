using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Nostalgic.Bot.Memories.Commands;
using Nostalgic.Bot.Memories.Entities;
using Nostalgic.Bot.Memories.Enums;
using Nostalgic.Bot.Memories.Queries;

namespace Nostalgic.Bot.Memories
{
    public interface IMemoriesComponent
    {
        void AddMemory(Memory memory);
        Memory GetMemory(Expression<Func<Memory, bool>> expression);
        IEnumerable<Memory> GetAllMemories();
        IEnumerable<Memory> GetAllCompliments();
        void UpdateDescription(int memoryId, Content description);
        void ClearMemoryContent(int memoryId);
    }

    internal class MemoriesComponent : IMemoriesComponent
    {
        private readonly IMediator _mediator;
        public MemoriesComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void AddMemory(Memory memory)
        {
            var command = new InsertMemory(memory);
            _mediator.Send(command);
        }

        public Memory GetMemory(Expression<Func<Memory, bool>> expression)
        {
            var command = new GetMemory(expression);
            return _mediator.Send(command).Result;
        }

        public IEnumerable<Memory> GetAllMemories()
        {
            return _mediator.Send(new GetMemories(memory => memory.Type == MemoryTypes.Memory)).Result;
        }

        public IEnumerable<Memory> GetAllCompliments()
        {
            return _mediator.Send(new GetMemories(memory => memory.Type == MemoryTypes.Compliment)).Result;
        }

        public void UpdateDescription(int memoryId, Content description)
        {
            _mediator.Send(new InsertContent(memoryId, description));
        }

        public void ClearMemoryContent(int memoryId)
        {
            _mediator.Send(new DeleteContent(content => content.MemoryId == memoryId));
        }
    } 
}
