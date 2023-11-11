using Calcultator.Views;

namespace Calcultator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DashboardView();
        }
    }
}