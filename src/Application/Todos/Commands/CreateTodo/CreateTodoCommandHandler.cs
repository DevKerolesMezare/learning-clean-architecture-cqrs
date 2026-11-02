
using CQRS_Demo.Application.Common.Interfaces;
using CQRS_Demo.Domain.Todos;
using MediatR;

namespace CQRS_Demo.Application.Todos.Commands.CreateTodo;


public sealed class CreateTodoCommandHandler(IAppDbContext context) : IRequestHandler<CreateTodoCommand, Guid>
{
    public async Task<Guid> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Todo
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
        };

        context.Todo.Add(todo);

        await context.SaveChangesAsync(cancellationToken);

        return todo.Id;
    }

}