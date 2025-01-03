using Business.Interfaces;
using Business.Repositories;
using Business.Services;
using Microsoft.Extensions.Logging;
using MobileApp.Pages;
using MobileApp.ViewModels;

namespace MobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton<ContactAddViewModel>();
            builder.Services.AddSingleton<ContactAddPage>();

            builder.Services.AddSingleton<ContactListViewModel>();
            builder.Services.AddSingleton<ContactListPage>();


            builder.Services.AddSingleton<ContactEditViewModel>();
            builder.Services.AddSingleton<ContactEditPage>();

            builder.Services.AddSingleton<IFileService>(sp => new FileService("Data", "contacts.json"));
            builder.Services.AddSingleton<IContactRepository, ContactRepository>();
            builder.Services.AddSingleton<IContactService, ContactService>();
            builder.Services.AddTransient<ContactService>();

            builder.Logging.AddDebug();
            return builder.Build();
        }
    }
}
