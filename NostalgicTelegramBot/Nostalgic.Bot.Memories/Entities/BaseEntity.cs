using System;
using System.Collections.Generic;
using System.Text;

namespace Nostalgic.Bot.Memories.Entities
{
    public abstract class BaseEntity
    {
        internal BaseEntity()
        {

        }

        public int Id { get; internal set; }
    }
}
