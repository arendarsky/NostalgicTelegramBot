using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nostalgic.Bot.Telegram;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Nostalgic.Bot.Client.Controllers
{
    [ApiController]
    [Route("[controller]ksdhnd21sd")]
    public class MessageController : ControllerBase
    {
        private readonly ITelegramComponent _telegramComponent;

        public MessageController(ITelegramComponent telegramComponent)
        {
            _telegramComponent = telegramComponent;
        }

        [Route("updatekjjwnjji1213dk")]
        [HttpPost]
        public async Task Update([FromBody]Update update)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    await _telegramComponent.HandleMessageAsync(update.Message);
                    break;
                case UpdateType.CallbackQuery:
                    await _telegramComponent.HandleCallbackQueryAsync(update.CallbackQuery);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
