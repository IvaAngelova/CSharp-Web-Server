using MyWebServer.Server.Http;

namespace MyWebServer.Server.Responses
{
    public class ContentResponse : HttpResponse
    {
        public ContentResponse(string content, string contentType)
            : base(HttpStatusCode.OK)
        {
            this.PrepareContent(content, contentType);
        }
    }
}
