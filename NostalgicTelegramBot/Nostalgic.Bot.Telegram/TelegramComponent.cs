using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using Nostalgic.Bot.Telegram.Commands;
using Nostalgic.Bot.Telegram.Factories;
using Nostalgic.Bot.Telegram.Settings;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram
{
    public interface ITelegramComponent
    {
        Task SetWebHookAsync(string webHook);
        Task HandleMessageAsync(Message message);
        Task HandleCallbackQueryAsync(CallbackQuery callbackQuery);
    }

    internal class TelegramComponent: ITelegramComponent
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IMediator _mediator;
        private readonly CommandFactory _commandFactory;

        public TelegramComponent(ITelegramBotClient telegramBotClient, IMediator mediator, CommandFactory commandFactory)
        {
            _telegramBotClient = telegramBotClient;
            _mediator = mediator;
            _commandFactory = commandFactory;
        }

        public async Task SetWebHookAsync(string webHook)
        {
            await _telegramBotClient.SetWebhookAsync(webHook);
        }

        public async Task HandleMessageAsync(Message message)
        {
            var command = _commandFactory.MakeCommand(message);

            if (command == null)
            {
                return;
            }

            await _mediator.Send(command);
        }

        public async Task HandleCallbackQueryAsync(CallbackQuery callbackQuery)
        {
            var stringCallbackData = callbackQuery.Data;
            var command = JsonConvert.DeserializeObject<OpenMemory>(stringCallbackData);
            command.SetCallbackQuery(callbackQuery);

            await _mediator.Send(command);
        }

        private static CallbackData GetCallbackData(string data)
        {
            return JsonConvert.DeserializeObject<CallbackData>(data);
        }

        private BaseCallbackCommand GetCallbackCommand(CallbackData data)
        {
            return null;
        } 
    }
}
