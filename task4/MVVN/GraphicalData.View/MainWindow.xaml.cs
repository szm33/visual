using System;
using System.Windows;
using GraphicalData.ViewDataStandard;


namespace GraphicalData.View
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MainViewModel _vm = (MainViewModel)DataContext;
            _vm.ViewModelHelper = new ViewModelHelper();
        }

    }
}
