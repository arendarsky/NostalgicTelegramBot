using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;
using Nostalgic.Bot.Memories;
using Nostalgic.Bot.Memories.Enums;
using Nostalgic.Bot.Telegram.Commands;
using Nostalgic.Bot.Telegram.Factories;
using Nostalgic.Bot.Telegram.Models;
using Nostalgic.Bot.Telegram.Services;
using Nostalgic.Bot.Telegram.Settings;
using Telegram.Bot;

namespace Nostalgic.Bot.Telegram.Handlers
{
    internal class ContentInputHandler: BaseCommandHandler<ContentInput>
    {
        private readonly IStateService _stateService;
        private readonly IMediator _mediator;
        private readonly TelegramBotSettings _settings;

        public ContentInputHandler(ITelegramBotClient telegramBotClient, IStateService stateService, IMediator mediator, IOptions<TelegramBotSettings> settingsOptions) : base(telegramBotClient)
        {
            _stateService = stateService;
            _mediator = mediator;
            _settings = settingsOptions.Value;
        }

        public override Task<Unit> Handle(ContentInput request, CancellationToken cancellationToken)
        {
            var chat = request.Message.Chat;

            if (chat.Id != _settings.AdminChatId)
            {
                return Task.FromResult(Unit.Value);
            }

            var player = (Player)chat;
            var state = _stateService.GetState(player);

            if (state.Memory == null)
            {
                switch (state.Type)
                {
                    case MemoryTypes.Memory:
                    case MemoryTypes.Compliment:
                        _mediator.Send(new MemoryInput(request.Message, state.Type.Value), cancellationToken);
                        return Task.FromResult(Unit.Value);
                    case null:
                        return Task.FromResult(Unit.Value);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _mediator.Send(new DescriptionInput(request.Message, state.Memory), cancellationToken);
            return Task.FromResult(Unit.Value);
        }
    }
}
