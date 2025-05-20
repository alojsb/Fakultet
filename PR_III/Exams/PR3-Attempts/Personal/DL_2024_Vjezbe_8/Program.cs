using System.Collections;

// IEnumerable
// yield
// pagination
// dynamic 

namespace DL_2024_Vjezbe_8
{
    // IEnumerable
    public class Automobile : IEnumerable<Automobile>
    {
        private IEnumerable<object> automobiles;

        public IEnumerator<Automobile> GetEnumerator()
        {
            foreach (var auto in automobiles)
            {
                yield return (Automobile)auto;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var stud = new Student();

            var methods = stud.GetType().GetMethods();

            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }

            // enumerator & yield
            // collection initializer syntax
            List<int> items = new List<int> { 3, 1, 5, 2, 4, 6 };

            var x = Testing(items).GetEnumerator();
            x.MoveNext();
            x.MoveNext();
            Console.WriteLine(x.Current);

            var y = Testing(items).GetEnumerator();
            y.MoveNext();
            Console.WriteLine(y.Current);
        }

        static IEnumerable<int> Testing(List<int> numbers)
        {
            foreach (int n in numbers)
            {
                if (n > 3)
                {
                    yield return n;
                }
                else
                {
                    continue;

                    // immediatelly stop the iterator
                    // yield break;
                }
            }
        }
    }
}
