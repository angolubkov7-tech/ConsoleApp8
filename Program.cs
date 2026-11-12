using System;
using System.IO;
using System.Text;

namespace Medvedev
{
    class Program
    {
        public static void Main()
        {
            Program p = new Program(); //ссылка на обьект

            Console.Write("Введите путь к файлу: ");
            string patch = Console.ReadLine();

            if(!File.Exists(patch))
            {
                Console.WriteLine("Файл ненайден");
                return;
            }

            string[] lines = File.ReadAllLines(patch, Encoding.UTF8);

            string[] mails = new string[lines.Length];
            int count = 0;

            foreach (string raw in lines)
            {
                string line = raw.Trim();
                if (line.Length == 0) continue;

                p.SearchMail(ref line);
                if(line.Length > 0) mails[count++] = line;

                Array.Resize(ref mails, count);

                Console.Write("Введите путь к выходному файлу: ");
                string outputPath = Console.ReadLine();

                File.WriteAllLines(outputPath, mails, Encoding.UTF8);
            }
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