using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Nostalgic.Bot.Telegram.Commands;
using Nostalgic.Bot.Telegram.Commands.NamedContainers;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Nostalgic.Bot.Telegram.Factories
{
    internal class CommandFactory
    {
        private readonly ContentFactory _contentFactory;
        private readonly IEnumerable<BaseNamedMessageCommandContainer> _namedMessageCommandContainers;

        public CommandFactory(ContentFactory contentFactory)
        {
            _contentFactory = contentFactory;
            _namedMessageCommandContainers = new BaseNamedMessageCommandContainer[]
                {new StartCommandContainer(), new ShowMemoriesContainer(), new ShowComplimentsContainer()};
        }

        public BaseMessageCommand MakeCommand(Message message)
        {
            switch (message.Type)
            {
                case MessageType.Audio:
                case MessageType.Video:
                case MessageType.Photo:
                    return new ContentInput(message);
                case MessageType.Text:
                    var namedContainer = GetNamedMessageCommandContainer(message);
                    return namedContainer == null ? new ContentInput(message) : namedContainer.GetCommand(message);
                default:
                    return null;
            }
        }

        private BaseNamedMessageCommandContainer GetNamedMessageCommandContainer(Message message)
        {
            return _namedMessageCommandContainers.FirstOrDefault(container =>
                string.Equals(container.Name, message.Text, StringComparison.Ordinal));
        }

        private BaseNamedMessageCommandContainer GetNamedCallBackCommandContainer(Message message)
        {
            return _namedMessageCommandContainers.FirstOrDefault(container =>
                string.Equals(container.Name, message.Text, StringComparison.Ordinal));
        }
    }
}
