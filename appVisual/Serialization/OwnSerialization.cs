using System.Collections.Generic;
using System.Runtime.Serialization;
using Zadanie1._0;

namespace zadanie2
{
   public class WlasnaSerializacja
    {
        public static void SerializacjaDataContext(string path, DataContext dataContext)
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

        public static DataContext DeserializacjaDataContext(string path)
        {
            DataContext dataContext = new DataContext();
            string[] dane = System.IO.File.ReadAllLines(@path);
            Dictionary<string, object> obiekty = new Dictionary<string, object>();
            foreach (string linia in dane)
            {
                string[] pole = linia.Split(';');
                switch (pole[0])
                {
                    case "Katalog": 
                    case "Katalog_ref":
                        Katalog katalog = Katalog.Deserialize(new List<string>(pole),obiekty);
                        dataContext.ksiazki.Add(katalog.Id,katalog);
                        break;
                    case "Wykaz":
                    case "Wykaz_ref":
                        Wykaz wykaz = Wykaz.Deserialize(new List<string>(pole),obiekty);
                        dataContext.czytelnicy.Add(wykaz);
                        break;
                    case "OpisStanu":
                    case "OpisStanu_ref":
                        OpisStanu opisStanu = OpisStanu.Deserialize(new List<string>(pole), obiekty);
                        dataContext.opisy_ksiazek.Add(opisStanu);
                        break;
                    case "KupienieKsiazkiZdarzenie":
                    case "KupienieKsiazkiZdarzenie_ref":
                        Zdarzenie kupienieKsiazkiZdarzenie = KupienieKsiazkiZdarzenie.Deserialize(new List<string>(pole), obiekty);
                        dataContext.zdarzenia.Add(kupienieKsiazkiZdarzenie);
                        break;
                    case "DodanieKsiazkiZdarzenie":
                    case "DodanieKsiazkiZdarzenie_ref":
                        Zdarzenie dodanieKsiazkiZdarzenie = DodanieKsiazkiZdarzenie.Deserialize(new List<string>(pole), obiekty);
                        dataContext.zdarzenia.Add(dodanieKsiazkiZdarzenie);
                        break;
                    case "DostawaZdarzenie":
                    case "DostawaZdarzenie_ref":
                        Zdarzenie dostawaZdarzenie = DostawaZdarzenie.Deserialize(new List<string>(pole), obiekty);
                        dataContext.zdarzenia.Add(dostawaZdarzenie);
                        break;
                    case "Zdarzenie":
                    case "Zdarzenie_ref":
                        Zdarzenie zdarzenie = Zdarzenie.Deserialize(new List<string>(pole), obiekty);
                        dataContext.zdarzenia.Add(zdarzenie);
                        break;
                }
            }
            return dataContext;

        }
    }
}
