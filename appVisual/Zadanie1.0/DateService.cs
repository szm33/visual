using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
     class DateService
    {
        private IDataRepository repo;

        public DateService(IDataRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<OpisStanu> DostepneKsiazki()
        {
            return repo.GetAllOpisStanu();
        }

        public String TransakcjeCzytelnika(int nrOsoby)
        {
            return repo.GetAllZdarzeniaCzytelnika(nrOsoby).ToString();
        }
        public void KupKsiazke(int nrOsoby, int idKsiazki, int ile)
        {
            int iloscKsiazek = repo.GetOpisStanu(idKsiazki).Ilosc;
            double cenaKsiazki = repo.GetOpisStanu(idKsiazki).Cena;
            if (iloscKsiazek >= ile)
            {
                repo.UpdateOpisStanu(idKsiazki, cenaKsiazki, iloscKsiazek);
                repo.AddZdarzenie(repo.CreateKupienieKsiazkiZdarzenie(repo.GetWykaz(nrOsoby), repo.GetOpisStanu(idKsiazki), DateTime.Now));
            }

        }
        public void DodanieKsiazki(int nrOsoby, int idKsiazki, String tytul, String autor)
        {
            if (repo.GetKatalog(idKsiazki) == null)
            {
                repo.AddKatalog(tytul, autor, idKsiazki);
                repo.AddOpisStanu(0.0, 0, idKsiazki);
                repo.AddZdarzenie(repo.CreateDodanieKsiazkiZdarzenie(repo.GetWykaz(nrOsoby), repo.GetOpisStanu(idKsiazki), DateTime.Now));
            }

        }

        public void DostawaKsiazki(int nrOsoby, int idKsiazki, int ilosc, int cena)
        {
            if (repo.GetKatalog(idKsiazki) != null)
            {
                repo.UpdateOpisStanu(idKsiazki, cena, ilosc);
                repo.AddZdarzenie(repo.CreateDostawaZdarzenie(repo.GetWykaz(nrOsoby), repo.GetOpisStanu(idKsiazki), DateTime.Now));
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

        public string KsiazkiAutora(string autor)
        {
            return repo.GetAllKsiazkiAutora(autor).ToString();
        }
    }
}
