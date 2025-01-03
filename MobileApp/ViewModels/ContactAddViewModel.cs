using Business.Services;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MobileApp.ViewModels;

public partial class ContactAddViewModel : ObservableObject
{
    private readonly ContactService _contactService;

    public ContactAddViewModel(ContactService contactService)
    {
        _contactService = contactService;
    }

    [ObservableProperty]
    private Business.Models.Contact contact = new();

    [RelayCommand]
    private async Task Add()
    {
        _contactService.CreateContact(Contact);
        Contact = new();

        await Shell.Current.GoToAsync("..");
    }
}
