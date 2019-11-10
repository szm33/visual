using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1._0;

namespace zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            Katalog k1 = new Katalog("tytul", "autor", 1);
            Katalog k2 = new Katalog("tytul2", "autor2", 2);
            string path= "katalogi.bin";
            SerialClass<Katalog>.Serialize(path, k1);
            SerialClass<Katalog>.Serialize(path, k2);
        }
    }
}
