using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;
    private readonly List<Contact> _contacts;
    private readonly FileService _fileService;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
        _fileService = new FileService(@"c:\projects\Business", "contacts.json");
        _contacts = LoadContacts();
    }

    public bool CreateContact(Contact contact)
    {
        try
        {
            contact.Id = IdGenerator.GenerateUniqueId();
            _contacts.Add(contact);

            return SaveContacts();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    private List<Contact> LoadContacts()
    {
        var content = _fileService.GetContentFromFile();
        if (string.IsNullOrEmpty(content))
        {
            return new List<Contact>();
        }

        return JsonSerializer.Deserialize<List<Contact>>(content)!;
    }

    private bool SaveContacts()
    {
        var content = JsonSerializer.Serialize(_contacts);
        return _fileService.SaveContentToFile(content);
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        return _contacts;
    }
}
