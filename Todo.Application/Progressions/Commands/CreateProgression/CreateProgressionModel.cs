namespace Todo.Application.Progressions.Commands.CreateProgression
{
    public class CreateProgressionModel
    {
        public int TodoItemId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Percentage { get; set; }
    }

    public class CreateProgressionRequest
    {
        public DateTime CreatedAt { get; set; }
        public decimal Percentage { get; set; }
    }
}
