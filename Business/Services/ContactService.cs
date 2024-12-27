using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public bool CreateContact(Contact contact)
    {
        try
        {
            contact.Id = IdGenerator.GenerateUniqueId();
            var contacts = _contactRepository.GetAllContacts();
            contacts.Add(contact);

            return _contactRepository.SaveContactListToFile(contacts);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool SaveContacts(List<Contact> contacts)
    {
        return _contactRepository.SaveContactListToFile(contacts);
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        return _contactRepository.GetAllContacts();
    }

}
