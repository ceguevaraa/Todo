using Todo.Application.Interfaces;
using Todo.Application.Lists.Commands.Factory;

namespace Todo.Application.Lists.Commands.DeleteItem
{
    public class DeleteItemCommand : IDeleteItemCommand
    {
        private readonly IDatabaseService _database;
        private readonly ITodoFactory _todoFactory;

        public DeleteItemCommand(IDatabaseService database, ITodoFactory todoFactory)
        {
            _database = database;
            _todoFactory = todoFactory;
        }
        public void Execute(int id)
        {
            var item = _todoFactory.Create(id, null, null, null);

            var foundItem = _database.TodoItems.Where(i => i.Id == item.Id).FirstOrDefault();

            if (foundItem == null)
                return;

            _database.TodoItems.Remove(foundItem);
            _database.Save();
        }
    }
}
