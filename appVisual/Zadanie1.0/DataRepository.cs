using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;



namespace Zadanie1._0
{
    public class DataRepository: IDataRepository
    {
        private DataContext dane;
        private IDataFiller dataFiller;
        private int idTransakcji = 1;

        public DataRepository(DataContext dane, IDataFiller dataFiller)
        {
            this.dane = dane;
            this.dataFiller = dataFiller;

            dane.zdarzenia.CollectionChanged += OnZdarzenieAdded;
        }

        public void FillRepositoryWithDataFiller()
        {
            dataFiller.Fill(dane);
        }

        public Wykaz CreateWykaz(string imie, string nazwisko, int nr)
        {
            return new Wykaz(imie, nazwisko, nr);
        }

        public Katalog CreatKatalog(string tytul, string autor, int id)
        {
            return new Katalog(tytul, autor, id);
        }

        public OpisStanu CreateOpisStanu(Katalog ksiazka, int ilosc, double cena)
        {
            return new OpisStanu(ksiazka, ilosc, cena);
        }

        public DostawaZdarzenie CreateDostawaZdarzenie(Wykaz osoba, OpisStanu opisStanu, DateTime data)
        {
            return new DostawaZdarzenie(osoba, opisStanu, data, GetNrTransakcji());
        }

        public DodanieKsiazkiZdarzenie CreateDodanieKsiazkiZdarzenie(Wykaz osoba, OpisStanu opisStanu, DateTime data)
        {
            return new DodanieKsiazkiZdarzenie(osoba, opisStanu, data, GetNrTransakcji());
        }

        public KupienieKsiazkiZdarzenie CreateKupienieKsiazkiZdarzenie(Wykaz osoba, OpisStanu opisStanu, DateTime data)
        {
            return new KupienieKsiazkiZdarzenie(osoba, opisStanu, data, GetNrTransakcji());
        }


        public void AddWykaz(Wykaz wykaz)
        {
            if (!dane.czytelnicy.Contains(wykaz))
            {
                dane.czytelnicy.Add(wykaz);
            }
            
        }

        public void AddKatalog(Katalog katalog)
        {
            if (!dane.ksiazki.ContainsValue(katalog))
            {
                dane.ksiazki.Add(katalog.Id, katalog);
            }
            
        }

        public void AddOpisStanu(OpisStanu opis)
        {
            if(!dane.opisy_ksiazek.Contains(opis) && dane.ksiazki.ContainsValue(opis.Ksiazka))
            {
                dane.opisy_ksiazek.Add(opis);
            }
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            if (dane.opisy_ksiazek.Contains(zdarzenie.OpisKsiazki) && dane.czytelnicy.Contains(zdarzenie.Wypozyczajacy))
            {
                dane.zdarzenia.Add(zdarzenie);
            }
        }

        public Wykaz GetWykaz(int nrOsoby)
        {
            foreach(Wykaz czytelnik in dane.czytelnicy)
            {
                if (czytelnik.Nr == nrOsoby)
                {
                    return czytelnik;
                }
            }
            return null;
        }

        public Katalog GetKatalog(int idKsiazki)
        {
            foreach (Katalog ksiazka in dane.ksiazki.Values)
            {
                if (ksiazka.Id == idKsiazki)
                {
                    return ksiazka;
                }
            }
            return null;
        }

        public OpisStanu GetOpisStanu(int idKsiazki)
        {
            foreach (OpisStanu opis in dane.opisy_ksiazek)
            {
                if (opis.Ksiazka.Id == idKsiazki)
                {
                    return opis;
                }
            }
            return null;
        }

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

        public void RemoveKatalog(int id)
        {
            dane.ksiazki.Remove(id);
        }
        public void RemoveOpisStanu(OpisStanu opis)
        {
            dane.opisy_ksiazek.Remove(opis);
        }
        public void RemoveZdarzenie(Zdarzenie zdarzenie)
        {
            dane.zdarzenia.Remove(zdarzenie);
        }

        public void UpdateWykaz(int nrOsoby, Wykaz osoba)
        {
            RemoveWykaz(GetWykaz(nrOsoby));
            AddWykaz(osoba);
        }

        public void UpdateKatalog(int idKsiazki, Katalog nowaKsiazka)
        {
            RemoveKatalog(idKsiazki);
            RemoveOpisStanu(GetOpisStanu(idKsiazki));
            AddKatalog(nowaKsiazka);
        }

        public void UpdateOpisStanu(int idKsiazki, OpisStanu opis)
        {
            RemoveOpisStanu(GetOpisStanu(idKsiazki));
            AddOpisStanu(opis);
        }

        public void UpdateZdarzenie(int nrTransakcji, Zdarzenie zdarzenie)
        {
            RemoveZdarzenie(GetZdarzenie(nrTransakcji));
            AddZdarzenie(zdarzenie);
        }

        public int GetNrTransakcji()
        {
            idTransakcji++;
            return idTransakcji;
        }

        public void OnZdarzenieAdded(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Zdarzenie dodane!");
        }
    }
    
}
