using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace Business.Tests.Services;

public class ContactService_Tests
{
    private readonly Mock<IContactRepository> _contactRepositoryMock;
    private readonly ContactService _contactService;

    public ContactService_Tests()
    {
        _contactRepositoryMock = new Mock<IContactRepository>();
        _contactService = new ContactService(_contactRepositoryMock.Object);
    }

    [Fact]
    public void CreateContact_ShouldReturnTrue_WhenContactIsCreated()
    {
        var contact = ContactFactory.Create();
        var contacts = new List<Contact>() { contact };

        _contactRepositoryMock.Setup(cr => cr.SaveContactListToFile(contacts)).Returns(true);

        var result = _contactService.CreateContact(contact);

        Assert.True(result);

        //expected contacts kan läggas här också 
    }

    [Fact]
    public void GetAllContacts_ShouldReturnListOfContact()
    {

        var result = _contactService.GetAllContacts();

        Assert.NotNull(result);




        _contactRepositoryMock.Setup(cr => cr.GetContactsFromFile()).Returns(expectedContacts);
    }
}
