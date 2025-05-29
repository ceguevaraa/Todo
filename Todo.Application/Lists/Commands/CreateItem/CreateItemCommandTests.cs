using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Todo.Application.Interfaces;
using Todo.Application.Lists.Commands.Factory;
using Todo.Domain.Lists;

namespace Todo.Application.Lists.Commands.CreateItem
{
    [TestFixture]
    public class CreateItemCommandTests
    {
        private CreateItemCommand _command;
        private AutoMocker _mocker;
        private CreateItemModel _model;
        private TodoItem _item;

        private const int ItemId = 1;
        private const string Title = "Complete Marketing Report";
        private const string Description = "Finish report on time";
        private const string Category = "Work";

        [SetUp]
        public void SetUp()
        {
            _model = new CreateItemModel()
            {
                Category = Category,
                Description = Description,
                Title = Title,
                Id = ItemId
            };

            _item = new TodoItem();
            _mocker = new AutoMocker();

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.TodoItems)
                .Returns(_mocker.GetMock<DbSet<TodoItem>>().Object);

            _mocker.GetMock<ITodoFactory>()
                .Setup(p => p.Create(
                    ItemId,
                    Title,
                    Description,
                    Category))
                .Returns(_item);

            _command = _mocker.CreateInstance<CreateItemCommand>();

        }

        [Test]
        public void TestExecuteShouldAddItemToTheDatabase()
        {
            _command.Execute(_model);

            _mocker.GetMock<DbSet<TodoItem>>()
                .Verify(p => p.Add(_item),
                    Times.Once);
        }
    }
}
