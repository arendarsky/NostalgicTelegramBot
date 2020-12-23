using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Commands
{
    internal class ShowCompliments: BaseMessageCommand
    {
        public ShowCompliments(Message message) : base(message)
        {
        }
    }
}
