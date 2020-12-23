using Nostalgic.Bot.Memories.Enums;

namespace Nostalgic.Bot.Memories.Entities
{
    public class Content: BaseEntity
    {
        internal Content()
        {

        }

        public Content(string essence, ContentTypes type)
        {
            Essence = essence;
            Type = type;
        }

        public string Essence { get; internal set; }
        public ContentTypes Type { get; internal set; }
        public int MemoryId { get; internal set; }
    }
}
