﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1._0;

namespace zadanie2
{
   public class WlasnaSerializacja
    {
        public static void serializacjaWykaz(string path, IEnumerable<Wykaz> wykazy)
        {
            string dane = "";
            foreach (Wykaz wykaz in wykazy)
            {
                dane += wykaz.Info() + "\n";
            }
            System.IO.File.WriteAllText(@path, dane);
        }
        public static void serializacjaKatalog(string path, IEnumerable<Katalog> katalogi)
        {
            string dane = "";
            foreach (Katalog katalog in katalogi)
            {
                dane += katalog.Info() + "\n";
            }
            System.IO.File.WriteAllText(@path, dane);
        }
        public static void serializacjOpisy(string path, IEnumerable<OpisStanu> opisy)
        {
            string dane = "";
            foreach (OpisStanu opis in opisy)
            {
                dane += opis.Info() + "\n";
            }
            System.IO.File.WriteAllText(@path, dane);
        }
        public static void serializacjaZdarzenia(string path, IEnumerable<Zdarzenie> zdarzenia)
        {
            string dane = "";
            foreach (Zdarzenie zdarzenie in zdarzenia)
            {
                dane += zdarzenie.Info() + "\n";
            }
            System.IO.File.WriteAllText(@path, dane);
        }

        public static IEnumerable<Wykaz> deserializacjaWykaz(string path)
        {
            List<Wykaz> wykazy = new List<Wykaz>();
            string[] dane = System.IO.File.ReadAllLines(@path);
            foreach (string linia in dane)
            {
                string[]  pole= linia.Split(',');
                wykazy.Add(new Wykaz(pole[0], pole[1], Int32.Parse(pole[2])));
            }
            return wykazy;
        }
        public static IEnumerable<Katalog> deserializacjaKatalog(string path)
        {
            List<Katalog> katalogi = new List<Katalog>();
            string[] dane = System.IO.File.ReadAllLines(@path);
            foreach (string linia in dane)
            {
                string[] pole = linia.Split(',');
                katalogi.Add(new Katalog(pole[0], pole[1], Int32.Parse(pole[2])));
            }
            return katalogi;
        }
        public static IEnumerable<OpisStanu> deserializacjaOpisStanu(string path)
        {
            List<OpisStanu> opisy = new List<OpisStanu>();
            string[] dane = System.IO.File.ReadAllLines(@path);
            foreach (string linia in dane)
            {
                string[] pole = linia.Split(',');
                opisy.Add(new OpisStanu(new Katalog(pole[0], pole[1], Int32.Parse(pole[2])), Int32.Parse(pole[3]), Double.Parse(pole[4])));
            }
            return opisy;
        }
        public static IEnumerable<Zdarzenie> deserializacjaZdarzenie(string path)
        {
            List<Zdarzenie> zdarzenia = new List<Zdarzenie>();
            string[] dane = System.IO.File.ReadAllLines(@path);
            foreach (string linia in dane)
            {
                string[] pole = linia.Split(',');
                zdarzenia.Add(new Zdarzenie(new Wykaz(pole[0], pole[1], Int32.Parse(pole[2])),new OpisStanu(new Katalog(pole[3],pole[4],Int32.Parse(pole[5])), Int32.Parse(pole[6]), Double.Parse(pole[7])),new DateTime(Int32.Parse(pole[8]), Int32.Parse(pole[9]), Int32.Parse(pole[10])), Int32.Parse(pole[11])));
            }
            return zdarzenia;
        }
    }
}
