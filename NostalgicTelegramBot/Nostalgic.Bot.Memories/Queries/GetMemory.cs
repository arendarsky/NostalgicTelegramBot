using System;
using System.Linq.Expressions;
using MediatR;
using Nostalgic.Bot.Memories.Entities;

namespace Nostalgic.Bot.Memories.Queries
{
    public class GetMemory: IRequest<Memory>
    {
        public GetMemory(Expression<Func<Memory, bool>> expression)
        {
            Expression = expression;
        }

        public Expression<Func<Memory, bool>> Expression { get; }
    }
}
