using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MediatR;
using Nostalgic.Bot.Memories.Entities;

namespace Nostalgic.Bot.Memories.Commands
{
    internal class DeleteContent: IRequest
    {
        public DeleteContent(Expression<Func<Content, bool>> expression)
        {
            Expression = expression;
        }

        public Expression<Func<Content, bool>> Expression { get; }
    }
}
