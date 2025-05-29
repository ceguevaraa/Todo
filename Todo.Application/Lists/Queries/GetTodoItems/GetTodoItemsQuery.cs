using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Interfaces;

namespace Todo.Application.Lists.Queries.GetTodoItems
{
    public class GetTodoItemsQuery
        : IGetTodoItemsQuery
    {
        private readonly IDatabaseService _database;
        public GetTodoItemsQuery(IDatabaseService database)
        {
            _database = database;
        }
        public List<TodoItemModel> Execute()
        {
            var items = _database.TodoItems.
                Select(x => new TodoItemModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Category = x.Category,
                    IsCompleted = x.IsCompleted,
                    Title = x.Title
                });

            return items.ToList();
        }
    }
}
