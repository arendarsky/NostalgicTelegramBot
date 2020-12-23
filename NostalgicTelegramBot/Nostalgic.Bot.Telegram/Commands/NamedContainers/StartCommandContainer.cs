using Nostalgic.Bot.Telegram.Constants;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Commands.NamedContainers
{
    internal class StartCommandContainer: BaseNamedMessageCommandContainer<StartCommand>
    {
        public override string Name => CommandNames.Start;
    }
}
