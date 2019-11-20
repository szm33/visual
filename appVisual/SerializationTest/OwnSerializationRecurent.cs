using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTest
{
    class OwnSerializationRecurent
    {
        public static void SerializacjaRekurencyja(string path, Rekurencja rekurencja)
        {
            ObjectIDGenerator generator = new ObjectIDGenerator();
            string dane = "";
            foreach (A a in rekurencja.aElements)
            {
                dane += A.Serialize(a, generator) + "\n";
            }
            foreach (B b in rekurencja.bElements)
            {
                dane += B.Serialize(b, generator) + "\n";
            }
            foreach (C c in rekurencja.cElements)
            {
                dane += C.Serialize(c, generator) + "\n";
            }
            System.IO.File.WriteAllText(@path, dane);
        }

        public static Rekurencja DeserializacjaRekurencja(string path)
        {
            Rekurencja rekurencja = new Rekurencja();
            string[] dane = System.IO.File.ReadAllLines(@path);
            Dictionary<string, object> obiekty = new Dictionary<string, object>();
            foreach (string linia in dane)
            {
                string[] pole = linia.Split(';');
                switch (pole[0])
                {
                    case "A":
                    case "A_ref":
                        A a = A.Deserialize(new List<string>(pole), obiekty);
                        rekurencja.aElements.Add(a);
                        break;

                    case "B":
                    case "B_ref":
                        B b = B.Deserialize(new List<string>(pole), obiekty);
                        rekurencja.bElements.Add(b);
                        break;

                    case "C":
                    case "C_ref":
                        C c = C.Deserialize(new List<string>(pole), obiekty);
                        rekurencja.cElements.Add(c);
                        break;
                }
            }
            return rekurencja;

        }
    }
}
