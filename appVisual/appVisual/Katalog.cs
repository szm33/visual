﻿using System;
using System.Collections.Generic;
using System.Text;

namespace appVisual
{
    class Katalog
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
    }
}
