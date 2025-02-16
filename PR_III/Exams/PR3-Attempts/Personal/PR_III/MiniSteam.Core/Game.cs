namespace MiniSteam.Core
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsSinglePlayer { get; set; }
        public bool IsMultiPlayer { get; set; }
        public bool HasControllerSupport { get; set; }
        public Ranking VoterRanking { get; set; }
        public List<Genre> GenreList { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public List<User> Owners { get; set; }

        public Game() {
            Title = string.Empty;
            Description = string.Empty;
            IsSinglePlayer = false;
            IsMultiPlayer = false;
            HasControllerSupport = false;
            VoterRanking = new Ranking();
            GenreList = [];
            ReleaseDate = new DateOnly();
            Owners = [];
        }

        public void AddUser(User user)
        {
            if (!Owners.Contains(user))
            {
                Owners.Add(user);
                if (!user.OwnedGames.Contains(this))
                {
                    user.OwnedGames.Add(this);
                }

            }
        }

        public void RemoveUser(User user) {
            if (Owners.Remove(user))
            {  
                user.OwnedGames.Remove(this);
            }
        }
    }
}
