using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Common;
using Todo.Domain.Progressions;

namespace Todo.Domain.Lists
{
    public class TodoItem : IEntity
    {
        private bool _isCompleted;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsCompleted
        {
            get
            {
                return _isCompleted;
            }
            private set
            {
                _isCompleted = value;
            }
        }
        public List<Progression> Progressions { get; set; } = new List<Progression>();

        public void AddProgression(Progression progression)
        {
            if (!progression.IsPercentRangeValid)
                return;
            
            if (!IsProgressionDateValid(progression))
                return;

            if (!ValidateProgressionsCompletion(progression))
                return;

            Progressions.Add(progression);
        }

        private bool IsProgressionDateValid(Progression progression)
        {
            return Progressions.Any(p => p.Created > progression.Created);
        }

        private bool ValidateProgressionsCompletion(Progression progression)
        {
            var currentCompletion = Progressions.Sum(i => i.Percentage);
            return currentCompletion + progression.Percentage > 100;
        }

        private void IsItemCompleted()
        {
            _isCompleted = Progressions.Sum(x => x.Percentage) == 100;
        }
    }
}
