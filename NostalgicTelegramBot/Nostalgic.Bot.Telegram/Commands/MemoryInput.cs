using System;
using System.Collections.Generic;
using System.Text;
using Nostalgic.Bot.Memories.Enums;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Commands
{
    internal class MemoryInput: BaseMessageCommand
    {
        public MemoryInput(Message message, MemoryTypes type) : base(message)
        {
            MemoryType = type;
        }

        public MemoryTypes MemoryType { get; }
    }
}
