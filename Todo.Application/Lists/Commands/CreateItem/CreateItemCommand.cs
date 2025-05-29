using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Interfaces;
using Todo.Application.Lists.Commands.Factory;

namespace Todo.Application.Lists.Commands.CreateItem
{
    public class CreateItemCommand : ICreateItemCommand
    {
        private readonly IDatabaseService _database;
        private readonly ITodoFactory _todoFactory;

        public CreateItemCommand(IDatabaseService databaseService, ITodoFactory todoFactory)
        {
            _database = databaseService; 
            _todoFactory = todoFactory;
        }
        public void Execute(CreateItemModel model)
        {
            var item = _todoFactory.Create(model.Id, model.Title, model.Description, model.Category);
            _database.TodoItems.Add(item);
            _database.Save();
        }
    }
}
