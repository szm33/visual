using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalData.ViewData
{
    interface IViewModelHelper
    {
        void Show(string errorName, string errorMessage);
        void ShowInfo();
    }
}
