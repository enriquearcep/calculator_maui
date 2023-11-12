using Calcultator.ViewModels;

namespace Calcultator.Views;

public partial class DashboardView : ContentPage
{
	public DashboardView()
	{
		InitializeComponent();
		BindingContext = new DashboardViewModel();
	}
}