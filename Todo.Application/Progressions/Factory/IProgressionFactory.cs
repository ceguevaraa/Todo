using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Lists;
using Todo.Domain.Progressions;

namespace Todo.Application.Progressions.Factory
{
    public interface IProgressionFactory
    {
        public Progression Create(TodoItem todoItem, DateTime createdAt, decimal percentage);
    }
}
