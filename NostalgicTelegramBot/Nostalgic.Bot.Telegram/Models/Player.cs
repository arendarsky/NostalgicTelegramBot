using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Models
{
    internal class Player
    {
        private readonly long _chatId;

        private Player(long chatId)
        {
            _chatId = chatId;
        }

        public string GetHash()
        {
            return _chatId.ToString();
        }

        public static explicit operator Player(Chat chat)
        {
            return new Player(chat.Id);
        }
    }
}
