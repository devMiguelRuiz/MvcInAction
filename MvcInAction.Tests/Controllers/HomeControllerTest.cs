using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcInAction.Controllers;
using System.Web.Mvc;

namespace MvcInAction.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void WhenIndexActionRequested_ViewResultIsNotNull()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenIndexActionRequested_ViewResultIsNotNullAndHasValidName()
        {
            // arrange
            var controller = new HomeController();

            // act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName, "Index");
        }

        [TestMethod]
        public void WhenIndexActionRequested_ViewResultIsNotNullAndViewDataIsNotNullAndHasOneElement()
        {
            // arrange
            var controller = new HomeController();

            // act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData);
            Assert.AreEqual(1, result.ViewData.Count);
        }
    }
}