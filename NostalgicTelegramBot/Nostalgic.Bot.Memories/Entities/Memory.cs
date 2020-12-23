using System.Collections.Generic;
using Nostalgic.Bot.Memories.Enums;

namespace Nostalgic.Bot.Memories.Entities
{
    public class Memory: BaseEntity
    {
        internal Memory()
        {

        }

        public Memory(string name, IEnumerable<Content> contents, MemoryTypes type)
        {
            Name = name;
            Contents = contents;
            Type = type;
        }

        public string Name { get; internal set; }
        public IEnumerable<Content> Contents { get; internal set; }
        public MemoryTypes Type { get; internal set; }
    }
}
