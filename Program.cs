using System;
using System.Linq;

namespace Medvedev
{
    class Program
    {
        public static string Line(string line)
        {
            char[] lines = line.ToCharArray();

            Array.Reverse(lines);
            return new string (lines);
        }

        public static void Main()
        {
            Console.WriteLine("Ввидите строку");
            string line = Console.ReadLine();

            string reversed = Line(line);
            Console.WriteLine($"{reversed}");
        }
    }
}