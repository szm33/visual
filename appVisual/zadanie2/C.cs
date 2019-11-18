using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    class C
    {
        private A a;
        private string name;

        public string Name { get => name; set => name = value; }

        public C() { }

        public C(A a, string name)
        {
            this.a = a;
            this.name = name;
        }

        static public string Serialize(C c, ObjectIDGenerator generator)
        {
            long genId = generator.GetId(c, out bool firstTime);
            if (firstTime)
            {
                return c.GetType().Name + ',' + A.Serialize(c.A,generator) + ',' + c.Name + ',' + genId;
            }
            else
            {
                return c.GetType().Name + "_ref" + ',' + genId;
            }
        }

        static public C Deserialize(List<string> pole, Dictionary<string, object> obj)
        {
            if (pole[0] == "C")
            {
                C c = new C();
                obj.Add(pole[1], c);
                pole.RemoveRange(0, 2);
                c.a = A.Deserialize(pole, obj);
                return c;
            }
            else
            {
                C c = (C)obj[pole[1]];
                pole.RemoveRange(0, 2);
                return c;
            }
        }

        internal A A { get => a; set => a = value; }
    }
}
