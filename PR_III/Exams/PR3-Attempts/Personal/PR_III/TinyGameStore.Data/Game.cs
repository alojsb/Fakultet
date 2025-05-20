namespace TinyGameStore.Data
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[]? CoverArt { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<User> Owners { get; set; }
    }
}
