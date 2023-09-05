using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    string fileName = Assembly.GetExecutingAssembly().GetName().Name ?? "Api";
    string path = Path.Combine(AppContext.BaseDirectory, fileName + ".xml");
    options.IncludeXmlComments(path);
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error/");

app.Map("/error", (HttpContext context) =>
{
    Exception? exception = context.Features
    .Get<IExceptionHandlerFeature>()?.Error;

    return Results.Problem(
        statusCode: StatusCodes.Status500InternalServerError,
        title: exception?.Message);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
