using Todo.Domain.Common;
using Todo.Domain.Progressions;

namespace Todo.Domain.Lists
{
    public class TodoItem : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsCompleted
        {
            get
            {
                return Progressions.Sum(x => x.Percentage) == 100;
            }
        
        }
        public List<Progression> Progressions { get; set; } = new List<Progression>();

        public void ProcessProgression(Progression progression)
        {
            if (!progression.IsPercentRangeValid)
                throw new InvalidOperationException("Percent of progression is not valid");
            
            if (!IsProgressionDateValid(progression))
                throw new InvalidOperationException("Date of progression is not valid");


            if (!ValidateProgressionsCompletion(progression))
                throw new InvalidOperationException("Completion does not have a valid value");

            Progressions.Add(progression);
        }

        private bool IsProgressionDateValid(Progression progression)
        {
            return Progressions.FirstOrDefault(p => p.Created >= progression.Created) == null;
        }

        private bool ValidateProgressionsCompletion(Progression progression)
        {
            var currentCompletion = Progressions.Sum(i => i.Percentage);
            return currentCompletion + progression.Percentage <= 100;
        }
    }
}
