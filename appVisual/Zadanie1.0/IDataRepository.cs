using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
    public interface IDataRepository
    {
        void FillRepositoryWithDataFiller();
        Wykaz CreateWykaz(string imie, string nazwisko, int nr);
        Katalog CreatKatalog(string tytul, string autor, int id);
        OpisStanu CreateOpisStanu(Katalog ksiazka, int ilosc, double cena);
        DostawaZdarzenie CreateDostawaZdarzenie(Wykaz osoba, OpisStanu opisStanu, DateTime data);
        DodanieKsiazkiZdarzenie CreateDodanieKsiazkiZdarzenie(Wykaz osoba, OpisStanu opisStanu, DateTime data);
        KupienieKsiazkiZdarzenie CreateKupienieKsiazkiZdarzenie(Wykaz osoba, OpisStanu opisStanu, DateTime data);
        void AddWykaz(Wykaz wykaz);
        void AddKatalog(Katalog katalog);
        void AddOpisStanu(OpisStanu opis);
        void AddZdarzenie(Zdarzenie zdarzenie);
        Wykaz GetWykaz(int nrOsoby);
        Katalog GetKatalog(int idKsiazki);
        OpisStanu GetOpisStanu(int idKsiazki);
        Zdarzenie GetZdarzenie(int nrTransakcji);
        IEnumerable<Wykaz> GetAllWykaz();
        IEnumerable<Katalog> GetAllKatalog();
        IEnumerable<OpisStanu> GetAllOpisStanu();
        IEnumerable<Zdarzenie> GetAllZdarzenie();
        void RemoveWykaz(Wykaz czytelnik);
        void RemoveKatalog(int id);
        void RemoveOpisStanu(OpisStanu opis);
        void RemoveZdarzenie(Zdarzenie zdarzenie);
        void UpdateWykaz(int nrOsoby, Wykaz osoba);
        void UpdateKatalog(int idKsiazki, Katalog nowaKsiazka);
        void UpdateOpisStanu(int idKsiazki, OpisStanu opis);
        void UpdateZdarzenie(int nrTransakcji, Zdarzenie zdarzenie);
        int GetNrTransakcji();

    }
}
