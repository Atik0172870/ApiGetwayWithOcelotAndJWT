using Articles.Repository;
using JwtConfiguration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddJwtAuthentication();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IArticleRep, ArticleRep>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
