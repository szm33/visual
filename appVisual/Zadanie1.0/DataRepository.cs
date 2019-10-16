using System;
using System.Collections.Generic;
using System.Text;



//Dodaj kod konfigurujący komponenty aplikacji przed uruchomieniem, który będzie przekazywać do klasy DataRepository obiekt klasy WypelnianieStalymi.
namespace Zadanie1._0
{
    class DataRepository
    {
        private DataContext dane;
        private IDataFiller dataFiller;

        public DataRepository(DataContext dane, IDataFiller dataFiller)
        {
            this.dane = dane;
            this.dataFiller = dataFiller;
            dataFiller.Fill(dane);
        }
    }
}
