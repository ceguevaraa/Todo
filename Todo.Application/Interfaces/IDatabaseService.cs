using Microsoft.EntityFrameworkCore;
using Todo.Domain.Lists;
using Todo.Domain.Progressions;

namespace Todo.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<Progression> Progressions { get; set; }
        void Save();
    }
}
