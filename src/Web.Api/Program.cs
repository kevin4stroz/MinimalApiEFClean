using System.Reflection;
using Web.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependency(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(builder.Configuration);

builder.Services.AddSwagger();
builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.MapEndpoints();

await app.RunAsync();
