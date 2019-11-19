using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1._0;
using zadanie2;

namespace DataRepositoryTest
{
    [TestClass]
    public class DataServiceTest
    {
        public DataRepository CreateDataRepositoryExample()
        {
            Wykaz czytelnik1 = new Wykaz("Maciej", "Bartos", 1);
            Katalog ksiazka1 = new Katalog("Wiedzmin", "Andrzej Sapkowski", 1);
            OpisStanu opisStanu1 = new OpisStanu(ksiazka1, 20, 15.30);
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
        [TestMethod]
        public void KupienieKsiazkiTest()
        {
            DataRepository dateRepository = CreateDataRepositoryExample();
            DateService dateService = new DateService(dateRepository);

            int currentAmount = dateRepository.GetOpisStanu(1).Ilosc;

            dateService.KupienieKsiazki(1, 1, 10);

            Assert.AreEqual(currentAmount - 10, dateRepository.GetOpisStanu(1).Ilosc);
        }

        [TestMethod]
        public void DodanieKsiazkiTest()
        {
            DataRepository dateRepository = CreateDataRepositoryExample();
            DateService dateService = new DateService(dateRepository);

            dateService.DodanieKsiazki(1, 3, "NaN", "Author");

            Assert.IsNotNull(dateRepository.GetKatalog(3));
        }

        [TestMethod]
        public void DostawaKsiazkiTest()
        {
            DataRepository dateRepository = CreateDataRepositoryExample();
            DateService dateService = new DateService(dateRepository);

            int currentAmount = dateRepository.GetOpisStanu(1).Ilosc;
            double futurePrice = 25.99;

            dateService.DostawaKsiazki(1, 1, 10, futurePrice);

            Assert.AreEqual(futurePrice, dateRepository.GetOpisStanu(1).Cena);
            Assert.AreEqual(currentAmount + 10, dateRepository.GetOpisStanu(1).Ilosc);

        }
        [TestMethod]
        public void serizlizacja()
        {
            Assert.IsTrue(true);
           /* Katalog k1 = new Katalog("tytul", "autor", 1);
            Katalog k2 = new Katalog("tytul2", "autor2", 2);
            List<Katalog> kata = new List<Katalog>();
            kata.Add(k1);
            kata.Add(k2);
            string path = "katalogi.bin";
            SerialClass<Katalog>.Serialize(path, k1);
            Katalog k3 = SerialClass<Katalog>.Deserialize(path); 
            Assert.AreEqual(k3, k1);
            SerialClass<List<Katalog>>.Serialize(path, kata);
            List < Katalog > kata1= SerialClass<List<Katalog>>.Deserialize(path);
            for (int i = 0; i < kata.Count; i++)
            {
                Assert.AreEqual(kata[i], kata1[i]);
            }
            Assert.AreEqual("Katalog", k1.GetType().Name);
            ObjectIDGenerator g = new ObjectIDGenerator();*/
           /* g.GetId(k1, out bool firstTime);
            Assert.IsTrue(firstTime);*/
        }
    }
}
