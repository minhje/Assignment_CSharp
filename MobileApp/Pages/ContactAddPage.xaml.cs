using MobileApp.ViewModels;

namespace MobileApp.Pages;

public partial class ContactAddPage : ContentPage
{

    public ContactAddPage(ContactAddViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}