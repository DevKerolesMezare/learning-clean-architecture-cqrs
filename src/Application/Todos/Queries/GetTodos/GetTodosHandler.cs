using CQRS_Demo.Application.Common.Interfaces;
using CQRS_Demo.Domain.Todos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Application.Todos.Queries.GetTodos;

public sealed class GetTodosHandler(IAppDbContext context) : IRequestHandler<GetTodoQuery, List<Todo>>
{
    public async Task<List<Todo>> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        return await context.Todo.ToListAsync(cancellationToken);
    }

}
