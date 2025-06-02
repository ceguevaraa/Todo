using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Interfaces;

namespace Todo.Application.Lists.Queries.GetTodoItemDetail
{
    public class GetTodoItemDetailQuery : IGetTodoItemDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetTodoItemDetailQuery(IDatabaseService database)
        {
            _database = database;
        }
        public TodoItemDetailModel Execute(int id)
        {
            var item = _database.TodoItems
                .Where(p => p.Id == id)
                .Select(p => new TodoItemDetailModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Category = p.Category,
                    IsCompleted = p.IsCompleted,
                    Progressions = p.Progressions
                    .Select(x => new ProgressionModel
                    {
                        Percentage = x.Percentage,
                        Created = x.Created,
                    })
                    .ToList()
                })
                .Single();

            return item;
        }
    }
}
