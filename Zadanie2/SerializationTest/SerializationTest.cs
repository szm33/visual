using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad2;

namespace SerializationTest
{
    [TestClass]
    public class SerializationTest
    {


        [TestMethod]
        public void SerialClassTestRekurencja()
        {
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
            a.Date = DateTime.Now;
            b.Date = DateTime.Now;
            c.Date = DateTime.Now;
            String path = "rekurencjaTest.bin";

            SerialClass<A>.Serialize(path, a);

            A a_tmp = SerialClass<A>.Deserialize(path);

            Assert.AreEqual(a, a_tmp);
            Assert.AreEqual(b, a_tmp.ClassB);
            Assert.AreEqual(c, a_tmp.ClassB.ClassC);

        }


        [TestMethod]
        public void WlasnaSerializacjaRekurencjaTest()
        {
            String path = "rekurencjaOwnSerializationTest.txt";

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
            a.Date = DateTime.Now;
            b.Date = DateTime.Now;
            c.Date = DateTime.Now;

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                osr.Serialize(fs, b);

            }
            B b_tmp;

            using (FileStream s = new FileStream(path, FileMode.Open))
            {
                b_tmp = (B)osr.Deserialize(s);
            }


            Assert.AreEqual(a, b_tmp.ClassC.ClassA);
            Assert.AreEqual(b, b_tmp);
            Assert.AreEqual(c, b_tmp.ClassC);


        }
    }
}
