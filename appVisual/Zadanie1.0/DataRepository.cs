using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;



namespace Zadanie1._0
{
    public class DataRepository
    {
        private DataContext dane;
        private IDataFiller dataFiller;

        public DataRepository(DataContext dane, IDataFiller dataFiller)
        {
            this.dane = dane;
            this.dataFiller = dataFiller;
        }

        public void FillRepositoryWithDataFiller()
        {
            dataFiller.Fill(dane);
        }
        //kazdy czytelnik moze wystapic raz
        public void AddWykaz(Wykaz wykaz)
        {
            if (!dane.czytelnicy.Contains(wykaz))
            {
                dane.czytelnicy.Add(wykaz);
            }
            
        }
        //dana typu ksiazki moze wystapic raz
        //DO UZGODNIENIA! obecnie w Dictionary wartosc klucza zostaje inkrementowana z kazdym dodaniem elementu, rozpoczynajac od elementu 1(wczesniej 0!)
        //remove odbywa sie poprzez podanie wartosciu klucza(byc moze lepiej podawac wartosc id ksiazki)
        //obecnie getKatalog odbywa sie poprzez podanie id ksiazki
        public void AddKatalog(Katalog katalog)
        {
            if (!dane.ksiazki.ContainsValue(katalog))
            {
                int key=dane.ksiazki.Count + 1;
                while(dane.ksiazki.ContainsKey(key))
                {
                    key++;
                }
                dane.ksiazki.Add(key, katalog);
            }
            
        }
        // opis stanu do danej ksiazki moze byc tylko jeden
        public void AddOpisStanu(OpisStanu opis)
        {
            if(!dane.opisy_ksiazek.Contains(opis) && dane.ksiazki.ContainsValue(opis.Ksiazka))
            {
                dane.opisy_ksiazek.Add(opis);
            }
        }
        //kupno danej ksiazki przez danego cztelnika moze wystapic wiele razy 
        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            if (dane.opisy_ksiazek.Contains(zdarzenie.OpisKsiazki) && dane.czytelnicy.Contains(zdarzenie.Wypozyczajacy))
            {
                dane.zdarzenia.Add(zdarzenie);
            }
        }
        //zwracamy czytelnika o danym numerze(nr jest unikalny)
        public Wykaz GetWykaz(int nr)
        {
            foreach(Wykaz czytelnik in dane.czytelnicy)
            {
                if (czytelnik.Nr == nr)
                {
                    return czytelnik;
                }
            }
            return null;
        }
        //zwracamy ksiazke o danym identyfikatorze
        public Katalog GetKatalog(int id)
        {
            foreach (Katalog ksiazka in dane.ksiazki.Values)
            {
                if (ksiazka.Id == id)
                {
                    return ksiazka;
                }
            }
            return null;
        }
        //zwracamy opis ksiazki o danym identyfikatorze
        public OpisStanu GetOpisStanu(int id)
        {
            foreach (OpisStanu opis in dane.opisy_ksiazek)
            {
                if (opis.Ksiazka.Id == id)
                {
                    return opis;
                }
            }
            return null;
        }
        //zwracamy transakcje o danym numerze transakcji
        public Zdarzenie GetZdarzenie(int nrTransakcji)
        {
            foreach (Zdarzenie zdarzenie in dane.zdarzenia)
            {
                if(zdarzenie.NrTransakcji == nrTransakcji)
                {
                    return zdarzenie;
                }
            }
            return null;
        }
        public IEnumerable<Wykaz> GetAllWykaz()
        {
            return dane.czytelnicy;
        }

        public IEnumerable<Katalog> GetAllKatalog()
        {
            return dane.ksiazki.Values;
        }  
        public IEnumerable<OpisStanu> GetAllOpisStanu()
        {
            return dane.opisy_ksiazek;
        }
        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return dane.zdarzenia;
        }
        public void RemoveWykaz(Wykaz czytelnik)
        {
            dane.czytelnicy.Remove(czytelnik);
        }
        //usuniecie ksiazki o podanym kluczu w kolekcji
        public void RemoveKatalog(int klucz)
        {
            dane.ksiazki.Remove(klucz);
        }
        public void RemoveOpisStanu(OpisStanu opis)
        {
            dane.opisy_ksiazek.Remove(opis);
        }
        public void RemoveZdarzenie(Zdarzenie zdarzenie)
        {
            dane.zdarzenia.Remove(zdarzenie);
        }
        // aktualizacja czytelnika o danym numerze
        public void UpdateWykaz(int nr, Wykaz czytelnik)
        {

            for (int i = 0; i < dane.czytelnicy.Count; i++)
            {
                if (dane.czytelnicy[i].Nr == nr)
                {
                    dane.czytelnicy.Insert(i, czytelnik);
                    break;
                }
            }
        }
        // aktualizacja ksiazki o danym identyfikatorze
        // PROPOZYCJA!! zamiana klucza w slowniku na GUID i uzycie tego samego GUID w id ksiazki
        // ulatwi to przeszukiwanie slownika
        public void UpdateKatalog(int id, Katalog nowaKsiazka)
        {
//            int elements = dane.ksiazki.Count - 1;
//            for(int index = 0; index < elements; index++)
//            {
////                if (dane.ksiazki)
////                {
////                    int idDictionary = keyValuePair.Key;
////                    dane.ksiazki.Remove(idDictionary);
////                    AddKatalog(nowaKsiazka);
////                }
//            }

        }
        // aktualizacja opisu ksiazki o danym identyfikatorze
        // DO UZGODNIENIA!!! OpisStanu nie zawiera w sobie zadnego identyfikatora, w tym przypadku odwolujemy sie do pozycji w kolecji
        // byc moze lepiej dodac pole id w klasie OpisStanu
        public void UpdateOpisStanu(int id, OpisStanu opis)
        {
            for (int i = 0; i < dane.opisy_ksiazek.Count; i++)
            {
                if(dane.opisy_ksiazek[i].Ksiazka.Id == id)
                {
                    dane.opisy_ksiazek[i] = opis;
//                    dane.opisy_ksiazek.Insert(i, opis);
                }
            }
        }
        // aktualizacja transakcji o danym numerze transakcji
        public void UpdateZdarzenie(int nrTransakcji, Zdarzenie zdarzenie)
        {
            for (int i = 0; i < dane.zdarzenia.Count; i++)
            {
                if(dane.zdarzenia[i].NrTransakcji == nrTransakcji)
                {
                    dane.zdarzenia[i] = zdarzenie;
//                    dane.zdarzenia.Insert(i, zdarzenie);
                }
            }
        }

    }
    
}
