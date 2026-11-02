
using CQRS_Demo.Application.Common.Expectation;
using CQRS_Demo.Application.Common.Interfaces;
using CQRS_Demo.Domain.Todos;
using MediatR;

namespace CQRS_Demo.Application.Todos.Commands.UpdateTodo;


public sealed class UpdateTodoCommandHandler(IAppDbContext context) : IRequestHandler<UpdateTodoCommand>
{
    public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await context.Todo.FindAsync([request.Id], cancellationToken);

        if (todo is null)
            throw new NotFoundException(nameof(Todo), request.Id);

        todo.Title = request.Title;
        todo.Completed = request.completed;

        await context.SaveChangesAsync(cancellationToken);
    }

}