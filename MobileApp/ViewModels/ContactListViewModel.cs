using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MobileApp.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Contact> contacts = [];

    [RelayCommand]
    private async Task NavigateToAddContact(Contact contact)
    {
        await Shell.Current.GoToAsync("ContactAddPage");
    }

    [RelayCommand]
    private async Task NavigateToEditContact(Contact contact)
    {
        await Shell.Current.GoToAsync("ContactAddPage");
    }

    [RelayCommand]
    private void NavigateToRemoveContact(Contact contact)
    {

    }
}
