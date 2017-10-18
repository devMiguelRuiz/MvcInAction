using System.Web.Mvc;

namespace MvcInAction.Utilities.Filters
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
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
        }
    }
}