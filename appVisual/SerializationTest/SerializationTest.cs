using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1._0;
using zadanie2;

namespace SerializationTest
{
    [TestClass]
    public class SerializationTest
    {
        [TestMethod]
        public void SerialClassTestDataContext()
        {
            Katalog ksiazka1 = new Katalog("example", "author", 1);
            Katalog ksiazka2 = new Katalog("example2", "author", 2);
            Dictionary<int, Katalog> ksiazki = new Dictionary<int, Katalog> { { 1, ksiazka1 }, { 2, ksiazka2 } };

            Wykaz osoba1 = new Wykaz("Name", "Surname", 1);
            Wykaz osoba2 = new Wykaz("Name2", "Surname2", 2);
            List<Wykaz> osoby = new List<Wykaz> { osoba1, osoba2 };

            OpisStanu opisStanu1 = new OpisStanu(ksiazka1, 12, 15.30);
            OpisStanu opisStanu2 = new OpisStanu(ksiazka2, 20, 20.50);
            List<OpisStanu> opisyStanu = new List<OpisStanu> { opisStanu1, opisStanu2 };

            Zdarzenie zdarzenie1 = new DostawaZdarzenie(osoba1, opisStanu1, DateTime.Now, 1);
            Zdarzenie zdarzenie2 = new DostawaZdarzenie(osoba2, opisStanu2, DateTime.Now, 2);
            ObservableCollection<Zdarzenie> zdarzenia = new ObservableCollection<Zdarzenie> { zdarzenie1, zdarzenie2 };


            DataContext dataContext = new DataContext(osoby, ksiazki, zdarzenia, opisyStanu);

            String filePath = "DataContextTest.bin";

            SerialClass<DataContext>.Serialize(filePath, dataContext);
            DataContext dataContextDes = SerialClass<DataContext>.Deserialize(filePath);

            Assert.AreEqual(dataContext, dataContextDes);

            CollectionAssert.AreEqual(dataContext.ksiazki, dataContextDes.ksiazki);
            CollectionAssert.AreEqual(dataContext.czytelnicy, dataContextDes.czytelnicy);
            CollectionAssert.AreEqual(dataContext.opisy_ksiazek, dataContextDes.opisy_ksiazek);
            CollectionAssert.AreEqual(dataContext.zdarzenia, dataContextDes.zdarzenia);

        }

        [TestMethod]
        public void SerialClassTestRekurencja()
        {
            Rekurencja rekurencja = new Rekurencja();
            rekurencja.Fill();
            String path = "rekurencjaTest.bin";

            SerialClass<Rekurencja>.Serialize(path, rekurencja);

            Rekurencja rekurencjaDes = SerialClass<Rekurencja>.Deserialize(path);

            Assert.AreEqual(rekurencja, rekurencjaDes);

        }

        [TestMethod]
        public void WlasnaSerializacjaTestDataContext()
        {
            Katalog ksiazka1 = new Katalog("example", "author", 1);
            Katalog ksiazka2 = new Katalog("example2", "author", 2);
            Dictionary<int, Katalog> ksiazki = new Dictionary<int, Katalog> { { 1, ksiazka1 }, { 2, ksiazka2 } };

            Wykaz osoba1 = new Wykaz("Name", "Surname", 1);
            Wykaz osoba2 = new Wykaz("Name2", "Surname2", 2);
            List<Wykaz> osoby = new List<Wykaz> { osoba1, osoba2 };

            OpisStanu opisStanu1 = new OpisStanu(ksiazka1, 12, 15.30);
            OpisStanu opisStanu2 = new OpisStanu(ksiazka2, 20, 20.50);
            List<OpisStanu> opisyStanu = new List<OpisStanu> { opisStanu1, opisStanu2 };

            Zdarzenie zdarzenie1 = new DodanieKsiazkiZdarzenie(osoba1, opisStanu1, DateTime.Now.Date, 1);
            Zdarzenie zdarzenie2 = new DodanieKsiazkiZdarzenie(osoba2, opisStanu2, DateTime.Now.Date, 2);
//            Zdarzenie zdarzenie1 = new Zdarzenie(osoba1, opisStanu1, DateTime.Now.Date, 1);
//            Zdarzenie zdarzenie2 = new Zdarzenie(osoba2, opisStanu2, DateTime.Now.Date, 2);
            ObservableCollection<Zdarzenie> zdarzenia = new ObservableCollection<Zdarzenie> { zdarzenie1, zdarzenie2 };


            DataContext dataContext = new DataContext(osoby, ksiazki, zdarzenia, opisyStanu);

            String filePath = "DataContextOwnSerializationTest.bin";

            WlasnaSerializacja.SerializacjaDataContext(filePath, dataContext);

            DataContext dataContextDes = WlasnaSerializacja.DeserializacjaDataContext(filePath);

//            Assert.AreEqual(dataContext, dataContextDes);
            CollectionAssert.AreEqual(dataContext.ksiazki, dataContextDes.ksiazki);
            CollectionAssert.AreEqual(dataContext.czytelnicy, dataContextDes.czytelnicy);
            CollectionAssert.AreEqual(dataContext.opisy_ksiazek, dataContextDes.opisy_ksiazek);
            CollectionAssert.AreEqual(dataContext.zdarzenia, dataContextDes.zdarzenia);
        }

        [TestMethod]
        public void WlasnaSerializacjaRekurencjaTest()
        {
            Rekurencja rekurencja = new Rekurencja();
            rekurencja.Fill();
            String path = "rekurencjaOwnSerializationTest.bin";

            OwnSerializationRecurent osr = new OwnSerializationRecurent();
            A a = new A();
            B b = new B();
            C c = new C();

            a.Name = "klasa A";
            b.Name = "klasa B";
            c.Name = "klasa C";
            a.ClassB = b;
            b.ClassC = c;
            c.ClassA = a;
            a.Number = 1.23F;
            b.Number = 2.555F;
            c.Number = 56.9283F;

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                osr.Serialize(fs, b);
                
            }
            string result = File.ReadAllText(path);

            System.Diagnostics.Debug.WriteLine(result);
            B a_tmp;

            using (FileStream s = new FileStream(path, FileMode.Open))
            {
                a_tmp = (B)osr.Deserialize(s);
            }

            System.Diagnostics.Debug.WriteLine(result);

            System.Diagnostics.Debug.WriteLine(a_tmp.GetType().ToString());
            System.Diagnostics.Debug.WriteLine(a_tmp.ClassC.Name);
            

        }
    }
}
