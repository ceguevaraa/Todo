using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Lists;

namespace Todo.Persistence.Lists
{
    public class TodoItemConfiguration
        : IEntityTypeConfiguration<TodoItem>
    {

        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new TodoItem() { Id = 1, Title = "Work 1", Description = "Finish Report", Category = "Work" },
                new TodoItem() { Id = 2, Title = "Meeting 1", Description = "Presentation ", Category = "Meeting" },
                new TodoItem() { Id = 3, Title = "Meeting 2", Description = "Sync with team", Category = "Meeting" });
        }
    }
}
