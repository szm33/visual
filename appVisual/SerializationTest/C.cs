using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTest
{
    [Serializable]
    public class C
    {
        private A a;
        private string name;

        public C() { }

        public C(A a, string name)
        {
            this.a = a;
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        internal A A { get => a; set => a = value; }

        public static string Serialize(C c, ObjectIDGenerator generator)
        {
            long genId = generator.GetId(c, out bool firstTime);
            if (firstTime)
            {
                return c.GetType().Name + ';' + genId + ';' + A.Serialize(c.A,generator) + ';' + c.Name;
            }
            else
            {
                return c.GetType().Name + "_ref" + ';' + genId;
            }
        }

        public static C Deserialize(List<string> pole, Dictionary<string, object> obj)
        {
            if (pole[0] == "C")
            {
                C c = new C();
                obj.Add(pole[1], c);
                pole.RemoveRange(0, 2);
                c.a = A.Deserialize(pole, obj);
                c.Name = pole[0];
                pole.RemoveRange(0, 1);
                return c;
            }
            else
            {
                C c = (C)obj[pole[1]];
                pole.RemoveRange(0, 2);
                return c;
            }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            C c = (C)obj;
            return Name == c.Name && A.Name == c.A.Name && A.B.Name == c.A.B.Name && Name == c.A.B.C.Name;
        }
    }
}
