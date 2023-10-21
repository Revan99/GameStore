using GameStore.Api.Entities;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";

    static List<Game> games = new(){
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
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games")
               .WithParameterValidation();


        // get all games
        group.MapGet("/", () => games);

        // get game by id
        group.MapGet("/{id}", (int id) =>
        {
            Game? game = games.Find(game => game.Id == id);

            if (game is null)
                return Results.NotFound();

            return Results.Ok(game);

        }).WithName(GetGameEndPointName);

        // create game
        group.MapPost("/", (Game game) =>
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
        });

        // update game by id
        group.MapPut("/{id}", (int id, Game updatedGame) =>
        {
            Game? existingGame = games.Find(game => game.Id == id);

            if (existingGame is null)
                return Results.NotFound();

            existingGame.Name = updatedGame.Name;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.ImageUri = updatedGame.ImageUri;

            return Results.NoContent();

        });

        group.MapDelete("/{id}", (int id) =>
        {
            Game? game = games.Find(game => game.Id == id);

            if (game is not null)
                games.Remove(game);

            return Results.NoContent();
        });
        return group;
    }
}