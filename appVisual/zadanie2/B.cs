using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    class B
    {
        private C c;
        private string name;

        public string Name { get => name; set => name = value; }

        public B() { }

        public B(C c, string name)
        {
            this.c = c;
            this.name = name;
        }

        static public string Serialize(B b, ObjectIDGenerator generator)
        {
            long genId = generator.GetId(b, out bool firstTime);
            if (firstTime)
            {
                return b.GetType().Name + ',' + C.Serialize(b.C,generator) + ',' + b.Name + ','  + genId;
            }
            else
            {
                return b.GetType().Name + "_ref" + ',' + genId;
            }
        }

        static public B Deserialize(List<string> pole, Dictionary<string, object> obj)
        {
            if (pole[0] == "B")
            {
                B b = new B();
                obj.Add(pole[1], b);
                pole.RemoveRange(0, 2);
                b.c = C.Deserialize(pole, obj);
                return b;
            }
            else
            {
                B b = (B)obj[pole[1]];
                pole.RemoveRange(0, 2);
                return b;
            }
        }

        internal C C { get => c; set => c = value; }
    }
}
