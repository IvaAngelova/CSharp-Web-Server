namespace MyWebServer.Server.Results.View
{
   public interface IViewEngine
    {
        string RenderHtml(string content, object model, string userId);
    }
}
