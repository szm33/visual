using System;

namespace appVisual
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OpisStanu o = new OpisStanu(new Katalog("s","s",2),new DateTime(),12,22);
            Katalog k=o.Ksiazka;
        }
    }
}
