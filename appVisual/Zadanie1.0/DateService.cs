using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
     class DateService
    {
        private IDataRepository repo;

        private int DataServiceOpperations { get; set; }

        public DateService(IDataRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<OpisStanu> DostepneKsiazki()
        {
            return repo.GetAllOpisStanu();
        }

        public IEnumerable<Zdarzenie> TransakcjeCzytelnika(Wykaz czytelnik)
        {
            List<Zdarzenie> zdarzenia = new List<Zdarzenie>();
            foreach ( Zdarzenie zdarzenie in repo.GetAllZdarzenie())
            {
                if(Equals(zdarzenie.Wypozyczajacy, czytelnik))
                {
                    zdarzenia.Add(zdarzenie);
                }
            }
            return zdarzenia;
        }
        public void KupienieKsiazki(int nrOsoby, int idKsiazki, int ile)
        {
            int iloscKsiazek = repo.GetOpisStanu(idKsiazki).Ilosc;
            double cenaKsiazki = repo.GetOpisStanu(idKsiazki).Cena;
            if (iloscKsiazek >= ile)
            {
                repo.UpdateOpisStanu(idKsiazki, repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), iloscKsiazek - ile, cenaKsiazki));
                repo.AddZdarzenie(repo.CreateKupienieKsiazkiZdarzenie(repo.GetWykaz(nrOsoby), repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), iloscKsiazek - ile, cenaKsiazki), DateTime.Now));
            }
        }
        public void DodanieKsiazki(int nrOsoby, int idKsiazki, String tytul, String autor)
        {
            if (repo.GetKatalog(idKsiazki) == null)
            {
                repo.AddKatalog(repo.CreatKatalog(tytul, autor, idKsiazki));
                repo.AddOpisStanu(repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), 0, 0.0));
                repo.AddZdarzenie(repo.CreateDodanieKsiazkiZdarzenie(repo.GetWykaz(nrOsoby), repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), 0, 0.0), DateTime.Now));
            }
        }

        public void DostawaKsiazki(int nrOsoby, int idKsiazki, int ilosc, double cena)
        {
            if (repo.GetKatalog(idKsiazki) != null)
            {
                int iloscObecna = repo.GetOpisStanu(idKsiazki).Ilosc;
                repo.UpdateOpisStanu(idKsiazki, repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), iloscObecna + ilosc, cena));
                repo.AddZdarzenie(repo.CreateDostawaZdarzenie(repo.GetWykaz(nrOsoby), repo.CreateOpisStanu(repo.GetKatalog(idKsiazki), iloscObecna + ilosc, cena), DateTime.Now));
            }
        }
        public IEnumerable<OpisStanu> KsiazkiAutora(string autor)
        {
            List<OpisStanu> ksiazki = new List<OpisStanu>();
            foreach (OpisStanu opisy in repo.GetAllOpisStanu())
            {
                if(opisy.Ksiazka.Autor == autor)
                {
                    ksiazki.Add(opisy);
                }
            }
            return ksiazki;
        }

    }
}
