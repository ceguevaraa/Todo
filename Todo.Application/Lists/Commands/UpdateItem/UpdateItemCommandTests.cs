using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using Todo.Application.Interfaces;
using Todo.Application.Lists.Commands.Factory;
using Todo.Domain.Lists;

namespace Todo.Application.Lists.Commands.UpdateItem
{
    [TestFixture]
    public class UpdateItemCommandTests
    {
        private UpdateItemCommand _command;
        private AutoMocker _mocker;
        private UpdateItemModel _model;
        private TodoItem _todoItem;
        private TodoItem _updatedItem;

        private const int Id = 1;
        private const string Title = "Complete Marketing Report";
        private const string Description = "Finish report on time";
        private const string UpdatedDescription = "Finish report later today";
        private const string Category = "Work";

        [SetUp]
        public void SetUp()
        {
            _model = new UpdateItemModel()
            {
                Description = UpdatedDescription,
                Id = Id
            };

            _mocker = new AutoMocker();

            _todoItem = new TodoItem()
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Category = Category
            };

            _updatedItem = new TodoItem() { Id = Id, Description = UpdatedDescription };

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.TodoItems)
                .ReturnsDbSet(new List<TodoItem> { _todoItem });


            _mocker.GetMock<ITodoFactory>()
                .Setup(p => p.Create(
                    Id,
                    UpdatedDescription))
                .Returns(_updatedItem);

            _command = _mocker.CreateInstance<UpdateItemCommand>();

        }

        [Test]
        public void TestExecuteShouldUpdateItemToTheDatabase()
        {
            _command.Execute(_model);

            _mocker.GetMock<IDatabaseService>()
                .Verify(p => p.Save(),
                    Times.Once);
        }
    }
}
