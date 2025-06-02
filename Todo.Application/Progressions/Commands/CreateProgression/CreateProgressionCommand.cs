using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;
using Todo.Application.Progressions.Factory;

namespace Todo.Application.Progressions.Commands.CreateProgression
{
    public class CreateProgressionCommand : ICreateProgressionCommand
    {
        private readonly IDatabaseService _database;
        private readonly IProgressionFactory _progressionFactory;

        public CreateProgressionCommand(IDatabaseService databaseService, IProgressionFactory progressionFactory)
        {
            _database = databaseService;
            _progressionFactory = progressionFactory;
        }
        public void Execute(CreateProgressionModel model)
        {
            var todoItem = _database.TodoItems.Include("Progressions").FirstOrDefault(i => i.Id == model.TodoItemId)
                ?? throw new ArgumentException($"Todo item with ID {model.TodoItemId} does not exist.");

            var item = _progressionFactory.Create(todoItem, model.CreatedAt, model.Percentage);
            
            todoItem.ProcessProgression(item);
            _database.Progressions.Add(item);
            _database.Save();
        }
    }
}
