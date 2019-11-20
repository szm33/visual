using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
     public class DateService
    {
        private IDataRepository repo;

        public DateService(IDataRepository repo)
        {
            this.repo = repo;
        }

        public void KupienieKsiazki(int nrOsoby, int idKsiazki, int ile)
        {
            int iloscKsiazek = repo.GetOpisStanu(idKsiazki).Ilosc;
            double cenaKsiazki = repo.GetOpisStanu(idKsiazki).Cena;
            if (iloscKsiazek >= ile)
            {
                repo.UpdateOpisStanu(idKsiazki, repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), iloscKsiazek - ile, cenaKsiazki));
                repo.AddZdarzenie(repo.CreateKupienieKsiazkiZdarzenie(repo.GetWykaz(nrOsoby), repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), iloscKsiazek - ile, cenaKsiazki), DateTime.Now.Date));
            }
        }
        public void DodanieKsiazki(int nrOsoby, int idKsiazki, String tytul, String autor)
        {
            if (repo.GetKatalog(idKsiazki) == null)
            {
                repo.AddKatalog(repo.CreatKatalog(tytul, autor, idKsiazki));
                repo.AddOpisStanu(repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), 0, 0.0));
                repo.AddZdarzenie(repo.CreateDodanieKsiazkiZdarzenie(repo.GetWykaz(nrOsoby), repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), 0, 0.0), DateTime.Now.Date));
            }
        }

        public void DostawaKsiazki(int nrOsoby, int idKsiazki, int ilosc, double cena)
        {
            if (repo.GetKatalog(idKsiazki) != null)
            {
                int iloscObecna = repo.GetOpisStanu(idKsiazki).Ilosc;
                repo.UpdateOpisStanu(idKsiazki, repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), iloscObecna + ilosc, cena));
                repo.AddZdarzenie(repo.CreateDostawaZdarzenie(repo.GetWykaz(nrOsoby), repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), iloscObecna + ilosc, cena), DateTime.Now.Date));
            }
        }

        public String InformationAboutWykaz(int nrOsoby)
        {
            return repo.GetWykaz(nrOsoby).ToString();
        }

        public String InformationAboutKatalog(int idKsiazki)
        {
            return repo.GetKatalog(idKsiazki).ToString();
        }

        public String InformationAboutOpisStanu(int idKsiazki)
        {
            return repo.GetOpisStanu(idKsiazki).ToString();
        }

        public String InformationAboutZdarzenie(int nrTransakcji)
        {
            return repo.GetZdarzenie(nrTransakcji).ToString();
        }

    }
}
