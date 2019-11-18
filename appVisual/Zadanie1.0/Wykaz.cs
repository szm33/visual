using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Zadanie1._0
{
    [Serializable]
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

        public string Info()
        {
            return imie + ',' + nazwisko + ',' + nr;
        }

        static public string Serialize(Wykaz w,ObjectIDGenerator generator)
        {
            return w.GetType().Name + ',' + w.Imie + ',' + w.Nazwisko + ',' + w.Nr + ',' + generator.GetId(w,out bool firstTime); 
        }

        static public Wykaz Deserialize(string[] pole)
        {
            return new Wykaz(pole[1], pole[2], Int32.Parse(pole[3]);
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
            return imie + ',' + nazwisko + ',' + nr;
            //return $"{nameof(imie)}: {imie}, {nameof(nazwisko)}: {nazwisko}, {nameof(nr)}: {nr}";
        }
    }
}
