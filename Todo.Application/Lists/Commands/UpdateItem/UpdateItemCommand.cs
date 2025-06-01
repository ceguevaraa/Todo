using Todo.Application.Interfaces;
using Todo.Application.Lists.Commands.Factory;

namespace Todo.Application.Lists.Commands.UpdateItem
{
    public class UpdateItemCommand : IUpdateItemCommand
    {
        private readonly IDatabaseService _database;
        private readonly ITodoFactory _todoFactory;

        public UpdateItemCommand(IDatabaseService database, ITodoFactory todoFactory)
        {
            _database = database;
            _todoFactory = todoFactory;
        }
        public void Execute(UpdateItemModel model)
        {
            var foundItem = _database.TodoItems.Where(i => i.Id == model.Id).FirstOrDefault();

            if (foundItem == null)
                return;

            foundItem.Description = model.Description;

            _database.TodoItems.Update(foundItem);
            _database.Save();
        }
    }
}
