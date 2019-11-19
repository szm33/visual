using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1._0;
using zadanie2;

namespace DataRepositoryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, new WypelnianieStalymi(5));
            WlasnaSerializacja ser = new WlasnaSerializacja();
            dataRepository.FillRepositoryWithDataFiller();
            ser.SerializacjaDataContext("datacontext.txt", dataContext);
            DataContext d = ser.DeserializacjaDataContext("datacontext.txt");
            /*Assert.AreEqual(dataContext,ser.DeserializacjaDataContext("datacontext.txt"));*/
            for (int i = 0; i < d.zdarzenia.Count; i++)
            {
                Assert.IsTrue(dataContext.ksiazki[i].Equals(d.ksiazki[i]));
                //Assert.IsTrue(dataContext.zdarzenia[i].Equals(d.zdarzenia[i]));
                //Assert.IsTrue(dataContext.opisy_ksiazek[i].Equals(d.opisy_ksiazek[i]));
                Assert.IsTrue(dataContext.czytelnicy[i].Equals(d.czytelnicy[i]));
                //Assert.AreEqual(d.zdarzenia[i], dataContext.zdarzenia[i]);
                //Assert.AreEqual(d.czytelnicy[i], dataContext.czytelnicy[i]);
                //Assert.AreEqual(d.opisy_ksiazek[i], dataContext.opisy_ksiazek[i]);
               // Assert.AreEqual(d.ksiazki[i], dataContext.ksiazki[i]);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            Rekurencja rek = new Rekurencja();
            Rekurencja rek1 = new Rekurencja();
            rek.Fill();
            WlasnaSerializacja ser = new WlasnaSerializacja();
            ser.SerializacjaRekurencyja("rekurencja.txt", rek);
            rek1 = ser.DeserializacjaRekurencja("rekurencja.txt");
            Assert.IsTrue(rek.cElements[0].Name == rek1.cElements[0].Name);
            Assert.IsTrue( rek1.cElements[0].Name == "c0");
        }
    }
}
