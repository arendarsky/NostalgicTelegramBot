using Nostalgic.Bot.Telegram.Constants;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Commands.NamedContainers
{
    internal class ShowMemoriesContainer: BaseNamedMessageCommandContainer<ShowMemories>
    {
        public override string Name => CommandNames.Memories;
    }
}
