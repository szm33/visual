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
                return w.GetType().Name + ';' + w.Imie + ';' + w.Nazwisko + ';' + w.Nr + ';' + genId;
            }
            else
            {
                return w.GetType().Name + "_ref" + ';' + genId;
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
                Wykaz w = (Wykaz)obj[pole[1]];
                pole.RemoveRange(0, 2);
                return w;
            }
        }


        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public int Nr { get => nr; set => nr = value; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            Wykaz w = (Wykaz)obj;
            return imie == w.imie && nazwisko == w.nazwisko && nr == w.nr;
        }

        public override string ToString()
        {
            return imie + ',' + nazwisko + ',' + nr;
            //return $"{nameof(imie)}: {imie}, {nameof(nazwisko)}: {nazwisko}, {nameof(nr)}: {nr}";
        }
    }
}
