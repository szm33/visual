using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    [Serializable]
    public class B
    {
        private C c;
        private string name;

        public string Name { get => name; set => name = value; }
        internal C C { get => c; set => c = value; }

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
                return b.GetType().Name + ';' + genId + ';' + C.Serialize(b.C,generator) + ';' + b.Name;
            }
            else
            {
                return b.GetType().Name + "_ref" + ';' + genId;
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
                b.Name = pole[0];
                pole.RemoveRange(0, 1);
                return b;
            }
            else
            {
                B b = (B)obj[pole[1]];
                pole.RemoveRange(0, 2);
                return b;
            }
        }

        
        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            B b = (B)obj;
            return Name == b.Name && C.Name == b.C.Name && C.A.Name == b.C.A.Name && Name == b.C.A.B.Name;
        }

    }
}
