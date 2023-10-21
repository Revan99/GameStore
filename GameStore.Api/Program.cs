using GameStore.Api.Entities;

const string GetGameEndPointName = "GetGame";

List<Game> games = new(){
    new Game(){
        Id=1,
        Name = "Street fight",
        Genre = "Fighting",
        Price = 19.99M,
        ReleaseDate = new DateTime(1991, 2,1),
        ImageUri = "https://placehold.co/100",
    },
    new Game(){
        Id=2,
        Name = "Final fantasy XIV",
        Genre = "Role playing",
        Price = 59.99M,
        ReleaseDate = new DateTime(2010, 9, 30),
        ImageUri = "https://placehold.co/100",
    },
    new Game(){
        Id=3,
        Name = "FIFA 23",
        Genre = "Sport",
        Price = 69.99M,
        ReleaseDate = new DateTime(2022, 9, 27),
        ImageUri = "https://placehold.co/100",
    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

// get all games
app.MapGet("/games", () => games);

// get game by id
app.MapGet("/games/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);
    if (game is not null)
        return Results.Ok(game);
    return Results.NotFound();
}).WithName(GetGameEndPointName);


// create game
app.MapPost("/game", (Game game) =>
{
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
});

// update game by id
app.Map

app.Run();
