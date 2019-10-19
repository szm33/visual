using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Zadanie1._0
{
    class DataContext
    {
        public List<Wykaz> czytelnicy;
        public Dictionary<int, Katalog> ksiazki;
        public ObservableCollection<Zdarzenie> zdarzenia;
        public List<OpisStanu> opisy_ksiazek;

        public DataContext(List<Wykaz> czytelnicy, Dictionary<int, Katalog> ksiazki, ObservableCollection<Zdarzenie> zdarzenia, List<OpisStanu> opisy_ksiazek)
        {
            this.czytelnicy = czytelnicy;
            this.ksiazki = ksiazki;
            this.zdarzenia = zdarzenia;
            this.opisy_ksiazek = opisy_ksiazek;
        }
    }
}
