using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using Todo.Application.Interfaces;
using Todo.Domain.Lists;

namespace Todo.Application.Lists.Queries.GetTodoItems
{
    [TestFixture]
    public class GetTodoItemsQueryTests
    {
        private GetTodoItemsQuery _query;
        private AutoMocker _mocker;
        private TodoItem _todoItem;

        private const int Id = 1;
        private const string Title = "Meeting with managament";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();
            _todoItem = new TodoItem()
            {
                Id = Id,
                Title = Title,
            };

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.TodoItems)
                .ReturnsDbSet(new List<TodoItem> { _todoItem });

            _query = _mocker.CreateInstance<GetTodoItemsQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfItems()
        {
            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Title, Is.EqualTo(Title));
        }
    }
}
