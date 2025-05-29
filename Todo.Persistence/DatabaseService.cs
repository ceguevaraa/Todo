using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Todo.Application.Interfaces;
using Todo.Domain.Lists;
using Todo.Domain.Progressions;
using Todo.Persistence.Lists;
using Todo.Persistence.Progressions;

namespace Todo.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        private readonly IConfiguration _configuration;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;

            Database.EnsureCreated();
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Progression> Progressions { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("TodoDbCore");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new TodoItemConfiguration().Configure(builder.Entity<TodoItem>());
            new ProgressionConfiguration().Configure(builder.Entity<Progression>());
        }
    }
}
