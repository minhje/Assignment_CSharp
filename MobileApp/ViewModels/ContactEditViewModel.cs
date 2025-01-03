using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MobileApp.ViewModels;

public partial class ContactEditViewModel : ObservableObject
{
    private readonly ContactService _contactService;

    [ObservableProperty]
    private Business.Models.Contact _contact = new();

    [RelayCommand]
    private async Task Update()
    {
        await _contactService.UpdateContact(Contact); 
        Contact = new();

        await Shell.Current.GoToAsync("//ContactListPage");
    }
}
