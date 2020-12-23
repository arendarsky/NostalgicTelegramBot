using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Nostalgic.Bot.Memories.Entities;
using Nostalgic.Bot.Telegram.Commands;
using Telegram.Bot.Types.ReplyMarkups;

namespace Nostalgic.Bot.Telegram.Factories
{
    internal class InlineKeyBoardFactory
    {
        public InlineKeyboardMarkup Make(IEnumerable<Memory> memories, int columns)
        {
            var buttons = memories.Select(memory =>
            {
                var command = new OpenMemory(memory.Id);
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.None,
                    NullValueHandling = NullValueHandling.Ignore
                };
                var commandJsonString = JsonConvert.SerializeObject(command, jsonSerializerSettings);
                return InlineKeyboardButton.WithCallbackData(memory.Name, commandJsonString);
            }).ToList();

            var buttonsMatrix = new List<IEnumerable<InlineKeyboardButton>>();

            var length = buttons.Count();
            var remainder = length % columns;

            for (var i = 0; i < length - remainder; i += columns)
            {
                var newLine = new List<InlineKeyboardButton>();

                for (var j = i; j < i + columns; j++)
                {
                    newLine.Add(buttons[j]);
                }

                buttonsMatrix.Add(newLine);
            }

            if (remainder <= 0)
            {
                return new InlineKeyboardMarkup(buttonsMatrix);
            }

            var line = new List<InlineKeyboardButton>();
            for (var i = 1; i <= remainder; i++)
            {
                line.Add(buttons[length - i]);
            }

            buttonsMatrix.Add(line);

            return new InlineKeyboardMarkup(buttonsMatrix);
        }
    }
}
