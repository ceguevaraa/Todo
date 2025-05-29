using Todo.Domain.Lists;

namespace Todo.Application.Lists.Commands.Factory
{
    public class TodoFactory : ITodoFactory
    {
        public TodoItem Create(int id, string title, string description, string category)
        {
            return new TodoItem() { Title = title, Category = category, Description = description };
        }

        public TodoItem Delete(int id)
        {
            return new TodoItem() { Id = id };
        }

        public TodoItem Update(int id, string description)
        {
            return new TodoItem() { Id = id, Description = description };
        }
    }
}
