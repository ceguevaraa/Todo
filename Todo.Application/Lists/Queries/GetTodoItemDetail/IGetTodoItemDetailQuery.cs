using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Lists.Queries.GetTodoItemDetail
{
    public interface IGetTodoItemDetailQuery
    {
        TodoItemDetailModel Execute(int  id);
    }
}
