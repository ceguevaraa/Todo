using NUnit.Framework;
using NUnit.Framework.Legacy;
using Todo.Domain.Progressions;

namespace Todo.Domain.Lists
{
    [TestFixture]

    public class TodoItemTests
    {
        private TodoItem _item;

        private const int Id = 1;
        private const string Title = "Complete Marketing Report";
        private const string Description = "Finish report on time";
        private const string Category = "Work";

        [SetUp]
        public void SetUp()
        {
            _item = new TodoItem()
            {
                Category = Category,
                Title = Title,
                Description = Description,
                Id = Id
            };
        }

        [Test]
        public void TestAddProgressionShouldAddProgressionToItem()
        {
            var progression = new Progression(_item, DateTime.Now, 50);
            _item.ProcessProgression(progression);
            Assert.That(_item.Progressions.Contains(progression));
        }

        [Test]
        public void TestAddProgressionShouldNotAddInvalidProgression()
        {
            var progression = new Progression(_item, DateTime.Now, 150); // Invalid percentage

            var ex = Assert.Throws<InvalidOperationException>(() => { 
                _item.ProcessProgression(progression);
            });
            
            StringAssert.Contains("Percent of progression is not valid", ex.Message);
        }

        [Test]
        public void TestAddProgressionShouldNotAddProgressionWithInvalidDate()
        {
            var progression1 = new Progression(_item, DateTime.Now, 50); // Valid progression
            _item.ProcessProgression(progression1);

            var progression2 = new Progression(_item, DateTime.Now.AddMinutes(-10), 30); // Invalid date (older than the first)

            Assert.That(_item.Progressions.Contains(progression1));

            var ex = Assert.Throws<InvalidOperationException>(() => {
                _item.ProcessProgression(progression2);
            });

            StringAssert.Contains("Date of progression is not valid", ex.Message);
        }

        [Test]
        public void TestIsCompletedShouldReturnTrueWhenProgressionsSumTo100()
        {
            _item.ProcessProgression(new Progression(_item, DateTime.Now, 50));
            _item.ProcessProgression(new Progression(_item, DateTime.Now.AddMinutes(1), 20));
            _item.ProcessProgression(new Progression(_item, DateTime.Now.AddMinutes(2), 30));


            Assert.That(_item.IsCompleted);
        }
    }
}
