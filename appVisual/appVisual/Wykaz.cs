﻿using System;
using System.Collections.Generic;
using System.Text;

namespace appVisual
{
    class Wykaz
    {
        private string imie;
        private string nazwisko;
        private int nr;

        public string Imie
        {
            get{ return imie; }
            set { imie = value; }
        }
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }
        public int Nr
        {
            get { return nr; }
            set { nr = value; }
        }
    }
}