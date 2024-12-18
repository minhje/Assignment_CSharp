using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService(IContactRepository contactRepository) : IContactService
{
    private readonly IContactRepository _contactRepository = contactRepository;
    private readonly List<Contact> _contacts = [];
    private readonly FileService _fileService = new(@"c:\projects", "contacts.json");

    public bool CreateContact(Contact contact)
    {
        try
        {
            contact.Id = IdGenerator.GenerateUniqueId();
            _contacts.Add(contact);

            var result = _contactRepository.SaveContactListToFile(_contacts);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        return _contacts;
    }


}
