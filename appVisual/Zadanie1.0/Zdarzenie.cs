using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1._0
{
    [Serializable]
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

        public string Info()
        {
            return osoba.Info() + ',' + opisKsiazki.Info() + ',' + data_zakupu.Year + ',' + data_zakupu.Month + ',' + data_zakupu.Day + ',' + nrTransakcji;
        }

        public DateTime Data_zakupu { get => data_zakupu; set => data_zakupu = value; }
        public int NrTransakcji { get => nrTransakcji; set => nrTransakcji = value; }
        internal Wykaz Wypozyczajacy { get => osoba; set => osoba = value; }
        internal OpisStanu OpisKsiazki { get => opisKsiazki; set => opisKsiazki = value; }

        public override string ToString()
        {
            return osoba.ToString() + ',' + opisKsiazki.ToString() + ',' + data_zakupu.Year + ',' + data_zakupu.Month + ',' + data_zakupu.Day + ',' + nrTransakcji;

            //return $"{nameof(nrTransakcji)}: {nrTransakcji}, {nameof(osoba)}: {osoba.ToString()}, {nameof(opisKsiazki)}: {opisKsiazki.ToString()}, {nameof(data_zakupu)}: {data_zakupu}";
        }
    }
}
