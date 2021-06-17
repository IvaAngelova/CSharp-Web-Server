namespace MyWebServer.Server.Http
{
    public class HttpContentType
    {
        public const string PlainText = "text/plain; charset=UTF-8";
        public const string Html = "text/html; charset=UTF-8";
        public const string FourmUrlEncoded = "application/x-www-form-urlencoded";

        public static string GetByFileExtention(string fileExtension)
            => fileExtension switch
            {
                "css" => "text/css",
                "js" => "application/javascript",
                "jpg" or "jpeg" => "image/jpeg",
                "png" => "image/png",
                _ => PlainText
            };
    }
}
