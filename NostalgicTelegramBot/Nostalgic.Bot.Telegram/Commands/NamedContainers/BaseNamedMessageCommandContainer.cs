using System;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Commands.NamedContainers
{
    internal abstract class BaseNamedMessageCommandContainer
    {
        public abstract string Name { get; }
        public abstract BaseMessageCommand GetCommand(Message message);
    }

    internal abstract class BaseNamedMessageCommandContainer<T> : BaseNamedMessageCommandContainer where T: BaseMessageCommand
    {
        public override BaseMessageCommand GetCommand(Message message)
        {
            return (T) Activator.CreateInstance(typeof(T), message);
        }
    }
}
