using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using Todo.Application.Interfaces;
using Todo.Domain.Lists;


namespace Todo.Application.Lists.Queries.GetTodoItemDetail
{
    [TestFixture]
    public class GetTodoItemDetailQueryTests
    {
        private GetTodoItemDetailQuery _query;
        private AutoMocker _mocker;
        private TodoItem _todoItem;

        private const int TodoItemId = 1;
        private const string Title = "Complete Project Report";
        private const string Description = "Finish the final report for the project";
        private const string Category = "Work";

        [SetUp]
        public void SetUp()
        {
            _todoItem = new TodoItem()
            {
                Id = TodoItemId,
                Title = Title,
                Description = Description,
                Category = Category,
            };

            _mocker = new AutoMocker();

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.TodoItems)
                .ReturnsDbSet(new List<TodoItem> { _todoItem });

            _query = _mocker.CreateInstance<GetTodoItemDetailQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnTodoItemDetail()
        {
            var result = _query.Execute(TodoItemId);

            Assert.That(result.Id,
                Is.EqualTo(TodoItemId));

            Assert.That(result.Title,
                Is.EqualTo(Title));

            Assert.That(result.Description,
                Is.EqualTo(Description));

            Assert.That(result.Category,
                Is.EqualTo(Category));
        }
    }
}
