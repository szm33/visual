using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
    public class DostawaZdarzenie: Zdarzenie
    {
        public DostawaZdarzenie(Wykaz osoba, OpisStanu opisKsiazki, DateTime data_zakupu, int nrTransakcji) : base(osoba, opisKsiazki, data_zakupu, nrTransakcji)
        {
        }
    }
}
