using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Newtonsoft.Json;
using Nostalgic.Bot.Memories.Entities;
using Nostalgic.Bot.Telegram.Constants;

namespace Nostalgic.Bot.Telegram.Commands
{
    internal class OpenMemory: BaseCallbackCommand
    {
        public OpenMemory(int memoryId)
        {
            MemoryId = memoryId;
        }

        [JsonProperty("m")]
        public int MemoryId { get; }
    }
}
