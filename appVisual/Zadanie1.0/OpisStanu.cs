using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1._0
{
    class OpisStanu
    {
        Katalog ksiazka;
        DateTime data_wypozyczenia;
        double cena;
        int ilosc;

        public OpisStanu(Katalog ksiazka, DateTime data_wypozyczenia, double cena, int ilosc)
        {
            this.ksiazka = ksiazka;
            this.data_wypozyczenia = data_wypozyczenia;
            this.cena = cena;
            this.ilosc = ilosc;
        }

        public DateTime Data_wypozyczenia { get => data_wypozyczenia; set => data_wypozyczenia = value; }
        public double Cena { get => cena; set => cena = value; }
        public int Ilosc { get => ilosc; set => ilosc = value; }
        internal Katalog Ksiazka { get => ksiazka; set => ksiazka = value; }
    }
}
