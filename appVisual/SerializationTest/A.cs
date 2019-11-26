using System;
using System.Runtime.Serialization;

namespace SerializationTest
{
    [Serializable]
    public class A : ISerializable
    {
        public string Name { get; set; }
        internal B ClassB { get; set; }

        public A() { }

        public A(B b, string name)
        {
            ClassB = b;
            Name = name;
        }

        public A(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            ClassB = (B)info.GetValue("ClassB", typeof(B));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("ClassB", ClassB, typeof(B));
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            A a = (A)obj;
            return Name == a.Name && ClassB.Name == a.ClassB.Name && ClassB.ClassC.Name == a.ClassB.ClassC.Name && Name == a.ClassB.ClassC.ClassA.Name;
        }
    }
}
