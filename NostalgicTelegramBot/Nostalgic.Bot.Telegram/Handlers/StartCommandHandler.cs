using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nostalgic.Bot.Telegram.Commands;
using Nostalgic.Bot.Telegram.Constants;
using Nostalgic.Bot.Telegram.Models;
using Nostalgic.Bot.Telegram.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Nostalgic.Bot.Telegram.Handlers
{
    internal class StartCommandHandler: BaseCommandHandler<StartCommand>
    {
        private readonly IStateService _stateService;
        private const string MessageText = MessageTexts.Welcome;
        private readonly ReplyKeyboardMarkup _keyboard = ReplyKeyBoards.MainMenu;

        public StartCommandHandler(ITelegramBotClient telegramBotClient, IStateService stateService): base(telegramBotClient)
        {
            _stateService = stateService;
        }

        public override async Task<Unit> Handle(StartCommand request, CancellationToken cancellationToken)
        {
            var message = request.Message;

            var chat = message.Chat;
            _stateService.UpdateState((Player) chat, State.Default);
            await TelegramBotClient.SendTextMessageAsync(chat.Id, MessageText, replyMarkup: _keyboard, cancellationToken: cancellationToken);

            return Unit.Value;
        }
    }
}
