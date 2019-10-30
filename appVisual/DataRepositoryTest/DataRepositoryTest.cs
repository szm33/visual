using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1._0;

namespace DataRepositoryTest
{
    [TestClass]
    public class DataRepositoryTest
    {

        public DataRepository CreateDataRepositoryExample()
        {
            Wykaz czytelnik1 = new Wykaz("Maciej", "Bartos", 1);
            Katalog ksiazka1 = new Katalog("Wiedzmin", "Andrzej Sapkowski", 1);
            OpisStanu opisStanu1 = new OpisStanu(ksiazka1, 6, 15.30);
            Zdarzenie zdarzenie1 = new Zdarzenie(czytelnik1, opisStanu1, DateTime.Now, 1);
            IDataFiller dataFiller = new WypelnianieStalymi(5);

            List<Wykaz> czytelnicyList = new List<Wykaz>();
            czytelnicyList.Add(czytelnik1);

            List<OpisStanu> opisStanuList = new List<OpisStanu>();
            opisStanuList.Add(opisStanu1);

            Dictionary<int, Katalog> ksiazkiDictionary = new Dictionary<int, Katalog>();
            ksiazkiDictionary.Add(1, ksiazka1);

            ObservableCollection<Zdarzenie> zdarzeniaCollection = new ObservableCollection<Zdarzenie>();
            zdarzeniaCollection.Add(zdarzenie1);

            DataContext dataContext = new DataContext(czytelnicyList, ksiazkiDictionary, zdarzeniaCollection, opisStanuList);
            DataRepository dataRepository = new DataRepository(dataContext, dataFiller);
            return dataRepository;

        }

        public DataRepository CreateEmptyRepository()
        {
            List<Wykaz> czytelnicyList = new List<Wykaz>();
            List<OpisStanu> opisStanuList = new List<OpisStanu>();
            Dictionary<int, Katalog> ksiazkiDictionary = new Dictionary<int, Katalog>();
            ObservableCollection<Zdarzenie> zdarzeniaCollection = new ObservableCollection<Zdarzenie>();
            DataContext dataContext = new DataContext(czytelnicyList, ksiazkiDictionary, zdarzeniaCollection, opisStanuList);
            IDataFiller dataFiller = new WypelnianieStalymi(5);

            return new DataRepository(dataContext, dataFiller);
        }

        public DataRepository CreateEmptyRepositoryWithRandomFill()
        {
            List<Wykaz> czytelnicyList = new List<Wykaz>();
            List<OpisStanu> opisStanuList = new List<OpisStanu>();
            Dictionary<int, Katalog> ksiazkiDictionary = new Dictionary<int, Katalog>();
            ObservableCollection<Zdarzenie> zdarzeniaCollection = new ObservableCollection<Zdarzenie>();
            DataContext dataContext = new DataContext(czytelnicyList, ksiazkiDictionary, zdarzeniaCollection, opisStanuList);
            IDataFiller dataFiller = new WypelnianieLosowe(5);

            return new DataRepository(dataContext, dataFiller);
        }

        [TestMethod]
        public void AddAndGetKatalogTest()
        {
            DataRepository dataRepository = CreateDataRepositoryExample();

            Katalog ksiazka = new Katalog("Example", "Author", 2);

            dataRepository.AddKatalog(ksiazka);

            Assert.AreSame(ksiazka, dataRepository.GetKatalog(2));

        }

        [TestMethod]
        public void AddAndGetWykazTest()
        {
            DataRepository dataRepository = CreateDataRepositoryExample();

            Wykaz czytelnik = new Wykaz("Name", "LastName", 3);

            dataRepository.AddWykaz(czytelnik);

            Assert.AreSame(czytelnik, dataRepository.GetWykaz(3));
        }

        [TestMethod]
        public void AddAndGetZdarzenieTest()
        {
            DataRepository dataRepository = CreateDataRepositoryExample();

            Zdarzenie zdarzenie = new Zdarzenie(dataRepository.GetWykaz(1), dataRepository.GetOpisStanu(1), DateTime.Now, 2);

            dataRepository.AddZdarzenie(zdarzenie);

            Assert.AreSame(zdarzenie, dataRepository.GetZdarzenie(2));
        }

