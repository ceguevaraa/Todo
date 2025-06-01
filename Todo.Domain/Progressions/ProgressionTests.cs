using NUnit.Framework;

namespace Todo.Domain.Progressions
{
    [TestFixture]
    public class ProgressionTests
    {

        private Progression _progression;
        private const int Percentage = 50;
        private static readonly DateTime Created = DateTime.Now;
        
        [SetUp]
        public void SetUp()
        {
            _progression = new Progression(Created, Percentage);
        }
        [Test]
        public void TestProgressionShouldHaveValidProperties()
        {
            Assert.That(_progression.Percentage, Is.EqualTo(Percentage));
            Assert.That(_progression.Created, Is.EqualTo(Created));
        }
        
        [Test]
        public void TestProgressionShouldNotAllowInvalidPercentage()
        {
            _progression = new Progression(Created, 150); // Invalid percentage
            Assert.That(_progression.IsPercentRangeValid, Is.False, "Progression should not be valid with percentage greater than 100.");
        }
       
    }
}
