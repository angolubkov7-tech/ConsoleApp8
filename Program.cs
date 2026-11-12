using System;

namespace Medvedev
{
    class Song
    {
        string name;
        string author;
        Song prev;
        
        private string Name(string name)
        {
            this.name = name;
            return name;
        }

        private string Author(string author)
        {
            this.author = author;
            return author;
        }


    }

    class Program
    {

    }
}