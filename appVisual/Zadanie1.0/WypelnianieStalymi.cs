using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
    class WypelnianieStalymi : IDataFiller
    {
        private int ilosc;

        public WypelnianieStalymi(int ilosc)
        {
            this.ilosc = ilosc;
        }

        public void Fill(DataContext data)
        {
           for(int i = 0; i < ilosc; i++)
            {
                data.ksiazki.Add(i, new Katalog("książka" + i, "autor" + i, i));
                data.czytelnicy.Add(new Wykaz("imię" + i, "nazwisko" + i, i));
                data.opisy_ksiazek.Add(new OpisStanu(data.ksiazki[i], i + 1, i + 0.5));
                data.zdarzenia.Add(new Zdarzenie(data.czytelnicy[i], data.opisy_ksiazek[i], new DateTime(),ilosc-i,i));
            }
            

        }
    }
}
