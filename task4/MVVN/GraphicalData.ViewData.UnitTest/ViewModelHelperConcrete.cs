using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalData.ViewData.UnitTest
{
    class ViewModelHelperMock : IViewModelHelper
    {
        public void Show(string errorName, string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            throw new NotImplementedException();
        }
    }
}
