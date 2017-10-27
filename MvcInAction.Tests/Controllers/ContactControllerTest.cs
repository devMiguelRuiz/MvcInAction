using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcInAction.Controllers;
using MvcInAction.Data.Entities;
using MvcInAction.Data.Repositories;
using MvcInAction.Utilities.ActionResults;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcInAction.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTest
    {
        private IContactRepository _mockRepository;

        [TestInitialize]
        public void Setup()
        {
            var contacts = new List<Contact>
            {
                new Contact {Id = 1, FirstName = "Juan Fake", LastName = "Perez", Email = "jPerez@epam.com"},
                new Contact {Id= 2, FirstName = "Oscar Fake", LastName = "Lopez", Email = "oLopez@epam.com"},
                new Contact {Id = 3,FirstName = "Miguel Fake", LastName = "Ruiz", Email = "mRuiz@epam.com"}
            };

            var repo = new Mock<IContactRepository>();

            // we set to the mock object that if "GetAll" is called we return the hardcoded contacts
            repo.Setup(r => r.GetAll()).Returns(contacts);

            // we set the mock to simulate the find, looking into the Ienumerable variable
            repo.Setup(mr => mr.Find(It.IsAny<int>())).Returns((int id) => contacts.FirstOrDefault(x => x.Id == id));

            // we set the mock to simulate the Add action with an especific callback handler
            repo.Setup(mr => mr.Add(It.IsAny<Contact>()))
                .Callback((Contact newContact) =>
                {
                    AddOrEdit(newContact, contacts);
                });

            // we set the mock to simulate the Edit action with an especific callback handler
            repo.Setup(mr => mr.Edit(It.IsAny<Contact>()))
                .Callback((Contact newContact) =>
                {
                    AddOrEdit(newContact, contacts);
                });

            // the we assign to the repository the mocked repo
            _mockRepository = repo.Object;
        }

        private static void AddOrEdit(Contact contact, ICollection<Contact> contacts)
        {
            if (contact.Id.Equals(default(int)))
            {
                contact.Id = contacts.Max(x => x.Id) + 1;
                contacts.Add(contact);
                return;
            }

            Contact original = contacts.Single(q => q.Id == contact.Id);
            original.Email = contact.Email;
            original.FirstName = contact.Email;
            original.LastName = contact.LastName;
        }

        [TestMethod]
        public void WhenIndexActionRequested_ViewResultIsNotNull()
        {
            // arrange
            var controller = new ContactController(_mockRepository);

            // Act
            var viewResult = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult);
        }

        [TestMethod]
        public void WhenIndexActionRequested_ViewResultIsNotNullAndIsValidModel()
        {
            // arrange
            var controller = new ContactController(_mockRepository);

            // Act
            var viewResult = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(viewResult.Model);
            Assert.IsInstanceOfType(viewResult.Model, typeof(IEnumerable<Contact>));
        }

        [TestMethod]
        public void WhenGetXmlActionRequested_ResultIsNotNullAndIsXmlActionResult()
        {
            // arrange
            var controller = new ContactController(_mockRepository);

            // Act
            var viewResult = controller.GetXml();

            // Assert
            Assert.IsNotNull(viewResult);
            Assert.IsInstanceOfType(viewResult, typeof(XmlActionResult<IEnumerable<Contact>>));
        }

        [TestMethod]
        public void WhenDetailsActionRequested_ViewResultIsNotNullAndModelIsTheExpected()
        {
            // arrange
            var controller = new ContactController(_mockRepository);
            var expected = _mockRepository.Find(1);

            // Act
            var viewResult = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult);
            Assert.AreEqual(viewResult.Model, expected);
        }

        [TestMethod]
        public void WhenAddActionRequested_ResultIsNotNullAndAdditionIsSuccess()
        {
            // arrange
            var controller = new ContactController(_mockRepository);
            var newContact = new Contact { FirstName = "Arnoldo", LastName = "Fake", Email = "hola@hola.com" };
            int countBeforeAddition = _mockRepository.GetAll().Count();

            // Act
            var viewResult = controller.Create(newContact) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(viewResult);

            int counterAfterAdition = _mockRepository.GetAll().Count();

            Assert.AreEqual(countBeforeAddition + 1, counterAfterAdition);
        }
    }
}
