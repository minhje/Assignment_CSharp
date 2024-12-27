using Business.Interfaces;
using Business.Repositories;
using Business.Services;
using MainApp.Dialogs;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection() 
    .AddSingleton<IFileService>(new FileService("Data", "contacts.json"))
    .AddSingleton<FileService>() // Generarad av ChatGPT 4o för att lösa "System.InvalidOperationException" error. 
    .AddSingleton<IContactRepository, ContactRepository>()
    .AddSingleton<IContactService, ContactService>()
    .AddTransient<MenuDialog>()
    .BuildServiceProvider();

var menuDialog = serviceProvider.GetRequiredService<MenuDialog>();
menuDialog.MainMenu();