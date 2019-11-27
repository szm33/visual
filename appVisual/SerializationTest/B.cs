using System;
using System.Runtime.Serialization;

namespace SerializationTest
{
    [Serializable]
    public class B : ISerializable
    {
        public string Name { get; set; }
        public float Number { get; set; }
        internal C ClassC { get; set; }

        public B() { }

        public B(C c, string name, float number)
        {
            ClassC = c;
            Name = name;
            Number = number;
        }

        public B(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Number = info.GetSingle("Number");
            ClassC = (C)info.GetValue("ClassC", typeof(C));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Number", Number);
            info.AddValue("ClassC", ClassC, typeof(C));
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            B b = (B)obj;
            return Name == b.Name && ClassC.Name == b.ClassC.Name && ClassC.ClassA.Name == b.ClassC.ClassA.Name && Name == b.ClassC.ClassA.ClassB.Name;
        }

    }
}
