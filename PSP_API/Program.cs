var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var scoresBD = new[]
{
    new Score("Fran",200)
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


var scoresBD = new[]
{
    new Score("Fran",200)
};


app.MapGet("/players", () =>
{
    var scores =  scoresBD
        .ToArray();
    return scores;
})
.WithName("GetPlayers");

app.MapPost("/player-points", (Score score) => {
    
    scoresBD.Append(score);
    return score;
}).WithName("PostPoints");

app.Run();

record Score(string name ,int points){

}


