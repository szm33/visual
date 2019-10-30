using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1._0
{
    public class Wykaz
    {
        private string imie;
        private string nazwisko;
        private int nr;

        public Wykaz(string imie, string nazwisko, int nr)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Nr = nr;
        }

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public int Nr { get => nr; set => nr = value; }

        public override bool Equals(object obj)
        {
            return obj is Wykaz wykaz &&
                   Nr == wykaz.Nr;
        }

        public override string ToString()
        {
            return $"{nameof(imie)}: {imie}, {nameof(nazwisko)}: {nazwisko}, {nameof(nr)}: {nr}";
        }
    }
}
