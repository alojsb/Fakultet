using MiniSteam.Core;

namespace MiniSteam.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create instances.
            User user1 = new User { Id = 1, Name = "Alice" };
            User user2 = new User { Id = 2, Name = "Bob" };

            Game game1 = new Game { Id = 101, Title = "Space Adventure" };
            Game game2 = new Game { Id = 102, Title = "Mystery Quest" };

            // Add games to users (and update the relationship in both directions).
            user1.AddGame(game1);
            user1.AddGame(game2);
            user2.AddGame(game1);

            // Now, user1.OwnedGames contains game1 and game2,
            // and game1.Owners contains user1 and user2, while game2.Owners contains only user1.
            Console.WriteLine($"{user1.Name} owns {user1.OwnedGames.Count} game(s).");
            Console.WriteLine($"{game1.Title} is owned by {game1.Owners.Count} user(s).");
        }
    }
}

// user
// game - desc, genres, multiplayer true false, singleplayer true false, controler support true false, ranking
// genre - jedna igra može da ima nekoliko žanrova
// users games - many to many - 1:1 class mappings
// ranking

// ref u UI sa Core-a
// napravi igre
// napravi usera, assign mu game
