using CQRS_Demo.Application.Common.Interfaces;
using CQRS_Demo.Domain.Todos;
using CQRS_Demo.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
 :DbContext(options), IAppDbContext
{
    public DbSet<Todo> Todo => Set <Todo>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoConfiguration).Assembly);
    }

}
