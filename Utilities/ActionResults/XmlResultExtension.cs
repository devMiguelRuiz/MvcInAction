using System.Web.Mvc;

namespace MvcInAction.Utilities.ActionResults
{
    public static class XmlResultExtension
    {
        public static ActionResult XmlFileResult<T>(this Controller controller, T contentData, string fileName)
        {
            return new XmlActionResult<T>(contentData, fileName);
        }
    }
}