using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTest
{
    class OwnSerializationRecurent : Formatter
    {
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override object Deserialize(Stream serializationStream)
        {
            throw new NotImplementedException();
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            ISerializable _data = (ISerializable)graph;
            SerializationInfo _info = new SerializationInfo(graph.GetType(), new FormatterConverter());
            StreamingContext _context = new StreamingContext(StreamingContextStates.File);
            _data.GetObjectData(_info, _context);

            foreach (SerializationEntry _item in _info)
                this.WriteMember(_item.Name, _item.Value);

            System.Diagnostics.Debug.WriteLine("value: " + data);


            dataForSave.Add(data + "\n");
            data = "";



            while (this.m_objectQueue.Count != 0)
            {
                this.Serialize(null, this.m_objectQueue.Dequeue());
            }

            if (null != serializationStream) 
            {
                using (StreamWriter writer = new StreamWriter(serializationStream))
                {
                    foreach (string line in dataForSave)
                        writer.Write(line);
                }
            }
            
        }

        private List<string> dataForSave = new List<string>();
        private string data = "";

        protected void WriteString(object obj, string name)
        {
            data += obj.GetType() + "(" + name + "=" + (string)obj + ")|";
        }
        protected void WriteObject(object obj, string name, Type type)
        {
            if (null != obj)
            {
                data += type.ToString() + "(" + name + "=" + this.m_idGenerator.GetId(obj, out bool firstTime).ToString() + ")|";
                if (firstTime)
                {
                    this.m_objectQueue.Enqueue(obj);
                }
                else
                {
                    data = "";
                }
            }
            else
            {
                data += "nullRef(" + name + "=-1)";
            }
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType.Equals(typeof(String)))
            {
                WriteString(obj, name);
            }
            else
            {
                WriteObject(obj, name, memberType);
            }
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }
    }
}
