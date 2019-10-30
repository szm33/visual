using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
    public class WypelnianieLosowe : IDataFiller
    {
        private int liczbaDanych;
        public WypelnianieLosowe(int liczbaDanych)
        {
            this.liczbaDanych = liczbaDanych;
        }
        public void Fill(DataContext data)
        {
            Random random = new Random();
            for (int i = 0; i < liczbaDanych; i++)
            {
                data.ksiazki.Add(i, new Katalog("książka" + random.Next(0,100), "autor" + random.Next(0, 100), i));
                data.czytelnicy.Add(new Wykaz("imię" + random.Next(0, 100), "nazwisko" + random.Next(0, 100), i));
                data.opisy_ksiazek.Add(new OpisStanu(data.ksiazki[i], random.Next(0, 100), random.NextDouble() *100.0) );
                data.zdarzenia.Add(new Zdarzenie(data.czytelnicy[i], data.opisy_ksiazek[i], new DateTime(), i));
            }
        }
    }
}
