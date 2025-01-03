using Business.Models;

namespace Business.Interfaces
{
    public interface IContactService
    {
        bool CreateContact(Contact contact);
        IEnumerable<Contact> GetAllContacts();
        bool SaveContacts(List<Contact> contacts);
        bool DeleteContact(Contact contact);
        //Task UpdateContact(Contact contact);
    }
}