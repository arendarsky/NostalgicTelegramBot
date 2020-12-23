using Newtonsoft.Json;
using Nostalgic.Bot.Memories.Entities;

namespace Nostalgic.Bot.Telegram.Commands
{
    internal class CallbackData
    {
        public string Name { get; set; }
    }

    internal class CallbackData<T> : CallbackData where T : class
    {
        public T Data { get; set; }
    }
}
