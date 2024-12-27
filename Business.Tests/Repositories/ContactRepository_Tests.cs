using Business.Interfaces;
using Business.Models;
using Moq;
using Xunit;

namespace Business.Tests.Repositories;

public class ContactRepository_Tests
{
    private readonly Mock<IContactRepository> _contactRepositoryMock;

    public ContactRepository_Tests()
    {
        _contactRepositoryMock = new Mock<IContactRepository>();
    }


    // Tester generarade av ChatGPT 4o


    // Testar metoden SaveContactListToFile i ContactRepository, ska retunera en lista med kontakter
    [Fact]
    public void GetAllContacts_ShouldReturnListOfContacts()
    {

        // Skapar en lista med kontakter
        var contacts = new List<Contact>
        {
            new Contact { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890", Address = "123 Main St", ZipCode = "12345", City = "Anytown" },
            new Contact { Id = "2", FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", PhoneNumber = "0987654321", Address = "456 Elm St", ZipCode = "54321", City = "Othertown" }
        };

        // Sätter upp mocken för GetAllContacts
        _contactRepositoryMock.Setup(cr => cr.GetAllContacts()).Returns(contacts);

        var result = _contactRepositoryMock.Object.GetAllContacts();

        Assert.NotNull(result); // Kontrollerar att resultatet inte är null
        Assert.Equal(contacts.Count, result.Count()); // Kontrollerar antalet kontakter
        Assert.Equal(contacts, result); // Kontrollerar att listorna är lika
    }


    // Testar metoden GetContactsFromFile i ContactRepository. Returnerar en lista med kontakter
    [Fact]
    public void GetContactsFromFile_ShouldReturnListOfContacts()
    {
        // Skapar en lista med kontakter
        var expectedContacts = new List<Contact>
        {
            new Contact { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
            new Contact { Id = "2", FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" }
        };

        // Sätter upp mocken för GetContactsFromFile
        _contactRepositoryMock.Setup(repo => repo.GetContactsFromFile()).Returns(expectedContacts);

        var result = _contactRepositoryMock.Object.GetContactsFromFile();

        Assert.Equal(expectedContacts, result); // Kontrollerar att listorna är lika
    }

    // Testar metoden SaveContactListToFile i ContactRepository, returnerar true om kontakterna sparas till fil
    [Fact]
    public void SaveContactListToFile_ShouldReturnTrue_WhenContactsAreSaved()
    {
        // Skapar en lista med kontakter
        var contactsToSave = new List<Contact>
        {
            new Contact { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
            new Contact { Id = "2", FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" }
        };

        // Sätter upp mocken för SaveContactListToFile
        _contactRepositoryMock.Setup(repo => repo.SaveContactListToFile(contactsToSave)).Returns(true);

        var result = _contactRepositoryMock.Object.SaveContactListToFile(contactsToSave);

        Assert.True(result); // Kontrollerar att resultatet är true
    }
}
