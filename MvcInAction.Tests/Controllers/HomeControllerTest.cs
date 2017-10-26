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
            // arrange and act
            ViewResult result = null;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenIndexActionRequested_ViewResultIsNotNullAndHasValidName()
        {
            // arrange and act
            ViewResult result = null;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName, "Index");
        }

        [TestMethod]
        public void WhenIndexActionRequested_ViewResultIsNotNullAndViewDataIsNotNullButEmpty()
        {
            // Arrange and act
            ViewResult result = null;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData);
            Assert.AreEqual(result.ViewData.Count, 0);
        }
    }
}