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
using Nostalgic.Bot.Telegram.Models;
using Nostalgic.Bot.Telegram.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Handlers
{
    internal class ShowComplimentsHandler: BaseCommandHandler<ShowCompliments>
    {
        private readonly IStateService _stateService;
        private readonly InlineKeyBoardFactory _inlineKeyBoardFactory;
        private readonly IMemoriesComponent _memoriesComponent;

        public ShowComplimentsHandler(ITelegramBotClient telegramBotClient, IStateService stateService, InlineKeyBoardFactory inlineKeyBoardFactory, IMemoriesComponent memoriesComponent) : base(telegramBotClient)
        {
            _stateService = stateService;
            _inlineKeyBoardFactory = inlineKeyBoardFactory;
            _memoriesComponent = memoriesComponent;
        }

        public override async Task<Unit> Handle(ShowCompliments request, CancellationToken cancellationToken)
        {
            var chat = request.Message.Chat;
            var player = (Player)chat;
            var state = State.Default;
            state.UpdateType(MemoryTypes.Compliment);
            _stateService.UpdateState(player, state);
            var memories = _memoriesComponent.GetAllCompliments();
            var keyboard = _inlineKeyBoardFactory.Make(memories, 3);
            await TelegramBotClient.SendTextMessageAsync(chat.Id, MessageTexts.Compliments, replyMarkup: keyboard, cancellationToken: cancellationToken);
            return Unit.Value;
        }
    }
}
