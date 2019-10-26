using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
    public interface IDataRepository
    {
        IEnumerable<Zdarzenie> GetAllZdarzeniaCzytelnika(int nrOsoby);
        IEnumerable<Katalog> GetAllKsiazkiAutora(String autor);
        void FillRepositoryWithDataFiller();
        void AddWykaz(String imie, String nazwisko, int nrOsoby);
        void AddKatalog(String tytul, String autor, int idKsiazki);
        void AddOpisStanu(double cena, int ilosc, int idKsiazki);

        Zdarzenie CreateDodanieKsiazkiZdarzenie(Wykaz osoba, OpisStanu opisStanu,
            DateTime dateTime);

        Zdarzenie CreateDostawaZdarzenie(Wykaz osoba, OpisStanu opisStanu, DateTime dateTime);

        Zdarzenie CreateKupienieKsiazkiZdarzenie(Wykaz osoba, OpisStanu opisStanu,
            DateTime dateTime);

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
        void RemoveKatalog(int idKsiazki);
        void RemoveOpisStanu(OpisStanu opis);
        void RemoveZdarzenie(Zdarzenie zdarzenie);
        void UpdateWykaz(int nrOsoby, String imie, String nazwisko);
        void UpdateKatalog(String tytul, String autor, int idKsiazki);
        void UpdateOpisStanu(int idKsiazki, double cena, int ilosc);
        void UpdateZdarzenie(int nrTransakcji, Zdarzenie zdarzenie);


    }
}
