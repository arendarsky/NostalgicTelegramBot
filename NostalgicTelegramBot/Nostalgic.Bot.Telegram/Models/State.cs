using System.Collections.Generic;
using Nostalgic.Bot.Memories.Entities;
using Nostalgic.Bot.Memories.Enums;

namespace Nostalgic.Bot.Telegram.Models
{
    public class State
    {
        public State(Memory memory)
        {
            Memory = memory;
        }

        public Memory Memory { get; }
        public MemoryTypes? Type { get; private set; }
        public IEnumerable<int> SentMessagesId { get; private set; } = new List<int>();
        public int? MenuMessageId { get; private set; }
        public static State Default => new State(null);

        public void UpdateSentMessagesId(IEnumerable<int> sentMessagesId)
        {
            SentMessagesId = sentMessagesId;
        }

        public void UpdateMenuMessageId(int id)
        {
            MenuMessageId = id;
        }

        public void UpdateType(MemoryTypes type)
        {
            Type = type;
        }
    }
}
