using Business.Models;

namespace Business.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        List<Contact> GetContactsFromFile();
        bool SaveContactListToFile(List<Contact> list);
    }
}