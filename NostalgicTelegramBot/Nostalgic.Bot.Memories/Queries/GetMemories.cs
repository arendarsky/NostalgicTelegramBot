using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MediatR;
using Nostalgic.Bot.Memories.Entities;

namespace Nostalgic.Bot.Memories.Queries
{
    internal class GetMemories: IRequest<IEnumerable<Memory>>
    {
        public GetMemories(Expression<Func<Memory, bool>> expression = null)
        {
            Expression = expression;
        }

        public Expression<Func<Memory, bool>> Expression { get; }
    }
}
