using Microsoft.EntityFrameworkCore;
using GameScoreAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GameScoreContext>(options =>
    options.UseSqlite("Data Source=gamescores.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
