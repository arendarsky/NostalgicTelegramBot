using System;
using System.Collections.Generic;
using System.Text;
using Nostalgic.Bot.Telegram.Constants;

namespace Nostalgic.Bot.Telegram.Commands.NamedContainers
{
    internal class ShowComplimentsContainer: BaseNamedMessageCommandContainer<ShowCompliments>
    {
        public override string Name => CommandNames.Songs;
    }
}
