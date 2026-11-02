using CQRS_Demo.Application.Common.Interfaces;
using CQRS_Demo.Domain.Todos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Application.Todos.Queries.GetTodoById;

public sealed class GetTodoByIdHandler(IAppDbContext context) : IRequestHandler<GetTodoByIdQuery, Todo?>
{
    public async Task<Todo?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        return await context.Todo.FindAsync([request.id], cancellationToken);
    }
}