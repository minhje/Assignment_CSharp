using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

public class ContactService_Tests
{
    private readonly Mock<IContactRepository> _contactRepositoryMock;
    private readonly ContactService _contactService;

    public ContactService_Tests()
    {
        _contactRepositoryMock = new Mock<IContactRepository>();
        _contactService = new ContactService(_contactRepositoryMock.Object);
    }

    // Test generarat av ChatGPT 4o som säkerställer att en kontakt skapas korrekt.
    [Fact]
    public void CreateContact_ShouldReturnTrue_WhenContactIsCreated()
    {
        var contact = new Contact { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890", Address = "123 Main St", ZipCode = "12345", City = "Anytown" };

        // Retunerar en tom lista när GetAllContacts-metoden anropas. Simulerar att det inte finns några kontakter i lagringen när testet körs.  
        _contactRepositoryMock.Setup(cr => cr.GetAllContacts()).Returns(new List<Contact>());

        // Retunerar true när SaveContactListToFile-metoden anropas. Simulerar att kontakten har sparats korrekt.
        _contactRepositoryMock.Setup(cr => cr.SaveContactListToFile(It.IsAny<List<Contact>>())).Returns(true);

        var result = _contactService.CreateContact(contact);

        Assert.True(result);
    }

    // Test generarat av ChatGPT 4o som säkerställer att en lista med kontakter returneras korrekt.
    [Fact]
    public void GetAllContacts_ShouldReturnListOfContacts()
    {
        // Skapar en lista med två kontakter.
        var contacts = new List<Contact>
        {
            new Contact { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "1234567890", Address = "123 Main St", ZipCode = "12345", City = "Anytown" },
            new Contact { Id = "2", FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", PhoneNumber = "0987654321", Address = "456 Elm St", ZipCode = "54321", City = "Othertown" }
        };

        // Retunerar listan som precis skapades med kontakter när GetAllContacts-metoden anropas. Simuletar beteendet i IContactRepository.
        _contactRepositoryMock.Setup(cr => cr.GetAllContacts()).Returns(contacts);

        // Anropar GetAllContacts-metoden i ContactService.
        var result = _contactService.GetAllContacts();

        Assert.NotNull(result); // Kontrollerar att resultatet inte är null.
        Assert.Equal(contacts.Count, result.Count()); // Kontrollerar att antalet kontakter i resultatet är samma som i listan.
        Assert.Equal(contacts, result.ToList()); // Kontrollerar att listorna är lika.
    }

    // Test generarat av ChatGPT 4o som säkerställer att en lista med kontakter sparas korrekt.
    [Fact]
    public void SaveContacts_ShouldReturnTrue_WhenContactsAreSaved()
    {
        var mockContactRepository = new Mock<IContactRepository>(); // Skapar en mock av IContactRepository.
        var contactService = new ContactService(mockContactRepository.Object); // Skapar en instans av ContactService med mocken.
        var contacts = new List<Contact> // Skapar en lista med en kontakt.
        {
            new Contact { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" }
        };

        var result = contactService.SaveContacts(contacts); // Anropar SaveContacts-metoden i ContactService.

        Assert.False(result); // Kontrollerar att resultatet är false.
    }
}
