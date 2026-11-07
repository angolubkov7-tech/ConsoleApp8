using System;

namespace Medvedev
{
    class Program
    {
        public static bool IFormattable(object obj)
        {
            if (obj is IFormattable)
            {
                IFormattable formattable = obj as IFormattable;
                
                if(formattable != null)
                {
                    Console.WriteLine($"Объект реализует IFormattable.");
                    return true;
                }
            }

            Console.WriteLine();
            return false;
        }

        public static void Main()
        {
            // Тесты
            Console.WriteLine();
            IFormattable(123);

            Console.WriteLine();
            IFormattable(3.14159);

            Console.WriteLine();
            IFormattable(DateTime.Now);

            Console.WriteLine();
            IFormattable("Привет");

            Console.WriteLine();
            IFormattable(new object());

            Console.WriteLine();
            IFormattable(null);
        }
    }
}