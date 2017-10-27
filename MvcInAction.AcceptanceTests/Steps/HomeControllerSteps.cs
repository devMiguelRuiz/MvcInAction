using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcInAction.Controllers;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace MvcInAction.AcceptanceTests.Steps
{
    [Binding]
    public class HomeControllerSteps
    {
        // this field help us to store the ViewResult object
        private ViewResult _indexResult;

        [Given(@"The trainee have navigated to the Home page")]
        public void GivenTheTraineeHaveNavigatedToTheHomePage()
        {
            // we simulate we go to the Home page
            // this is Home/Index/
            var controller = new HomeController();
            _indexResult = controller.Index() as ViewResult;
        }

        [When(@"The trainee is in the Home page")]
        public void WhenTheTraineeIsInTheHomePage()
        {
            // in order to know i am at the home page we can verify the name of the view
            Assert.IsNotNull(_indexResult);
            Assert.AreEqual(_indexResult.ViewName, "Index");
        }

        [Then(@"The Page title should say ""(.*)""")]
        public void ThenThePageTitleShouldSay(string p0)
        {
            // lets verify if the title is correct
            var title = _indexResult.ViewBag.Title;

            Assert.AreEqual(p0, title);
        }
    }
}