using Microsoft.IdentityModel.Tokens;
using System.Text;
using OcelotAuthentication.Services;
using JwtConfiguration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddJwtAuthentication();
// Add services to the container.
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
