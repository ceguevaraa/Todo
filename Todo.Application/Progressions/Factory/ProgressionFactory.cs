using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Lists;
using Todo.Domain.Progressions;

namespace Todo.Application.Progressions.Factory
{
    public class ProgressionFactory : IProgressionFactory
    {
        public Progression Create(TodoItem todoItem, DateTime createdAt, decimal percentage)
        {
            return new Progression(todoItem, createdAt, percentage);
        }
    }
}
