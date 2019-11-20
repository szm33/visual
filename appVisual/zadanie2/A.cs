using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace zadanie2
{
    [Serializable]
    public class A
    {
        private B b;
        private string name;

        public string Name { get => name; set => name = value; }
        internal B B { get => b; set => b = value; }

        public A() { }

        public A(B b, string name)
        {
            this.b = b;
            this.name = name;
        }

       static public string Serialize(A a, ObjectIDGenerator generator)
        {
            long genId = generator.GetId(a, out bool firstTime);
            if (firstTime)
            {
                return a.GetType().Name + ';' + genId + ';' + B.Serialize(a.B,generator) + ';' + a.Name;
            }
            else
            {
                return a.GetType().Name + "_ref" + ';' + genId;
            }
        }

        static public A Deserialize(List<string> pole, Dictionary<string, object> obj)
        {
            if (pole[0] == "A")
            {
                A a = new A();
                obj.Add(pole[1], a);
                pole.RemoveRange(0, 2);
                a.b = B.Deserialize(pole, obj);
                a.Name = pole[0];
                pole.RemoveRange(0, 1);
                return a;
            }
            else
            {
                A a = (A)obj[pole[1]];
                pole.RemoveRange(0, 2);
                return a;
            }
        }



        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            A a = (A)obj;
            return Name == a.Name && b.Name == a.b.Name && b.C.Name == a.b.C.Name && Name == a.b.C.A.Name;
        }
    }
}
