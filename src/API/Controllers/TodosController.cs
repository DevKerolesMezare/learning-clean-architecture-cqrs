using CQRS_Demo.API.Requests;
using CQRS_Demo.Application.Todos.Commands.CreateTodo;
using CQRS_Demo.Application.Todos.Commands.DeleteTodo;
using CQRS_Demo.Application.Todos.Commands.UpdateTodo;
using CQRS_Demo.Application.Todos.Queries.GetTodoById;
using CQRS_Demo.Application.Todos.Queries.GetTodos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Demo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        // var result = await mediator.Send(new GetTodoQuery());
        // or
        return Ok(await mediator.Send(new GetTodoQuery()));
    }

    [HttpGet("{todoId:guid}", Name = "GetTodoById")]
    public async Task<IActionResult> Get(Guid todoId)
    {
        var result = await mediator.Send(new GetTodoByIdQuery(todoId));

        return result is null ? NotFound() : Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Post(CreateTodoRequest request)
    {
        var command = new CreateTodoCommand(request.Title);
        var todoId = await mediator.Send(command);

        return CreatedAtRoute(
            "GetTodoById",
            new { todoId },
            null
        );
    }


    [HttpPut("{todoId:guid}")]
    public async Task<IActionResult> Update(Guid todoId, UpdateTodoRequest request)
    {
        var command = new UpdateTodoCommand(todoId, request.Title, request.Completed);

        await mediator.Send(command);

        return NoContent();
    }


    [HttpDelete("{todoId:guid}")]
    public async Task<IActionResult> Delete(Guid todoId)
    {
        var command = new DeleteTodoCommand(todoId);

        await mediator.Send(command);

        return NoContent();
    }



}