        [TestMethod]
        public void AddAndGetOpisStanuTest()
        {
            DataRepository dataRepository = CreateDataRepositoryExample();

            Katalog ksiazka = new Katalog("Example", "Author", 2);
            OpisStanu opisStanu = new OpisStanu(ksiazka, 10, 59.99);

            dataRepository.AddKatalog(ksiazka);
            dataRepository.AddOpisStanu(opisStanu);

            Assert.AreSame(opisStanu, dataRepository.GetOpisStanu(2));

        }

        [TestMethod]
        public void GetAllWykazTest()
        {
            DataRepository dataRepository = CreateEmptyRepository();

            Wykaz czytelnik1 = new Wykaz("FirstName1", "LastName1", 1);
            Wykaz czytelnik2 = new Wykaz("FirstName2", "LastName2", 2);

            dataRepository.AddWykaz(czytelnik1);
            dataRepository.AddWykaz(czytelnik2);
            
            List<Wykaz> czytelnicy = new List<Wykaz> {czytelnik1, czytelnik2};

            Assert.IsTrue(czytelnicy.SequenceEqual(dataRepository.GetAllWykaz()));

        }

        [TestMethod]
        public void GetAllKatalogTest()
        {
            DataRepository dataRepository = CreateEmptyRepository();

            Katalog ksiazka1 = new Katalog("Name1", "Author1", 1);
            Katalog ksiazka2 = new Katalog("Name2", "Author2", 2);

            dataRepository.AddKatalog(ksiazka1);
            dataRepository.AddKatalog(ksiazka2);

            List<Katalog> ksiazki = new List<Katalog>{ksiazka1, ksiazka2};

            Assert.IsTrue(ksiazki.SequenceEqual(dataRepository.GetAllKatalog()));
        }

        [TestMethod]
        public void GetAllOpisStanuTest()
        {
            DataRepository dataRepository = CreateEmptyRepository();

            Katalog ksiazka1 = new Katalog("Name1", "Author1", 1);
            Katalog ksiazka2 = new Katalog("Name2", "Author2", 2);

            OpisStanu opisStanu1 = new OpisStanu(ksiazka1, 10, 19.99);
            OpisStanu opisStanu2 = new OpisStanu(ksiazka2, 12, 29.99);

            dataRepository.AddKatalog(ksiazka1);
            dataRepository.AddKatalog(ksiazka2);

            dataRepository.AddOpisStanu(opisStanu1);
            dataRepository.AddOpisStanu(opisStanu2);

            List<OpisStanu> opisStanow = new List<OpisStanu>{opisStanu1, opisStanu2};

            Assert.IsTrue(opisStanow.SequenceEqual(dataRepository.GetAllOpisStanu()));
        }

        [TestMethod]
        public void GetAllZdarzeniaTest()
        {
            DataRepository dataRepository = CreateEmptyRepository();

            Katalog ksiazka = new Katalog("Name", "Author", 1);
            Wykaz czytelnik = new Wykaz("FirstName", "LastName", 1);
            OpisStanu opisStanu = new OpisStanu(ksiazka, 23, 19.99);


            Zdarzenie zdarzenie1 = new Zdarzenie(czytelnik, opisStanu, DateTime.Now, 1);
            Zdarzenie zdarzenie2 = new Zdarzenie(czytelnik, opisStanu, DateTime.Now, 2);

            dataRepository.AddKatalog(ksiazka);
            dataRepository.AddWykaz(czytelnik);
            dataRepository.AddOpisStanu(opisStanu);
            dataRepository.AddZdarzenie(zdarzenie1);
            dataRepository.AddZdarzenie(zdarzenie2);

            List<Zdarzenie> zdarzenia = new List<Zdarzenie>{zdarzenie1, zdarzenie2};

            Assert.IsTrue(zdarzenia.SequenceEqual(dataRepository.GetAllZdarzenie()));
        }

        [TestMethod]
        public void RemoveKatalogTest()
        {
            DataRepository dataRepository = CreateEmptyRepository();
            
            Katalog ksiazka = new Katalog("Name", "Author", 1);

            dataRepository.AddKatalog(ksiazka);
            dataRepository.RemoveKatalog(1);

            Assert.IsNull(dataRepository.GetKatalog(1));
        }

