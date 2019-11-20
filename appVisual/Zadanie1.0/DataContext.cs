using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Zadanie1._0
{
    [Serializable]
    public class DataContext
    {
        public List<Wykaz> czytelnicy;
        public Dictionary<int, Katalog> ksiazki;
        public ObservableCollection<Zdarzenie> zdarzenia;
        public List<OpisStanu> opisy_ksiazek;

        public DataContext()
        {
            czytelnicy = new List<Wykaz>();
            ksiazki = new Dictionary<int,Katalog>();
            opisy_ksiazek = new List<OpisStanu>();
            zdarzenia = new ObservableCollection<Zdarzenie>();
        }

        public DataContext(List<Wykaz> czytelnicy, Dictionary<int, Katalog> ksiazki, ObservableCollection<Zdarzenie> zdarzenia, List<OpisStanu> opisy_ksiazek)
        {
            this.czytelnicy = czytelnicy;
            this.ksiazki = ksiazki;
            this.zdarzenia = zdarzenia;
            this.opisy_ksiazek = opisy_ksiazek;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            DataContext dc = (DataContext)obj;
            return czytelnicy.SequenceEqual(dc.czytelnicy) && ksiazki.SequenceEqual(dc.ksiazki) && zdarzenia.SequenceEqual(dc.zdarzenia) && opisy_ksiazek.SequenceEqual(dc.opisy_ksiazek);
        }   
    }
}
