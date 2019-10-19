using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1._0
{
     class DateService
    {
        private DataRepository repozytorium;

        public DateService(DataRepository repozytorium)
        {
            this.repozytorium = repozytorium;
        }

        public IEnumerable<OpisStanu> dostepneKsiazki()
        {
            return repozytorium.GetAllOpisStanu();
        }

        public IEnumerable<Zdarzenie> transakcjeCzytelnika(Wykaz czytelnik)
        {
            List<Zdarzenie> zdarzenia = new List<Zdarzenie>();
            foreach ( Zdarzenie zdarzenie in repozytorium.GetAllZdarzenie())
            {
                if(zdarzenie.Wypozyczajacy == czytelnik)
                {
                    zdarzenia.Add(zdarzenie);
                }
            }
            return zdarzenia;
        }
        public void kup(Wykaz czytelnik, Katalog ksiazka, int ile)
        {
            repozytorium.AddWykaz(czytelnik);
            foreach (OpisStanu opisy in repozytorium.GetAllOpisStanu())
            {
                if(opisy.Ksiazka == ksiazka && opisy.Ilosc >= ile)
                {
                    opisy.Ilosc -= ile;
                    repozytorium.AddZdarzenie(new Zdarzenie(czytelnik, new OpisStanu(ksiazka, ile, opisy.Cena), new DateTime(), repozytorium.GetNrTransakcji()));
                    break;
                }
            }
        }
        public void dodanieKsiazki(Katalog ksiazka)
        {
            repozytorium.AddKatalog(ksiazka);

        }

        public void dostawaKsiazki(Katalog ksiazka, int ilosc, int wartosc)
        {
            repozytorium.AddKatalog(ksiazka);
            foreach (OpisStanu opis in repozytorium.GetAllOpisStanu())
            {
                if(opis.Ksiazka == ksiazka)
                {
                    opis.Ilosc += ilosc;
                    return;
                }
            }
            repozytorium.AddOpisStanu(new OpisStanu(ksiazka, ilosc, wartosc));
        }
        public IEnumerable<OpisStanu> ksiazkiAutora(string autor)
        {
            List<OpisStanu> ksiazki = new List<OpisStanu>();
            foreach (OpisStanu opisy in repozytorium.GetAllOpisStanu())
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
