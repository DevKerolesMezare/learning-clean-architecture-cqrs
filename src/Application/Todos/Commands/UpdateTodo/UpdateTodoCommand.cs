using MediatR;

namespace CQRS_Demo.Application.Todos.Commands.UpdateTodo;

public sealed record UpdateTodoCommand(Guid Id, string Title, bool completed) : IRequest;
