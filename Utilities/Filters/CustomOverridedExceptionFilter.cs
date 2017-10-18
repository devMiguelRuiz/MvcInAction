using System.Web.Mvc;

namespace MvcInAction.Utilities.Filters
{
    public class CustomOverridedExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            var dictionary = new ViewDataDictionary
            {
                {"Controller", filterContext.RouteData.Values["controller"]},
                {"Action", filterContext.RouteData.Values["action"]},
                {"Error", filterContext.Exception.Message}
            };

            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(dictionary)
            };

            base.OnException(filterContext);
        }
    }
}