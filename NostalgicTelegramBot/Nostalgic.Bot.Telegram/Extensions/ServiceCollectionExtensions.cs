using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nostalgic.Bot.Telegram.Factories;
using Nostalgic.Bot.Telegram.Services;
using Telegram.Bot;

namespace Nostalgic.Bot.Telegram.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTelegramComponent(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<CommandFactory>();
            serviceCollection.AddSingleton<ContentFactory>();
            serviceCollection.AddSingleton<MemoryFactory>();
            serviceCollection.AddSingleton<InlineKeyBoardFactory>();
            serviceCollection.AddMediatR(typeof(TelegramComponent));
            serviceCollection.AddSingleton<IStateService, StateService>();
            serviceCollection.AddScoped<IContentSendingService, ContentSendingService>();
            serviceCollection.AddScoped<ITelegramComponent, TelegramComponent>();
        }
    }
}
