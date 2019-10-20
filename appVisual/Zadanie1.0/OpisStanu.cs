using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1._0
{
    public class OpisStanu
    {
        Katalog ksiazka;
        double cena;
        int ilosc;

        public OpisStanu(Katalog ksiazka, int ilosc, double cena)
        {
            this.ksiazka = ksiazka;
            this.cena = cena;
            this.ilosc = ilosc;
            
        }

        public int Ilosc { get => ilosc; set => ilosc = value; }
        public double Cena { get => cena; set => cena = value; }
       
        internal Katalog Ksiazka { get => ksiazka; set => ksiazka = value; }

        public override bool Equals(object obj)
        {
            return obj is OpisStanu stanu &&
                   ksiazka == stanu.ksiazka;
        }
    }
}
