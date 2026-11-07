using System;
using System.IO;

namespace Medvede 
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Ввидите путь к файлу: ");
            string input = Console.ReadLine();

            if (!File.Exists(input))
            {
                Console.WriteLine("Файл не найден. Завершение работы.");
            }

            else
            {

                string output = File.ReadAllText(input);

                string upper = output.ToUpper();

                Console.Write("Ввидите имя выходного файла: ");
                string file = Console.ReadLine();

                File.WriteAllText(file, upper);
            }
        }
    }
}
