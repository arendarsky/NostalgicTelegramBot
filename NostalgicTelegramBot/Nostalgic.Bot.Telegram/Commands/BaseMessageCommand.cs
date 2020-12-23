using MediatR;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Commands
{
    internal abstract class BaseMessageCommand: IRequest
    {
        protected BaseMessageCommand(Message message)
        {
            Message = message;
        }
        public Message Message { get; }
    }
}
