using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nostalgic.Bot.Memories.Data;

namespace Nostalgic.Bot.Memories.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMemoriesComponent(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MemoriesContext>();
            serviceCollection.AddMediatR(typeof(MemoriesComponent));
            serviceCollection.AddScoped<IMemoriesComponent, MemoriesComponent>();
        }
    }
}
