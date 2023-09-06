using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAuthentication();

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
    app.UseSwaggerUI(config => config.DisplayRequestDuration());
}

app.UseHttpsRedirection();

app.UseExceptionHandler("/error/");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
