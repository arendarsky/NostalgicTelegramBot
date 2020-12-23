using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nostalgic.Bot.Memories;
using Nostalgic.Bot.Memories.Enums;
using Nostalgic.Bot.Telegram.Commands;
using Nostalgic.Bot.Telegram.Constants;
using Nostalgic.Bot.Telegram.Factories;
using Telegram.Bot;

namespace Nostalgic.Bot.Telegram.Handlers
{
    internal class DescriptionInputHandler: BaseCommandHandler<DescriptionInput>
    {
        private readonly IMemoriesComponent _memoriesComponent;
        private readonly ContentFactory _contentFactory;

        public DescriptionInputHandler(ITelegramBotClient telegramBotClient, IMemoriesComponent memoriesComponent, ContentFactory contentFactory) : base(telegramBotClient)
        {
            _memoriesComponent = memoriesComponent;
            _contentFactory = contentFactory;
        }

        public override Task<Unit> Handle(DescriptionInput request, CancellationToken cancellationToken)
        {
            var content = _contentFactory.MakeContent(request.Message);

            if (content.Type == ContentTypes.Text &&
                string.Equals(content.Essence, CommandNames.ClearContent, StringComparison.Ordinal))
            {
                _memoriesComponent.ClearMemoryContent(request.Memory.Id);
                return Task.FromResult(Unit.Value);
            }

            var memory = request.Memory;
            _memoriesComponent.UpdateDescription(memory.Id, content);
            return Task.FromResult(Unit.Value);
        }
    }
}
