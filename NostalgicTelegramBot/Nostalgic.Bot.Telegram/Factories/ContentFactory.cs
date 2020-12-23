using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nostalgic.Bot.Memories.Entities;
using Nostalgic.Bot.Memories.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Nostalgic.Bot.Telegram.Factories
{
    public class ContentFactory
    {
        public Content MakeContent(Message message)
        {
            return message.Type switch
            {
                MessageType.Photo => new Content(message.Photo.Last().FileId, ContentTypes.Photo),
                MessageType.Video => new Content(message.Video.FileId, ContentTypes.Video),
                MessageType.Audio => new Content(message.Audio.FileId, ContentTypes.Audio),
                MessageType.Text => new Content(message.Text, ContentTypes.Text),
                _ => null
            };
        }

        public IEnumerable<Content> MakeContents(Message message)
        {
            return new[] {MakeContent(message)};
        }
    }
}
