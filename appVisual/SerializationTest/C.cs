using System;
using System.Runtime.Serialization;

namespace SerializationTest
{
    [Serializable]
    public class C : ISerializable
    {
        public string Name { get; set; }
        public float Number { get; set; }
        internal A ClassA { get; set; }

        public C() { }

        public C(A a, string name, float number)
        {
            ClassA = a;
            Name = name;
            Number = number;
        }

        public C(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Number = info.GetSingle("Number");
            ClassA = (A)info.GetValue("ClassA", typeof(A));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Number", Number);
            info.AddValue("ClassA", ClassA, typeof(A));
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            C c = (C)obj;
            return Name == c.Name && ClassA.Name == c.ClassA.Name && ClassA.ClassB.Name == c.ClassA.ClassB.Name && Name == c.ClassA.ClassB.ClassC.Name;
        }
    }
}
