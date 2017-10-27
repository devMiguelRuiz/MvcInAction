using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcInAction.Tests.Stubs;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcInAction.Tests.Routes
{
    [TestClass]
    public class RoutesTest
    {
        [TestMethod]
        public void WhenHomePathIsEntered_DefaultRouteIsUsed()
        {
            // Arrange
            var context = new StubHttpContextForRouting("~/");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);
        }

        [TestMethod]
        public void WhenConstraintUrlIsEntered_ConstraintRouteIsUsed()
        {
            // Arrange
            var context = new StubHttpContextForRouting(requestUrl: "~/Constraint/1");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Constraint", routeData.Values["controller"]);
            Assert.AreEqual("Constraint", routeData.Values["action"]);
            Assert.AreEqual("1", routeData.Values["id"]);
        }

        [TestMethod]
        public void WhenConstraintUrlIsEntered_NoConstraintRouteIsUsed()
        {
            // Arrange
            var context = new StubHttpContextForRouting(requestUrl: "~/Constraint/HolaMundo");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            RouteData routeData = routes.GetRouteData(context);

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Constraint", routeData.Values["controller"]);
            Assert.AreEqual("NoConstraint", routeData.Values["action"]);
            Assert.AreEqual("HolaMundo", routeData.Values["id"]);
        }
    }
}
