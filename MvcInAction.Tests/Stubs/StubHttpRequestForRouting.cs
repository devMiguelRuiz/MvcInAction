using System.Collections.Specialized;
using System.Web;

namespace MvcInAction.Tests.Stubs
{
    public class StubHttpRequestForRouting : HttpRequestBase
    {
        private readonly string _appPath;
        private readonly string _requestUrl;

        public StubHttpRequestForRouting(string appPath, string requestUrl)
        {
            _appPath = appPath;
            _requestUrl = requestUrl;
        }

        public override string ApplicationPath => _appPath;

        public override string AppRelativeCurrentExecutionFilePath => _requestUrl;

        public override string PathInfo => "";

        public override NameValueCollection ServerVariables => new NameValueCollection();
    }
}