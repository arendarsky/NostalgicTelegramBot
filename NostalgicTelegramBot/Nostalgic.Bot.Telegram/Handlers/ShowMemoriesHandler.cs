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

namespace Nostalgic.Bot.Telegram.Handlers
{
    internal class ShowMemoriesHandler: BaseCommandHandler<ShowMemories>
    {
        private readonly IMemoriesComponent _memoriesComponent;
        private readonly InlineKeyBoardFactory _inlineKeyBoardFactory;
        private readonly IStateService _stateService;

        public ShowMemoriesHandler(ITelegramBotClient telegramBotClient, IMemoriesComponent memoriesComponent, InlineKeyBoardFactory inlineKeyBoardFactory, IStateService stateService) : base(telegramBotClient)
        {
            _memoriesComponent = memoriesComponent;
            _inlineKeyBoardFactory = inlineKeyBoardFactory;
            _stateService = stateService;
        }

        public override async Task<Unit> Handle(ShowMemories request, CancellationToken cancellationToken)
        {
            var chat = request.Message.Chat;
            var player = (Player) chat;
            var state = State.Default;
            state.UpdateType(MemoryTypes.Memory);
            _stateService.UpdateState(player, state);
            var memories = _memoriesComponent.GetAllMemories();
            var keyboard = _inlineKeyBoardFactory.Make(memories, 2);
            await  TelegramBotClient.SendTextMessageAsync(chat.Id, MessageTexts.Memories, replyMarkup: keyboard, cancellationToken: cancellationToken);
            return Unit.Value;
        }
    }
}
