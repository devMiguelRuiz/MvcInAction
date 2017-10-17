using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace MvcInAction.Utilities.ActionResults
{
    public class XmlActionResult<T>: ActionResult
    {
        private readonly T _data;
        private readonly string _fileName;

        public XmlActionResult(T contentData, string fileName)
        {
            _data = contentData;
            _fileName = fileName;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpContextBase httpContextBase = context.HttpContext;
            httpContextBase.Response.Buffer = true;
            httpContextBase.Response.Clear();
            httpContextBase.Response.AddHeader("content-disposition", $"attachment; filename={_fileName}");
            httpContextBase.Response.ContentType = "text/xml";

            using (var xmlWriter = new StringWriter())
            {
                var xml = new XmlSerializer(typeof(T));
                xml.Serialize(xmlWriter, _data);
                httpContextBase.Response.Write(xmlWriter);
            }
        }


    }
}