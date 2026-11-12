using System;
using System.IO;

namespace Medvedev
{
    class Program
    {
        public static void Main()
        {
            Program p = new Program(); //ссылка на обьект

            Console.Write("Введите путь к файлу: ");
            string patch = Console.ReadLine();

            string content = Reading(patch);

            string[] lines = content.Split('\n');
            for (int i = 0;  i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (line.Length == 0) continue;

                p.SearchMail(ref line);
                Console.WriteLine(line);
            }


        
        }

        public static string Reading(string patch)
        {
            if(!File.Exists(patch)) { Console.WriteLine("Файл не найден"); }
            
            return File.ReadAllText(patch);
        }

        public void SearchMail(ref string s)
        {
            int pos = s.IndexOf('#');
            if(pos >= 0)
            {
                s = s.Substring(pos + 1).Trim();
            }
            else { s = ""; }
        }
    }
}