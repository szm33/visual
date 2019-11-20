using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
    [Serializable]
    public class KupienieKsiazkiZdarzenie: Zdarzenie
    {
        public KupienieKsiazkiZdarzenie(Wykaz osoba, OpisStanu opisKsiazki, DateTime data_zakupu, int nrTransakcji) : base(osoba, opisKsiazki, data_zakupu, nrTransakcji)
        {
        }

        public static string Serialize(KupienieKsiazkiZdarzenie z, ObjectIDGenerator generator)
        {
            long genId = generator.GetId(z, out bool firstTime);
            if (firstTime)
            {
                return z.GetType().Name + ';' + Wykaz.Serialize(z.Osoba, generator) + ';' + OpisStanu.Serialize(z.OpisKsiazki, generator) + ';' + z.Data_zakupu.Year + ';' + z.Data_zakupu.Month + ';' + z.Data_zakupu.Day + ';' + z.NrTransakcji + ';' + genId;
            }
            else
            {
                return z.GetType().Name + "_ref" + ';' + genId;
            }
        }

        /* static public Zdarzenie Deserialize(string [] pole, Dictionary<string, object> obiekty)
         {
             return new Zdarzenie((Wykaz)obiekty[pole[1]], (OpisStanu)obiekty[pole[2]], new DateTime(Int32.Parse(pole[3]), Int32.Parse(pole[4]), Int32.Parse(pole[5])), Int32.Parse(pole[6]));
         }*/


        public static Zdarzenie Deserialize(List<string> pole, Dictionary<string, object> obj)
        {
            if (pole[0] == "DodanieKsiazkiZdarzenie")
            {
                pole.RemoveAt(0);
                Zdarzenie z = new KupienieKsiazkiZdarzenie(Wykaz.Deserialize(pole, obj), OpisStanu.Deserialize(pole, obj), new DateTime(Int32.Parse(pole[0]), Int32.Parse(pole[1]), Int32.Parse(pole[2])), Int32.Parse(pole[3]));
                obj.Add(pole[4], z);
                pole.RemoveRange(0, 5);
                return z;
            }
            else
            {
                Zdarzenie z = (KupienieKsiazkiZdarzenie)obj[pole[1]];
                pole.RemoveRange(0, 2);
                return z;
            }
        }
    }
}
