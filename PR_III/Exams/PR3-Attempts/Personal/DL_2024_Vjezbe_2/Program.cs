using System.Text;
namespace DL_2024_Vjezbe_2
{
    public class Game
    {
        // Private Fields (backing fields)
        private string _name;
        private decimal _price;

        // Constructors
        public Game(string name, string description, decimal price = 100.00m) {
        
            _name = name;
            Description = description;
            _price = price;
        }

        public Game(string name = "NOT_SPECIFIED") { 
            _name = name;
        }

        // Auto-Implemented Properties (simple properties)
        public int Id { get; set; }
        public  string? Description { get; set; }
        public  Publisher? GamePublisher { get; set; }
        public int Test { get; set; } // Instead of a public field with separate accessors

        // Properties with Backing Fields and Custom Logic
        public string Name
        {
            get { return _name.ToUpper(); }
            set { _name = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value > 1000)
                {
                    Console.WriteLine("Too expensive!");
                }
                else
                {
                    _price = (int)MyCustomRule(value);
                }
            }
        }

        // Public Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Game Details:");
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Description: {Description}");
            sb.AppendLine($"Price: {Price:C}"); // :C formats as currency

            if (GamePublisher != null)
            {
                sb.AppendLine("Publisher Details:");
                sb.AppendLine($"Publisher ID: {GamePublisher.Id}");
                sb.AppendLine($"Publisher Name: {GamePublisher.Name}");
            }

            // Return the constructed string.
            return sb.ToString();
        }

        // Private Methods
        private static decimal MyCustomRule(decimal val)
        {
            // Custom logic here...
            return val;
        }
    }

    public class Publisher
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("\nNew game =============");
            Game game = new Game("GTA Vice City", "80s nostalgia overload", 19.85m);
            Console.WriteLine(game);

            Console.WriteLine("\nGame3 =============");
            Game game3 = new Game();
            game3.Name = "Stardew Valley";
            Console.WriteLine(game3);

            Console.WriteLine("\nGame55 =============");
            Game game55 = game3;
            Console.WriteLine(game55);

            Console.WriteLine("\nGame3 after game55 rename =============");
            game55.Name = "NewName";
            Console.WriteLine(game3);
        }
    }
}