        [TestMethod]
        public void RemoveWykazTest()
        {
            DataRepository dataRepository = CreateEmptyRepository();

            Wykaz czytelnik = new Wykaz("FirstName", "LastName", 1);

            dataRepository.AddWykaz(czytelnik);
            dataRepository.RemoveWykaz(czytelnik);

            Assert.IsNull(dataRepository.GetWykaz(1));
        }

        [TestMethod]
        public void RemoveOpisStanuTest()
        {
            DataRepository dataRepository = CreateEmptyRepository();

            Katalog ksiazka = new Katalog("Name", "Author", 1);
            OpisStanu opisStanu = new OpisStanu(ksiazka, 15, 29.99);

            dataRepository.AddKatalog(ksiazka);
            dataRepository.AddOpisStanu(opisStanu);
            dataRepository.RemoveOpisStanu(opisStanu);

            Assert.IsNull(dataRepository.GetOpisStanu(1));
        }

        [TestMethod]
        public void RemoveZdarzenieTest()
        {
            DataRepository dataRepository = CreateEmptyRepository();

            Wykaz czytelnik = new Wykaz("FirstName", "LastName", 1);
            Katalog ksiazka = new Katalog("Name", "Author", 1);
            OpisStanu opisStanu = new OpisStanu(ksiazka, 15, 29.99);
            Zdarzenie zdarzenie = new Zdarzenie(czytelnik, opisStanu, DateTime.Now, 1);

            dataRepository.AddWykaz(czytelnik);
            dataRepository.AddKatalog(ksiazka);
            dataRepository.AddOpisStanu(opisStanu);
            dataRepository.AddZdarzenie(zdarzenie);
            dataRepository.RemoveZdarzenie(zdarzenie);

            Assert.IsNull(dataRepository.GetZdarzenie(1));
        }

        [TestMethod]
        public void UpdateWykazTest()
        {
            DataRepository dataRepository = CreateDataRepositoryExample();

            Wykaz czytelnik = new Wykaz("FirstNameExample", "LastNameExample", 6);

            dataRepository.UpdateWykaz(1, czytelnik);

            Assert.AreSame(czytelnik, dataRepository.GetWykaz(6));
        }

        [TestMethod]
        public void UpdateKatalogTest()
        {
            DataRepository dataRepository = CreateDataRepositoryExample();

            Katalog ksiazka = new Katalog("NameExample", "AuthorExample", 5);

            dataRepository.UpdateKatalog(1, ksiazka);

            Assert.AreSame(ksiazka, dataRepository.GetKatalog(5));

            Assert.IsNull(dataRepository.GetOpisStanu(1));
        }


        [TestMethod]
        public void UpdateOpisStanuTest()
        {
            DataRepository dataRepository = CreateDataRepositoryExample();
            OpisStanu opisStanu = new OpisStanu(dataRepository.GetKatalog(1), 20, 25.99);

            dataRepository.UpdateOpisStanu(1, opisStanu);

            Assert.AreSame(opisStanu, dataRepository.GetOpisStanu(1));
        }

        [TestMethod]
        public void UpdateZdarzenieTest()
        {
            DataRepository dataRepository = CreateDataRepositoryExample();
            Zdarzenie zdarzenie = new Zdarzenie(dataRepository.GetWykaz(1), dataRepository.GetOpisStanu(1), DateTime.Now, 1);

            dataRepository.UpdateZdarzenie(1, zdarzenie);

            Assert.AreSame(zdarzenie, dataRepository.GetZdarzenie(1));

        }

        [TestMethod]
        public void WypelnianieLosoweTest()
        {
            DataRepository dataRepository = CreateEmptyRepositoryWithRandomFill();
            dataRepository.FillRepositoryWithDataFiller();
            Assert.IsTrue(dataRepository.GetAllKatalog().ToList().Count == 5);
            Assert.IsTrue(dataRepository.GetAllWykaz().ToList().Count == 5);
            Assert.IsTrue(dataRepository.GetAllZdarzenie().ToList().Count == 5);
            Assert.IsTrue(dataRepository.GetAllOpisStanu().ToList().Count == 5);
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(dataRepository.GetAllOpisStanu().ToList()[i].Ilosc <= 100);
            }
            
        }



    }
}
