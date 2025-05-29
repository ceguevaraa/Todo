using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var item = _progressionFactory.Create(model.CreatedAt, model.Percentage);
            _database.Progressions.Add(item);
            _database.Save();
        }
    }
}
