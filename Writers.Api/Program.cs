using JwtConfiguration;
using Writers.Api.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddJwtAuthentication();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IWriterRep, WriterRep>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
