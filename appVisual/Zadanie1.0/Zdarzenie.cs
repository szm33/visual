using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1._0
{
    class Zdarzenie
    {
        Wykaz wypozyczajacy;
        OpisStanu egzemplarz;
        DateTime data_zakupu;

        public Zdarzenie(Wykaz wypozyczajacy, OpisStanu egzemplarz, DateTime data_zakupu)
        {
            this.wypozyczajacy = wypozyczajacy;
            this.egzemplarz = egzemplarz;
            this.data_zakupu = data_zakupu;
        }

        public DateTime Data_zakupu { get => data_zakupu; set => data_zakupu = value; }
        internal Wykaz Wypozyczajacy { get => wypozyczajacy; set => wypozyczajacy = value; }
        internal OpisStanu Egzemplarz { get => egzemplarz; set => egzemplarz = value; }
    }
}
