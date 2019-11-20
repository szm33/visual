using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Zadanie1._0
{
    [Serializable]
    public class Katalog
    {
        private string tytul;
        private string autor;
        private int id;

        public Katalog(string tytul, string autor, int id)
        {
            this.tytul = tytul;
            this.autor = autor;
            this.id = id;
        }

        public string Info()
        {
            return tytul + ',' + autor + ',' + id ;
        }

        /*static public string Serialize(Katalog k,ObjectIDGenerator generator)
        {
            return k.GetType().Name + ',' + k.Tytul + ',' + k.Autor + ',' + k.Id + ',' + generator.GetId(k, out bool firstTime);
        }*/

        static public string Serialize(Katalog k, ObjectIDGenerator generator)
        {
            long genId = generator.GetId(k, out bool firstTime);
            if (firstTime) {
                return k.GetType().Name + ';' + k.Tytul + ';' + k.Autor + ';' + k.Id + ';' + genId;
            }
            else
            {
                return k.GetType().Name + "_ref" + ';' + genId;
            }
        }

  /*      static public Katalog Deseriazlie(string[] pole)
        {
            return new Katalog(pole[1], pole[2], Int32.Parse(pole[3]));
        }*/

        static public Katalog Deserialize(List<string> pole, Dictionary<string, object> obj)
        {
            if (pole[0] == "Katalog")
            {
                Katalog k = new Katalog(pole[1], pole[2], Int32.Parse(pole[3]));
                obj.Add(pole[4], k);
                pole.RemoveRange(0, 5);
                return k;
            }
            else
            {
                Katalog k = (Katalog)obj[pole[1]];
                pole.RemoveRange(0, 2);
                return k;
            } 
        }

        public string Tytul
        {
            get { return tytul; }
            set { tytul = value; }
        }
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }

            Katalog k = (Katalog)obj;
            return tytul == k.tytul && autor == k.autor && id == k.id;
        }

        public override string ToString()
        {
            return tytul + ',' + autor + ',' + id;
            //return $"{nameof(tytul)}: {tytul}, {nameof(autor)}: {autor}, {nameof(id)}: {id}";
        }
    }
}
