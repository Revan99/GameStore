using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGamesRepositories
{
    static readonly List<Game> games = new(){
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

    public IEnumerable<Game> GetAll()
    {
        return games;
    }
    public Game? Get(int id)
    {
        return games.Find(game => game.Id == id);
    }
}