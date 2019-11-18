using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

        public void SerializacjaDataContext(string path, DataContext dataContext)
        {
            ObjectIDGenerator generator = new ObjectIDGenerator();
            string dane = "";
            foreach (Katalog katalog in dataContext.ksiazki.Values)
            {
                dane += Katalog.Serialize(katalog,generator) + "\n";
            }
            foreach (Wykaz wykaz in dataContext.czytelnicy)
            {
                dane += Wykaz.Serialize(wykaz,generator) + "\n";
            }
            foreach (OpisStanu opis in dataContext.opisy_ksiazek)
            {
                dane += OpisStanu.Serialize(opis,generator) + "\n";
            }
            foreach (Zdarzenie zdarzenie in dataContext.zdarzenia)
            {
                dane += Zdarzenie.Serialize(zdarzenie,generator) + "\n";
            }
            System.IO.File.WriteAllText(@path, dane);
        }

        public DataContext DeserializacjaDataContext(string path)
        {
            DataContext dataContext = new DataContext();
            string[] dane = System.IO.File.ReadAllLines(@path);
            Dictionary<string, object> obiekty = new Dictionary<string, object>();
            foreach (string linia in dane)
            {
                string[] pole = linia.Split(',');
                switch (pole[0])
                {
                    case "Katalog": 
                    case "Katalog_ref":
                        /*Katalog katalog = new Katalog(pole[1], pole[2], Int32.Parse(pole[3]));*/
                        Katalog katalog = Katalog.Deserialize(new List<string>(pole),obiekty);
                        dataContext.ksiazki.Add(katalog.Id,katalog);
                      /*  obiekty.Add(pole[4], katalog);*/
                        break;

                    case "Wykaz":
                    case "Wykaz_ref":
                        /*Wykaz wykaz = new Wykaz(pole[1], pole[2], Int32.Parse(pole[3]));*/
                        Wykaz wykaz = Wykaz.Deserialize(new List<string>(pole),obiekty);
                        dataContext.czytelnicy.Add(wykaz);
                       /* obiekty.Add(pole[4], wykaz);*/
                        break;

                    case "OpisStanu":
                    case "OpisStanu_ref":
                        /* OpisStanu opisStanu = new OpisStanu((Katalog)obiekty[pole[1]], Int32.Parse(pole[2]), Double.Parse(pole[3]));*/
                        OpisStanu opisStanu = OpisStanu.Deserialize(new List<string>(pole), obiekty);
                        dataContext.opisy_ksiazek.Add(opisStanu);
                       /* obiekty.Add(pole[4], opisStanu);*/
                        break;

                    case "Zdarzenie":
                    case "Zdarzenie_ref":
                        Zdarzenie zdarzenie = Zdarzenie.Deserialize(new List<string>(pole), obiekty);
                        dataContext.zdarzenia.Add(zdarzenie);
                        /*obiekty.Add(pole[7], zdarzenie);*/
                        break;
                }
            }
            return dataContext;

        }


        public void SerializacjaRekurencyja(string path, Rekurencja rekurencja)
        {
            ObjectIDGenerator generator = new ObjectIDGenerator();
            string dane = "";
            foreach (A a in rekurencja.aElements)
            {
                dane += A.Serialize(a, generator) + "\n";
            }
            foreach (B b in rekurencja.bElements)
            {
                dane += B.Serialize(b, generator) + "\n";
            }
            foreach (C c in rekurencja.cElements)
            {
                dane += C.Serialize(c, generator) + "\n";
            }
            System.IO.File.WriteAllText(@path, dane);
        }

        public Rekurencja DeserializacjaRekurencja(string path)
        {
            Rekurencja rekurencja = new Rekurencja();
            string[] dane = System.IO.File.ReadAllLines(@path);
            Dictionary<string, object> obiekty = new Dictionary<string, object>();
            foreach (string linia in dane)
            {
                string[] pole = linia.Split(',');
                switch (pole[0])
                {
                    case "A":
                    case "A_ref":
                        A a = A.Deserialize(new List<string>(pole), obiekty);
                        rekurencja.aElements.Add(a);
                        break;

                    case "B":
                    case "B_ref":
                        B b = B.Deserialize(new List<string>(pole), obiekty);
                        rekurencja.bElements.Add(b);
                        break;

                    case "C":
                    case "C_ref":
                        C c = C.Deserialize(new List<string>(pole), obiekty);
                        rekurencja.cElements.Add(c);
                        break;
                }
            }
            return rekurencja;

        }
    }
}
