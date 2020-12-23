using System;
using System.Collections.Generic;
using System.Text;
using Nostalgic.Bot.Memories.Entities;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Commands
{
    internal class DescriptionInput: BaseMessageCommand
    {
        public DescriptionInput(Message message, Memory memory) : base(message)
        {
            Memory = memory;
        }

        public Memory Memory { get; }
    }
}
