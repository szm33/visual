using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
    class WypelnianieStalymi : IDataFiller
    {
        public void Fill(DataContext data)
        {
            int ilosc = 5;
           for(int i = 0; i < ilosc; i++)
            {
                data.ksiazki.Add(i, new Katalog("książka" + i, "autor" + i, i));
                data.czytelnicy.Add(new Wykaz("imię" + i, "nazwisko" + i, i));
                data.opisy_stanow.Add(new OpisStanu(data.ksiazki[i], new DateTime(2000+i,i%12+1,i%28+1), i + 0.5, i + 1));
                data.zdarzenia.Add(new Zdarzenie(data.czytelnicy[i], data.opisy_stanow[i], new DateTime()));
            }
            

        }
    }
}
