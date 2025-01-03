using Business.Interfaces;
using MobileApp.ViewModels;

namespace MobileApp.Pages;

public partial class ContactListPage : ContentPage
{
    public ContactListPage(ContactListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}