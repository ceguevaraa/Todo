using Todo.Domain.Common;

namespace Todo.Domain.Progressions
{
    public class Progression : IEntity
    {
        private bool _isValid;
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public decimal Percentage { get; set; }
        
        public Progression(DateTime created, decimal percentage)
        {
            Created = created;
            _isValid = percentage > 0 && percentage < 100;
        }
        public bool IsPercentRangeValid { get { return _isValid; } private set { _isValid = value; } }
    }
}
