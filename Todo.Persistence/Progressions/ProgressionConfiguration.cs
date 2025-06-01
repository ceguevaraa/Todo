using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Progressions;

namespace Todo.Persistence.Progressions
{
    public class ProgressionConfiguration
        : IEntityTypeConfiguration<Progression>
    {

        public void Configure(EntityTypeBuilder<Progression> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Percentage)
                .IsRequired();

            builder.Property(p => p.Created)
                .IsRequired();

            builder.HasOne(p => p.ParentItem);

            builder.Navigation(p => p.ParentItem)
                .IsRequired()
                .AutoInclude();
        }
    }
}