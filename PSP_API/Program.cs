var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var scoresBD = new[]
{
    new Score("Fran",200)
}.ToList();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/players", () =>
{
    var scores =  scoresBD;
    return scores;
})
.WithName("GetPlayers");

app.MapPost("/player-points", (Score score) => {
    
    scoresBD.Add(score);

    Console.WriteLine(scoresBD);
    return score;
}).WithName("PostPoints");

app.Run();

record Score(string name ,int points){

}


