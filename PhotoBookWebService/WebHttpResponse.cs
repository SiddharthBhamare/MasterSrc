using System.Net;

namespace PhotoBookWebService
{
    public class WebHttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
        public string Description { get; set; }
        public object ExtraData { get; set; }
        public WebHttpResponse() { }
        public bool IsSuccess { get; set; }
    }
}
