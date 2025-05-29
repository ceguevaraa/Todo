using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Lists.Queries.GetTodoItems
{
    public interface IGetTodoItemsQuery
    {
        List<TodoItemModel> Execute();
    }
}
