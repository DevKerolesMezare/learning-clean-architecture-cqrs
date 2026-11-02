using CQRS_Demo.Domain.Todos;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Todo> Todo {get;}

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
