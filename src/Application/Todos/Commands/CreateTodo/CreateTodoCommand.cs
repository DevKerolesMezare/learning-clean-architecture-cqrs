using MediatR;

namespace CQRS_Demo.Application.Todos.Commands.CreateTodo;

public sealed record CreateTodoCommand(string Title) : IRequest<Guid>;
