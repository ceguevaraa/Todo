using Todo.Domain.Common;
using Todo.Domain.Lists;

namespace Todo.Domain.Progressions
{
    public class Progression : IEntity
    {
        private bool _isValid;
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public decimal Percentage { get; set; }
        public TodoItem ParentItem { get; set; }

        public Progression(TodoItem todoItem, DateTime created, decimal percentage)
        {
            ParentItem = todoItem;
            Created = created;
            Percentage = percentage;
            _isValid = percentage > 0 && percentage < 100;
        }
        public bool IsPercentRangeValid { get { return _isValid; } private set { _isValid = value; } }
    }
}
