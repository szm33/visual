using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Zadanie1._0
{
    [Serializable]
    public class OpisStanu
    {
        Katalog ksiazka;
        double cena;
        int ilosc;

        public OpisStanu(Katalog ksiazka, int ilosc, double cena)
        {
            this.ksiazka = ksiazka;
            this.ilosc = ilosc;
            this.cena = cena;

        }

        public string Info()
        {
            return ksiazka.Info() + ',' + ilosc + ',' + cena;
        }

        /* static public string Serialize(OpisStanu o,ObjectIDGenerator generator)
         {
             return o.GetType().Name + ',' + generator.GetId(o.Ksiazka, out bool firstTime1) + o.Ilosc + ',' + o.Cena + ',' + generator.GetId(o, out bool firstTime2);
         }*/

        static public string Serialize(OpisStanu o, ObjectIDGenerator generator)
        {
            long genId = generator.GetId(o, out bool firstTime);
            if (firstTime)
            {
                return o.GetType().Name + ';' + Katalog.Serialize(o.ksiazka,generator) + ';' + o.Ilosc + ';' + o.Cena + ';' + genId;
            }
            else
            {
                return o.GetType().Name + "_ref" + ';' + genId;
            }
        }

        /* static public OpisStanu Deserialize(string[] pole, Dictionary<string, object> obiekty)
         {
             return new OpisStanu((Katalog)obiekty[pole[1]], Int32.Parse(pole[2]), Double.Parse(pole[3]));
         }*/

        static public OpisStanu Deserialize(List<string> pole, Dictionary<string, object> obj)
        {
            if (pole[0] == "OpisStanu")
            {
                /*string[] poleKatalog = pole.Where(p => p != pole[0]).ToArray();*/
                pole.RemoveAt(0);
                OpisStanu o = new OpisStanu(Katalog.Deserialize(pole,obj), Int32.Parse(pole[0]), Double.Parse(pole[1]));
                obj.Add(pole[2], o);
                pole.RemoveRange(0, 3);
                return o;
            }
            else
            {
                OpisStanu o = (OpisStanu)obj[pole[1]];
                pole.RemoveRange(0, 2);
                return o;
            }
        }

        public int Ilosc { get => ilosc; set => ilosc = value; }
        public double Cena { get => cena; set => cena = value; }
       
        internal Katalog Ksiazka { get => ksiazka; set => ksiazka = value; }

        public override bool Equals(object obj)
        {
            return obj is OpisStanu stanu &&
                   ksiazka == stanu.ksiazka;
        }

        public override string ToString()
        {
            return ksiazka.ToString() + ',' + ilosc + ',' + cena;
            //return $"{nameof(ksiazka)}: {ksiazka.ToString()}, {nameof(cena)}: {cena}, {nameof(ilosc)}: {ilosc}";
        }
    }
}
