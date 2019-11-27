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
        public override StreamingContext Context { get; set; }

        public OwnSerializationRecurent()
        {
            Context = new StreamingContext(StreamingContextStates.File);
        }

        public override object Deserialize(Stream serializationStream)
        {
            using (StreamReader reader = new StreamReader(serializationStream))
            {
                string line;
                while (null != (line = reader.ReadLine()) && "" != line)
                {
                    dataForDeserialization.Add(line);
                }

                foreach (string obj in dataForDeserialization)
                {
                    string[] separatedObj = obj.Split(new string[] { "(|)" }, StringSplitOptions.None);
                    dataForReference.Add(separatedObj[1], FormatterServices.GetSafeUninitializedObject(Type.GetType(separatedObj[0])));
                }

                foreach (string row in dataForDeserialization)
                {
                    string[] splitRowOfData = row.Split(new string[] { "(|)" }, StringSplitOptions.None);
                    Type objectType = Type.GetType(splitRowOfData[0]);
                    SerializationInfo info = new SerializationInfo(objectType, new FormatterConverter());

                    GetDataOfObjectsToDeserialize(info, splitRowOfData);
                    Type[] constructorTypes = { info.GetType(), Context.GetType() };

                    object[] constructorParameters = { info, Context };
                    dataForReference[splitRowOfData[1]].GetType().GetConstructor(constructorTypes).Invoke(dataForReference[splitRowOfData[1]], constructorParameters);
                }

            }
            return dataForReference["1"];

        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            ISerializable _data = (ISerializable)graph;
            SerializationInfo _info = new SerializationInfo(graph.GetType(), new FormatterConverter());
            data += graph.GetType() + "(|)" + this.m_idGenerator.GetId(graph, out bool _) + "(|)";
            _data.GetObjectData(_info, Context);

            foreach (SerializationEntry _item in _info)
                this.WriteMember(_item.Name, _item.Value);

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
        private List<string> dataForDeserialization = new List<string>();
        private Dictionary<string, object> dataForReference = new Dictionary<string, object>();
        private string data = "";

        private void PropertyTypeInDeserialization(SerializationInfo info, string type, string name, string value)
        {
            switch (type)
            {
                case "System.String":
                    info.AddValue(name, value);
                    break;
                case "System.Integar":
                    info.AddValue(name, System.Convert.ToInt32(value));
                    break;
            }
        }

        private bool CustomType(string type)
        {
            switch (type)
            {
                case "SerializationTest.A":
                case "SerializationTest.B":
                case "SerializationTest.C":
                    return true;
                default:
                    return false;
            }
        }

        private void GetDataOfObjectsToDeserialize(SerializationInfo info, string[] splitRowOfData)
        {
            for (int i = 2; i < splitRowOfData.Length-1; i++)
            {
                string[] property = splitRowOfData[i].Split(new string[] { "(-)" }, StringSplitOptions.None);

                if (CustomType(property[0]))
                {
                    info.AddValue(property[1], dataForReference[property[2]], Type.GetType(property[0]));
                }
                else
                {
                    if (!property[0].Equals("nullRef"))
                    {
                        PropertyTypeInDeserialization(info, property[0], property[1], property[2]);
                    }
                    else
                    {
                        info.AddValue(property[1], null);
                    }
                }
            }
        }

        protected void WriteString(object obj, string name)
        {
            data += obj.GetType() + "(-)" + name + "(-)" + (string)obj + "(|)";
        }
        protected void WriteObject(object obj, string name, Type type)
        {
            if (null != obj)
            {
                data += type.ToString() + "(-)" + name + "(-)" + this.m_idGenerator.GetId(obj, out bool firstTime).ToString() + "(|)";
                if (firstTime)
                {
                    this.m_objectQueue.Enqueue(obj);
                }

            }
            else
            {
                data += "nullRef(-)" + name + "(-)-1(|)";
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
