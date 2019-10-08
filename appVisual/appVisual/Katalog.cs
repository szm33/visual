using System;
using System.Collections.Generic;
using System.Text;

namespace appVisual
{
    class Katalog
    {
        private string tytul;
        private string opis;
        private int id;

        public string Tytul
        {
            get { return tytul; }
            set { tytul = value; }
        }
        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
