using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
            this.Osoba = osoba;
            this.opisKsiazki = opisKsiazki;
            this.data_zakupu = data_zakupu;
            this.NrTransakcji = nrTransakcji;
        }

        public string Info()
        {
            return Osoba.Info() + ',' + opisKsiazki.Info() + ',' + data_zakupu.Year + ',' + data_zakupu.Month + ',' + data_zakupu.Day + ',' + nrTransakcji;
        }

        static public string Serialize(Zdarzenie z,ObjectIDGenerator generator)
        {
            return z.GetType().Name + ',' + generator.GetId(z.Osoba, out bool firstTime1) + ',' + generator.GetId(z.OpisKsiazki, out bool firstTime2) + ',' + z.Data_zakupu.Year + ',' + z.Data_zakupu.Month + ',' + z.Data_zakupu.Day + ',' + z.NrTransakcji + ',' + generator.GetId(z, out bool firstTime3);
        }

        static public Zdarzenie Deserialize(string [] pole, Dictionary<string, object> obiekty)
        {
            return new Zdarzenie((Wykaz)obiekty[pole[1]], (OpisStanu)obiekty[pole[2]], new DateTime(Int32.Parse(pole[3]), Int32.Parse(pole[4]), Int32.Parse(pole[5])), Int32.Parse(pole[6]));
        }

        public DateTime Data_zakupu { get => data_zakupu; set => data_zakupu = value; }
        public int NrTransakcji { get => nrTransakcji; set => nrTransakcji = value; }
        internal Wykaz Wypozyczajacy { get => Osoba; set => Osoba = value; }
        internal OpisStanu OpisKsiazki { get => opisKsiazki; set => opisKsiazki = value; }
        public Wykaz Osoba { get => osoba; set => osoba = value; }

        public override string ToString()
        {
            return Osoba.ToString() + ',' + opisKsiazki.ToString() + ',' + data_zakupu.Year + ',' + data_zakupu.Month + ',' + data_zakupu.Day + ',' + nrTransakcji;

            //return $"{nameof(nrTransakcji)}: {nrTransakcji}, {nameof(osoba)}: {osoba.ToString()}, {nameof(opisKsiazki)}: {opisKsiazki.ToString()}, {nameof(data_zakupu)}: {data_zakupu}";
        }
    }
}
