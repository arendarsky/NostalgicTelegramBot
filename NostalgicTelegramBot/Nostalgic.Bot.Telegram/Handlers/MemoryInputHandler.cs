using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nostalgic.Bot.Memories;
using Nostalgic.Bot.Telegram.Commands;
using Nostalgic.Bot.Telegram.Factories;
using Telegram.Bot;

namespace Nostalgic.Bot.Telegram.Handlers
{
    internal class MemoryInputHandler: BaseCommandHandler<MemoryInput>
    {
        private readonly IMemoriesComponent _memoriesComponent;
        private readonly MemoryFactory _memoryFactory;

        public MemoryInputHandler(ITelegramBotClient telegramBotClient, IMemoriesComponent memoriesComponent, MemoryFactory memoryFactory) : base(telegramBotClient)
        {
            _memoriesComponent = memoriesComponent;
            _memoryFactory = memoryFactory;
        }

        public override Task<Unit> Handle(MemoryInput request, CancellationToken cancellationToken)
        {
            var memory = _memoryFactory.MakeMemory(request.Message, request.MemoryType);

            if (memory != null)
            {
                _memoriesComponent.AddMemory(memory);
            }

            return Task.FromResult(Unit.Value);
        }
    }
}
