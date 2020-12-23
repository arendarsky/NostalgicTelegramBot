using System;
using System.Linq;
using Nostalgic.Bot.Memories.Entities;
using Nostalgic.Bot.Memories.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Nostalgic.Bot.Telegram.Factories
{
    internal class MemoryFactory
    {
        private readonly ContentFactory _contentFactory;

        public MemoryFactory(ContentFactory contentFactory)
        {
            _contentFactory = contentFactory;
        }

        public Memory MakeMemory(Message message, MemoryTypes type)
        {
            switch (message.Type)
            {
                case MessageType.Photo:
                case MessageType.Video:
                    return new Memory(message.Caption, _contentFactory.MakeContents(message), type);
                default:
                    return null;
            }
        }
    }
}
