namespace MyWebServer.Server.Results.View
{
    public interface IView
    {
        string ExecuteTemplate(object model, string user);
    }
}
