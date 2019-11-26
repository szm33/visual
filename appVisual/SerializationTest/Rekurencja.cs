using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTest
{
    [Serializable]
    public class Rekurencja
    {
        public List<A> aElements= new List<A>();
        public List<B> bElements= new List<B>();
        public List<C> cElements= new List<C>();

        public void Fill()
        {
            for (int i = 0; i < 5; i++)
            {
                A a = new A();
                B b = new B();
                C c = new C();
                a.Name = "a" + i;
                b.Name = "b" + i;
                c.Name = "c" + i;
                a.ClassB = b;
                b.ClassC = c;
                c.ClassA = a;
                aElements.Add(a);
                bElements.Add(b);
                cElements.Add(c);
            }
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            Rekurencja r = (Rekurencja)obj;
            return aElements.SequenceEqual(r.aElements) && bElements.SequenceEqual(r.bElements) &&
                   cElements.SequenceEqual(r.cElements);
        }
    }
}
