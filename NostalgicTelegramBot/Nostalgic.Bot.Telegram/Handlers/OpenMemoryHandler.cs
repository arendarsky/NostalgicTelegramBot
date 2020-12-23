using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nostalgic.Bot.Memories;
using Nostalgic.Bot.Telegram.Commands;
using Nostalgic.Bot.Telegram.Models;
using Nostalgic.Bot.Telegram.Services;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Handlers
{
    internal class OpenMemoryHandler: BaseCommandHandler<OpenMemory>
    {
        private readonly IContentSendingService _contentSendingService;
        private readonly IMemoriesComponent _memoriesComponent;
        private readonly IStateService _stateService;

        public OpenMemoryHandler(ITelegramBotClient telegramBotClient, IContentSendingService contentSendingService, IMemoriesComponent memoriesComponent, IStateService stateService) : base(telegramBotClient)
        {
            _contentSendingService = contentSendingService;
            _memoriesComponent = memoriesComponent;
            _stateService = stateService;
        }

        public override async Task<Unit> Handle(OpenMemory request, CancellationToken cancellationToken)
        {
            var chat = request.CallbackQuery.Message.Chat;
            var memory = _memoriesComponent.GetMemory(memo => memo.Id == request.MemoryId);
            var player = (Player) chat;
            var previousState = _stateService.GetState(player);

            foreach (var messageId in previousState.SentMessagesId)
            {
                try
                {
                    await TelegramBotClient.DeleteMessageAsync(chat.Id, messageId, cancellationToken);
                }
                catch (ApiRequestException)
                {
                    break;
                }
            }

            _stateService.UpdateState(player, new State(memory));
            var messages = new List<Message>
            {
                await TelegramBotClient.SendTextMessageAsync(chat.Id, memory.Name,
                    cancellationToken: cancellationToken)
            };
            messages.AddRange(await _contentSendingService.SendContents(chat.Id, memory.Contents, cancellationToken));
            _stateService.AddSentMessagesId(player, messages.Select(message => message.MessageId));
            await TelegramBotClient.AnswerCallbackQueryAsync(request.CallbackQuery.Id, cancellationToken: cancellationToken);
            return Unit.Value;
        }
    }
}
