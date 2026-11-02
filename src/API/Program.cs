using CQRS_Demo.API.Exceptions;
using CQRS_Demo.Application.Behaviors;
using CQRS_Demo.Application.Common.Interfaces;
using CQRS_Demo.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite("Data Source=app.db"));

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(typeof(CQRS_Demo.Application.IAssemblyMarker).Assembly);
});

builder.Services.AddValidatorsFromAssembly(typeof(CQRS_Demo.Application.IAssemblyMarker).Assembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddScoped<IAppDbContext , AppDbContext>();


builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
