using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;



namespace Zadanie1._0
{
    public class DataRepository
    {
        private DataContext dane;
        private IDataFiller dataFiller;
        private int nrTransakcji = 1;

        public DataRepository(DataContext dane, IDataFiller dataFiller)
        {
            this.dane = dane;
            this.dataFiller = dataFiller;
        }

        public IEnumerable<Zdarzenie> GetAllZdarzeniaCzytelnika(int nrOsoby)
        {
            List<Zdarzenie> zdarzeniaOsoby = new List<Zdarzenie>();
            foreach (Zdarzenie zdarzenie in GetAllZdarzenie())
            {
                if (zdarzenie.Wypozyczajacy.Nr == nrOsoby)
                {
                    zdarzeniaOsoby.Add(zdarzenie);
                }
            }

            return zdarzeniaOsoby;
        }

        public IEnumerable<Katalog> GetAllKsiazkiAutora(String autor)
        {
            List<Katalog> ksiazki = new List<Katalog>();
            foreach (Katalog ksiazka in GetAllKatalog())
            {
                if (ksiazka.Autor == autor)
                {
                    ksiazki.Add(ksiazka);
                }
            }

            return ksiazki;
        }

        public void FillRepositoryWithDataFiller()
        {
            dataFiller.Fill(dane);
        }
        //kazdy czytelnik moze wystapic raz
        public void AddWykaz(String imie, String nazwisko, int nrOsoby)
        {
            
            if (dane.czytelnicy.FindIndex(i => i.Nr == nrOsoby) == -1)
            {
                dane.czytelnicy.Add(new Wykaz(imie, nazwisko, nrOsoby));
            }
            
        }
        //dana typu ksiazki moze wystapic raz
        //DO UZGODNIENIA! obecnie w Dictionary wartosc klucza zostaje inkrementowana z kazdym dodaniem elementu, rozpoczynajac od elementu 1(wczesniej 0!)
        //remove odbywa sie poprzez podanie wartosciu klucza(byc moze lepiej podawac wartosc idKsiazki ksiazki)
        //obecnie getKatalog odbywa sie poprzez podanie idKsiazki ksiazki
        public void AddKatalog(String tytul, String autor, int idKsiazki)
        {
            if (!dane.ksiazki.ContainsKey(idKsiazki))
            {
                dane.ksiazki.Add(idKsiazki, new Katalog(tytul, autor, idKsiazki));
            }
            
        }
        // opis stanu do danej ksiazki moze byc tylko jeden
        public void AddOpisStanu(double cena, int ilosc, int idKsiazki)
        {
            if(dane.opisy_ksiazek.FindIndex(i => i.Ksiazka.IdKsiazki == idKsiazki) == -1)
            {
                dane.opisy_ksiazek.Add(new OpisStanu(GetKatalog(idKsiazki), ilosc, cena));
            }
        }

        public Zdarzenie CreateDodanieKsiazkiZdarzenie(Wykaz osoba, OpisStanu opisStanu,
            DateTime dateTime)
        {
            return new DodanieKsiazkiZdarzenie(osoba, opisStanu, dateTime, GetNrTransakcji());
        }

        public Zdarzenie CreateDostawaZdarzenie(Wykaz osoba, OpisStanu opisStanu, DateTime dateTime)
        {
            return  new DostawaZdarzenie(osoba, opisStanu, dateTime, GetNrTransakcji());
        }

        public Zdarzenie CreateKupienieKsiazkiZdarzenie(Wykaz osoba, OpisStanu opisStanu,
            DateTime dateTime)
        {
            return new KupienieKsiazkiZdarzenie(osoba, opisStanu, dateTime, GetNrTransakcji());
        }
        //kupno danej ksiazki przez danego cztelnika moze wystapic wiele razy 
        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            dane.zdarzenia.Add(zdarzenie);
        }
        //zwracamy czytelnika o danym numerze(nrOsoby jest unikalny)
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
        //zwracamy ksiazke o danym identyfikatorze
        public Katalog GetKatalog(int idKsiazki)
        {
            foreach (Katalog ksiazka in dane.ksiazki.Values)
            {
                if (ksiazka.IdKsiazki == idKsiazki)
                {
                    return ksiazka;
                }
            }
            return null;
        }
        //zwracamy opis ksiazki o danym identyfikatorze
        public OpisStanu GetOpisStanu(int idKsiazki)
        {
            foreach (OpisStanu opis in dane.opisy_ksiazek)
            {
                if (opis.Ksiazka.IdKsiazki == idKsiazki)
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
        //usuniecie ksiazki o podanym identyfikatorze ktory jest rowny kluczowi w dictionary
        public void RemoveKatalog(int idKsiazki)
        {
            dane.ksiazki.Remove(idKsiazki);
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
        public void UpdateWykaz(int nrOsoby, String imie, String nazwisko)
        {
            RemoveWykaz(GetWykaz(nrOsoby));
            AddWykaz(imie, nazwisko, nrOsoby);
        }

        // aktualizacja ksiazki o danym identyfikatorze
        // PROPOZYCJA!! zamiana klucza w slowniku na GUID i uzycie tego samego GUID w idKsiazki ksiazki
        // ulatwi to przeszukiwanie slownika
        public void UpdateKatalog(String tytul, String autor, int idKsiazki)
        {
            RemoveKatalog(idKsiazki);
            RemoveOpisStanu(GetOpisStanu(idKsiazki));
            AddKatalog(tytul, autor, idKsiazki);

        }
        // aktualizacja opisu ksiazki o danym identyfikatorze
        public void UpdateOpisStanu(int idKsiazki, double cena, int ilosc)
        {
            RemoveOpisStanu(GetOpisStanu(idKsiazki));
            AddOpisStanu(cena, ilosc, idKsiazki);

        }
        // aktualizacja transakcji o danym numerze transakcji
        public void UpdateZdarzenie(int nrTransakcji, Zdarzenie zdarzenie)
        {
            for (int i = 0; i < dane.zdarzenia.Count; i++)
            {
                if(dane.zdarzenia[i].NrTransakcji == nrTransakcji)
                {
                    dane.zdarzenia[i] = zdarzenie;
                }
            }
        }

        public int GetNrTransakcji()
        {
            nrTransakcji++;
            return nrTransakcji;
        }

    }
    
}
