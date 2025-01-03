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

    public Task UpdateContact(Contact contact)
    {
        try
        {
            var contacts = _contactRepository.GetAllContacts();
            var existingContact = contacts.FirstOrDefault(c => c.Id == contact.Id);

            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                existingContact.PhoneNumber = contact.PhoneNumber;
                existingContact.Address = contact.Address;
                existingContact.ZipCode = contact.ZipCode;
                existingContact.City = contact.City;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return Task.CompletedTask;
    }

    public bool DeleteContact(Contact contact)
    {
        try
        {
            var contacts = _contactRepository.GetAllContacts();
            contacts.Remove(contact);
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
