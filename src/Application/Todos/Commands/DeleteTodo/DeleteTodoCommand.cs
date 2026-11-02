using MediatR;

namespace CQRS_Demo.Application.Todos.Commands.DeleteTodo;

public sealed record DeleteTodoCommand(Guid Id) : IRequest;
