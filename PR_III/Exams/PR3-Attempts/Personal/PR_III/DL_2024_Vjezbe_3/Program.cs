using System.Reflection.Metadata;
using System.Text;

namespace DL_2024_Vjezbe_3
{
    public class Math {
        public const float PI = 3.1415926f; // Tied to class. Implicitly static.
    }

    public class Circle
    {
        public string Name { get; set; }
        public readonly float area; // Tied to instance. Can only be initialized in a constructor.
        public float Circumference { get; private set; }    // Can only be changed from within the class.

        public Circle(float area) { this.area = area; }
    }

    public class  CustomDictionary 
    {
        private int[] Keys { get; set; }
        private string[] Values { get; set; }
        private int count;

        public CustomDictionary(int capacity)
        {
            count = 0;
            Keys = new int[capacity];
            Values = new string[capacity];
        }


        public string this[int key]
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    if (Keys[i] == key)
                    {
                        return Values[i];
                    }
                }
                throw new ArgumentException("Key not found");
            }

            set
            {
                for (int i = 0; i < count; i++)
                {
                    if (Keys[i] == key)
                    {
                        Values[i] = value;
                        return;
                    }

                    if (count < Keys.Length)
                    {
                        Keys[count] = key;
                        Values[count] = value;
                        count++;
                    }
                }
            }
        }

        // Add a new key-value pair.
        public void Add(int key, string value)
        {
            // Ensure the key does not already exist.
            for (int i = 0; i < count; i++)
            {
                if (Keys[i] == key)
                {
                    throw new ArgumentException("Key already exists");
                }
            }
            if (count >= Keys.Length)
            {
                throw new InvalidOperationException("Dictionary is full");
            }
            Keys[count] = key;
            Values[count] = value;
            count++;
        }

        // Remove the key-value pair with the given key.
        public bool Remove(int key)
        {
            // Find the index of the key.
            for (int i = 0; i < count; i++)
            {
                if (Keys[i] == key)
                {
                    // Shift subsequent items left to fill the gap.
                    for (int j = i; j < count - 1; j++)
                    {
                        Keys[j] = Keys[j + 1];
                        Values[j] = Values[j + 1];
                    }
                    count--;
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\nDictionary content:");

            for (int i = 0; i < count; i++)
            {
                sb.AppendLine($"key: {Keys[i]}, value: {Values[i]}");
            }

            return sb.ToString();
        }
    }



    public abstract class Animal
    {
        // A concrete field and property (allowed in an abstract class)
        protected string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        // An abstract method: no body, must be overridden in derived classes
        public abstract void MakeSound();

        // A concrete method that derived classes inherit
        public virtual void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }

        public override void Eat() {
            Console.WriteLine($"{Name} is munching.");
        }
    }

    class Program
    {
        static void Main()
        {
            // Animal a = new Animal("Generic"); // Not allowed: Animal is abstract
            Dog dog = new Dog("Rex");
            dog.MakeSound(); // Output: "Rex says: Woof!"
            dog.Eat();      // Output: "Rex is eating." ||  "Rex is munching."

            // explicit typing
            Circle c = new Circle(16.423f);

            // implicit typing
            var cirk = new Circle(88);

            // target-typed new expression
            Circle c2 = new(5);



            // Null Handling Operators and Patterns in C#
            string name = null;
            string[] myArray = null;

            // null check with equality
            if (name == null) { }

            // null coalescing operator
            var displayName = name ?? "Default name";

            // null conditional operator
            name = c2?.Name;

            // null coalescing assignment operator
            name ??= "Some name";

            // pattern matching for null
            if (name is null) { }

            // pattern matching for not null
            if (name is not null) { }

            // null parameter checking
            ArgumentNullException.ThrowIfNull(name, $"this here is null{nameof(name)}");

            string? nameMaybe = ThisMethodReturnsNullMaybe();

            // null forgiving operator
            //Console.WriteLine(nameMaybe!.Length);

            // null-conditional index operator
            var item = myArray?[0];

            // combining null-conditional and null-coalescing
            var result = c2?.Name ?? "default value";



            // custom dictionary
            CustomDictionary cd = new CustomDictionary(4);

            cd.Add(0, "prvi");
            cd.Add(1, "drugi");
            cd.Add(2, "treci");
            cd.Add(3, "cetvrti");

            cd.Remove(2);

            Console.WriteLine($"Dictionary printout:{cd}");
        }

        static string ThisMethodReturnsNullMaybe()
        {
            return null;
        }
    }

}
