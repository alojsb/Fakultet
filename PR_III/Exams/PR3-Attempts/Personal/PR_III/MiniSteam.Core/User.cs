using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSteam.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Password { get; set; } = "NO_PASS";
        public List<Game> OwnedGames { get; set; } = [];

        public void AddGame(Game game)
        {
            if (!OwnedGames.Contains(game))
            {
                OwnedGames.Add(game);
                game.AddUser(this);
            }
        }

        public void RemoveGame(Game game) {
            if (OwnedGames.Remove(game))
            {
                game.RemoveUser(this);
            }
        }
    }
}
