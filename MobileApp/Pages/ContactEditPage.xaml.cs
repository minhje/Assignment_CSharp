using MobileApp.ViewModels;

namespace MobileApp.Pages;

public partial class ContactEditPage : ContentPage
{
	public ContactEditPage(ContactEditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;


    }
}