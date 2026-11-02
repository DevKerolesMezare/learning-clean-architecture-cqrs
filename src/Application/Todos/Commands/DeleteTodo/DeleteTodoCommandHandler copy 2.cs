using CQRS_Demo.Application.Common.Expectation;
using CQRS_Demo.Application.Common.Interfaces;
using CQRS_Demo.Domain.Todos;
using MediatR;

namespace CQRS_Demo.Application.Todos.Commands.DeleteTodo;

public sealed class DeleteTodoCommandHandler(IAppDbContext context) : IRequestHandler<DeleteTodoCommand>
{
    public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await context.Todo.FindAsync([request.Id], cancellationToken);

        if (todo is null)
            throw new NotFoundException(nameof(Todo), request.Id);

        context.Todo.Remove(todo);

        await context.SaveChangesAsync(cancellationToken);
    }
}