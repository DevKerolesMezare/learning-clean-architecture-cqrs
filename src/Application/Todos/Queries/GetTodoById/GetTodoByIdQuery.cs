using CQRS_Demo.Domain.Todos;
using MediatR;

namespace CQRS_Demo.Application.Todos.Queries.GetTodoById;

public sealed record GetTodoByIdQuery(Guid id): IRequest<Todo?>;