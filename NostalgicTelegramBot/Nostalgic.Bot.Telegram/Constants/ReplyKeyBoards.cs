using Telegram.Bot.Types.ReplyMarkups;

namespace Nostalgic.Bot.Telegram.Constants
{
    internal class ReplyKeyBoards
    {
        public static readonly ReplyKeyboardMarkup MainMenu = new ReplyKeyboardMarkup(new[]
        {
            new[]
            {
                new KeyboardButton
                {
                    Text = CommandNames.Memories
                }
            }
        });
    }
}
