using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Lists;

namespace Todo.Application.Lists.Commands.Factory
{
    public interface ITodoFactory
    {
        TodoItem Create(int id, string title, string description, string category);
        TodoItem Update(int id, string description);
        TodoItem Delete(int id);

    }
}
