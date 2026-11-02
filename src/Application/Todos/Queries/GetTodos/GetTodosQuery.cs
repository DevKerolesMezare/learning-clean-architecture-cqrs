using CQRS_Demo.Domain.Todos;
using MediatR;

namespace CQRS_Demo.Application.Todos.Queries.GetTodos;

public sealed record GetTodoQuery: IRequest<List<Todo>>;