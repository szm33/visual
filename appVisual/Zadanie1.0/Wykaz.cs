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

        /*static public string Serialize(Wykaz w,ObjectIDGenerator generator)
        {

            return w.GetType().Name + ',' + w.Imie + ',' + w.Nazwisko + ',' + w.Nr + ',' + generator.GetId(w,out bool firstTime); 
        }*/

        static public string Serialize(Wykaz w, ObjectIDGenerator generator)
        {
            long genId = generator.GetId(w, out bool firstTime);
            if (firstTime) {
                return w.GetType().Name + ',' + w.Imie + ',' + w.Nazwisko + ',' + w.Nr + ',' + genId;
            }
            else
            {
                return "" + genId;
            }
        }

       /* static public Wykaz Deserialize(string[] pole)
        {
            return new Wykaz(pole[1], pole[2], Int32.Parse(pole[3]));
        }*/
        static public Wykaz Deserialize(List<string> pole, Dictionary<string,object> obj)
        {
            if (pole[0] == "Wykaz")
            {
                Wykaz w = new Wykaz(pole[1], pole[2], Int32.Parse(pole[3]));
                obj.Add(pole[4], w);
                pole.RemoveRange(0, 5);
                return w;
            }
            else
            {
                pole.RemoveRange(0, 1);
                return (Wykaz)obj[pole[0]];
            }
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
