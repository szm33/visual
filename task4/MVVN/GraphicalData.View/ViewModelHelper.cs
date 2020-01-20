using System.Windows;
using GraphicalData.ViewData;

namespace GraphicalData.View
{
    public class ViewModelHelper : IViewModelHelper
    {
        public void Show(string errorName, string errorMessage)
        {
            MessageBox.Show(errorName, errorMessage, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowInfo()
        {
            new DetailedInfo().Show();
        }
    }
}
