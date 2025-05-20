namespace DL_2024_Vjezbe_4
{
    // bilo je price i o interface ali nisam kucao taj kod

    struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    // part of pattern1
    class ModifyInputResult
    {
        public Position resultPosition { get; set; } = default;
        public bool isValid { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // out
            var userInput = Console.ReadLine();

            if (double.TryParse(userInput, out var parsedUserInput))
            {
                Console.WriteLine(parsedUserInput);
            }

            var result = ModifyInput(10);

            if (result.isValid)
            {
                Console.WriteLine(result.resultPosition);
            }
        }

        // pattern1
        static ModifyInputResult ModifyInput(int input)
        {
            var result = new ModifyInputResult();

            if (input > 0)
            {
                result.resultPosition = new Position(++input, ++input * 2);
                result.isValid = true;
            }

            result.isValid = false;
            return result;
        }

        // pattern2
        static bool ModifyInput(int input, out Position output)
        {
            if (input > 0)
            {
                output = new Position(++input, ++input * 2);
                return true;
            }
            output = default(Position);
            return false;
        }

        // ref
        static void TranslatePosition(ref Position pos)
        {
            pos = new Position();
        }
    }
}
