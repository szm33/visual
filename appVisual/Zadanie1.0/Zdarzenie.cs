using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1._0
{
    public class Zdarzenie
    {
        int nrTransakcji;
        Wykaz osoba;
        OpisStanu opisKsiazki;
        DateTime data_zakupu;

        public Zdarzenie(Wykaz osoba, OpisStanu opisKsiazki, DateTime data_zakupu, int nrTransakcji)
        {
            this.osoba = osoba;
            this.opisKsiazki = opisKsiazki;
            this.data_zakupu = data_zakupu;
            this.NrTransakcji = nrTransakcji;
        }

        public DateTime Data_zakupu { get => data_zakupu; set => data_zakupu = value; }
        public int NrTransakcji { get => nrTransakcji; set => nrTransakcji = value; }
        internal Wykaz Wypozyczajacy { get => osoba; set => osoba = value; }
        internal OpisStanu OpisKsiazki { get => opisKsiazki; set => opisKsiazki = value; }

        public override string ToString()
        {
            return $"{nameof(nrTransakcji)}: {nrTransakcji}, {nameof(osoba)}: {osoba.ToString()}, {nameof(opisKsiazki)}: {opisKsiazki.ToString()}, {nameof(data_zakupu)}: {data_zakupu}";
        }
    }
}
