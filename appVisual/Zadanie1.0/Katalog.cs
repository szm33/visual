using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1._0
{
    public class Katalog
    {
        private string tytul;
        private string autor;
        private int idKsiazki;

        public Katalog(string tytul, string autor, int idKsiazki)
        {
            this.tytul = tytul;
            this.autor = autor;
            this.idKsiazki = idKsiazki;
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
        public int IdKsiazki
        {
            get { return idKsiazki; }
            set { idKsiazki = value; }
        }

        public override bool Equals(object obj)
        {
            return obj is Katalog katalog &&
                   idKsiazki == katalog.idKsiazki;
        }

        public override string ToString()
        {
            return $"{nameof(Tytul)}: {Tytul}, {nameof(Autor)}: {Autor}, {nameof(IdKsiazki)}: {IdKsiazki}";
        }
    }
}
