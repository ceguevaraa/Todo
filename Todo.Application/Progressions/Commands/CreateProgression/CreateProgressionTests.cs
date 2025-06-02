using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using Todo.Application.Interfaces;
using Todo.Application.Progressions.Factory;
using Todo.Domain.Lists;
using Todo.Domain.Progressions;

namespace Todo.Application.Progressions.Commands.CreateProgression
{
    [TestFixture]

    public class CreateProgressionTests
    {
        private TodoItem _item;
        private CreateProgressionModel _model;
        private CreateProgressionCommand _command;
        private AutoMocker _mocker;
        private Progression _progression;

        private const int ItemId = 1;
        private const string Title = "Complete Marketing Report";
        private const string Description = "Finish report on time";
        private const string Category = "Work";

        private DateTime CreatedAt = DateTime.Now;
        private const decimal Percentage = 50;


        [SetUp]
        public void SetUp()
        {
            _item = new TodoItem()
            {
                Id = ItemId,
                Title = Title,
                Description = Description,
                Category = Category
            };
            
            _model = new CreateProgressionModel()
            {
                TodoItemId = ItemId,
                Percentage = Percentage,
                CreatedAt = CreatedAt
            };

            _progression = new Progression(_item, CreatedAt, Percentage);

            _mocker = new AutoMocker();

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.TodoItems)
                .ReturnsDbSet(new List<TodoItem> { _item });

            _mocker.GetMock<IDatabaseService>()
               .Setup(p => p.Progressions)
               .Returns(_mocker.GetMock<DbSet<Progression>>().Object);

            _mocker.GetMock<IProgressionFactory>()
                .Setup(p => p.Create(
                    _item,
                    CreatedAt,
                    Percentage))
                .Returns(_progression);

            _command = _mocker.CreateInstance<CreateProgressionCommand>();
        }

        [Test]
        public void TestExecuteShouldAddProgressionToItem()
        {
            _command.Execute(_model);

            _mocker.GetMock<DbSet<Progression>>()
                .Verify(p => p.Add(_progression),
                    Times.Once);

        }

    }
}
