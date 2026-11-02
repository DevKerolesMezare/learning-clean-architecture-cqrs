using CQRS_Demo.Domain.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS_Demo.Infrastructure.Data.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("Todos");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title).IsRequired();
    }

}
