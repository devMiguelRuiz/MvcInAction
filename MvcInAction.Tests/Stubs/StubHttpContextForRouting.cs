using System.Web;

namespace MvcInAction.Tests.Stubs
{
    public class StubHttpContextForRouting : HttpContextBase
    {
        private readonly StubHttpRequestForRouting _request;
        private readonly StubHttpResponseForRouting _response;

        public StubHttpContextForRouting(string appPath = "/", string requestUrl = "~/")
        {
            _request = new StubHttpRequestForRouting(appPath, requestUrl);
            _response = new StubHttpResponseForRouting();
        }

        public override HttpRequestBase Request => _request;

        public override HttpResponseBase Response => _response;
    }
}