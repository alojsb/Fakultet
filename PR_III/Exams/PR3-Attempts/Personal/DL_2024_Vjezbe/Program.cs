namespace DL_2024_Vjezbe_1
{
    /*
     Star
    Planet
    Moon
    Asteroid
     */

    public class Star
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Asteroid[] Asteroids { get; set; }
        public Planet[] Planets { get; set; }
    }

    public class Planet
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Moon[] Moons { get; set; }
    }

    public class Moon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }

    public class Asteroid
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal OrbitalPeriod { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Star sun = new Star
            {
                Name = "Sun",
                Description = "Main sequence star in the center of the Solar System.",
                Type = "G-Type main.sequence star",

                Planets = new Planet[]
                {
                    new Planet {
                        Name =  "Earth",
                        Description = "The third planet from the Sun, home to diverse life forms.",
                        Type = "Terrestrial",

                        Moons = new Moon[] {
                            new Moon {
                                Name = "Moon",
                                Description = "Earth's only natural satellite.",
                                Type = "Natural Satellite"
                            }
                        }
                    },
                    new Planet {
                        Name = "Mars",
                        Description = "The red planet, known for its canals and tallest mountain in the Solar System.",
                        Type = "Terrestrial",
                        Moons = new Moon[] {
                            new Moon {
                                Name = "Phobos",
                                Description = "The larger and closer of Mars' two moons.",
                                Type = "Natural Satellite"
                            },
                            new Moon {
                                Name = "Deimos",
                                Description = "The smaller and more distant Martian moon.",
                                Type = "Natural Satellite"
                            }
                        }
                    }
                },
                Asteroids = new Asteroid[]
                {
                    new Asteroid
                    {
                        Name = "Ceres",
                        Description = "The largest object in the asteroid belt, also classified as a dwarf planet.",
                        Type = "Dwarf Planet / Asteroid",
                        OrbitalPeriod = 1680m // Orbital period in days (example value)
                    },
                    new Asteroid
                    {
                        Name = "Vesta",
                        Description = "One of the largest asteroids in the belt.",
                        Type = "Asteroid",
                        OrbitalPeriod = 1325m // Orbital period in days (example value)
                    }
                }
            };

            // Display some of the solar system information to the console.
            Console.WriteLine($"Star: {sun.Name}");
            Console.WriteLine(sun.Description);
            Console.WriteLine("\nPlanets:");
            foreach (var planet in sun.Planets)
            {
                Console.WriteLine($"- {planet.Name}: {planet.Description}");
                if (planet.Moons != null && planet.Moons.Length > 0)
                {
                    Console.WriteLine("  Moons:");
                    foreach (var moon in planet.Moons)
                    {
                        Console.WriteLine($"    - {moon.Name}: {moon.Description}");
                    }
                }
            }
            Console.WriteLine("\nAsteroids:");
            foreach (var asteroid in sun.Asteroids)
            {
                Console.WriteLine($"- {asteroid.Name}: {asteroid.Description} (Orbital Period: {asteroid.OrbitalPeriod} days)");
            }
        }
    }
}
