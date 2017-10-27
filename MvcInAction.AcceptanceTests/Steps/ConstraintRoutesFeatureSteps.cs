using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcInAction.Tests.Stubs;
using System.Web.Routing;
using TechTalk.SpecFlow;

namespace MvcInAction.AcceptanceTests.Steps
{
    [Binding]
    public class ConstraintRoutesFeatureSteps
    {
        private StubHttpContextForRouting _context;
        private RouteCollection _routes;
        private RouteData _routeData;
        private string _url;

        [Given(@"I have entered ""(.*)"" as url pattern")]
        public void GivenIHaveEnteredAsUrlPattern(string p0)
        {
            _url = p0;
        }

        [When(@"I hit enter")]
        public void WhenIHitEnter()
        {
            _context = new StubHttpContextForRouting(requestUrl: _url);
            _routes = new RouteCollection();
            RouteConfig.RegisterRoutes(_routes);
            _routeData = _routes.GetRouteData(_context);
        }

        [Then(@"the controller should be ""(.*)""")]
        public void ThenTheControllerShouldBe(string p0)
        {
            Assert.AreEqual(p0, _routeData.Values["controller"]);
        }

        [Then(@"the action should be ""(.*)""")]
        public void ThenTheActionShouldBe(string p0)
        {
            Assert.AreEqual(p0, _routeData.Values["action"]);
        }

        [Then(@"the id should be ""(.*)""")]
        public void ThenTheIdShouldBe(string p0)
        {
            Assert.AreEqual(p0, _routeData.Values["id"]);
        }
    }
}