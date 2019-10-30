using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
    public class KupienieKsiazkiZdarzenie: Zdarzenie
    {
        public KupienieKsiazkiZdarzenie(Wykaz osoba, OpisStanu opisKsiazki, DateTime data_zakupu, int nrTransakcji) : base(osoba, opisKsiazki, data_zakupu, nrTransakcji)
        {
        }
    }
}
