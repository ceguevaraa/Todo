using Todo.Domain.Lists;

namespace Todo.Application.Lists.Commands.Factory
{
    public interface ITodoFactory
    {
        TodoItem Create(int id, string title, string description, string category);
        TodoItem Create(int id, string description);
        TodoItem Create(int id);

    }
}
