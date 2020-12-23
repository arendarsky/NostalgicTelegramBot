using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nostalgic.Bot.Memories.Entities;
using Nostalgic.Bot.Memories.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Nostalgic.Bot.Telegram.Services
{
    internal interface IContentSendingService
    {
        Task<IEnumerable<Message>> SendContents(long chatId, IEnumerable<Content> contents, CancellationToken cancellationToken = default);
        Task<Message> SendContent(long chatId, Content content, CancellationToken cancellationToken = default);
    }

    internal class ContentSendingService: IContentSendingService
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public ContentSendingService(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        public async Task<IEnumerable<Message>> SendContents(long chatId, IEnumerable<Content> contents, CancellationToken cancellationToken = default)
        {
            var messages = new List<Message>();
            var mediaContent = new List<Content>();

            foreach (var content in contents)
            {
                if (content.Type == ContentTypes.Photo || content.Type == ContentTypes.Video)
                {
                    mediaContent.Add(content);
                    continue;
                }

                messages.Add(await SendContent(chatId, content, cancellationToken));
            }

            if (mediaContent.Any())
            {
                messages.AddRange(await _telegramBotClient.SendMediaGroupAsync(
                    mediaContent.Select(CreateInputMedia).Where(media => media != null), chatId,
                    cancellationToken: cancellationToken));
            }

            return messages;
        }

        private static IAlbumInputMedia CreateInputMedia(Content content)
        {
            return content.Type switch
            {
                ContentTypes.Photo => new InputMediaPhoto(new InputMedia(content.Essence)),
                ContentTypes.Video => new InputMediaVideo(new InputMedia(content.Essence)),
                _ => null
            };
        }

        public async Task<Message> SendContent(long chatId, Content content, CancellationToken cancellationToken = default)
        {
            switch (content.Type)
            {
                case ContentTypes.Audio:
                    return await _telegramBotClient.SendAudioAsync(chatId, content.Essence, cancellationToken: cancellationToken);
                case ContentTypes.Photo:
                    return await _telegramBotClient.SendPhotoAsync(chatId, content.Essence, cancellationToken: cancellationToken);
                
                case ContentTypes.Video:
                    return await _telegramBotClient.SendVideoAsync(chatId, content.Essence, cancellationToken: cancellationToken);
                case ContentTypes.Text:
                    return await _telegramBotClient.SendTextMessageAsync(chatId, content.Essence, cancellationToken: cancellationToken);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
