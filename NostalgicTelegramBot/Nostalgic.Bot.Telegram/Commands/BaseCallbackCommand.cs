using MediatR;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Commands
{
    internal abstract class BaseCallbackCommand : IRequest
    {
        [JsonProperty("c")]
        public CallbackQuery CallbackQuery { get; protected set; }

        public void SetCallbackQuery(CallbackQuery callbackQuery)
        {
            CallbackQuery = callbackQuery;
        }
    }
}
