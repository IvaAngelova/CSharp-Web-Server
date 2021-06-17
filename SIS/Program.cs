using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SIS
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            // http://localhost:8080

            //Connection with browser
            var address = IPAddress.Parse("127.0.0.1");
            var port = 8080;

            var serverListener = new TcpListener(address, port);

            serverListener.Start();

            Console.WriteLine($"Server started on port {port}...");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await serverListener.AcceptTcpClientAsync();

                var networkStream = connection.GetStream();

                //Request to browser
                var bufferLength = 1024;
                var buffer = new byte[bufferLength];

                var requestBuilder = new StringBuilder();

                while (networkStream.DataAvailable)
                {
                    var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                    requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                }

                
                Console.WriteLine(requestBuilder.ToString());

                //Response to browser
                var content = @"
<html>
    <head>
        <link rel=""icon"" href=""data:, "">
    </head>
    <body>
        Hello from my server!
    </body>
</html>";
                var contentLength = Encoding.UTF8.GetByteCount(content);

                var response = $@"
HTTP/1.1 200 OK
Server: My Web Server
Date: {DateTime.UtcNow.ToString("r")}
Content-Length: {contentLength}
Content-Type: text/html; charset=UTF-8

{content}";

                var responseBytes = Encoding.UTF8.GetBytes(response);

                await networkStream.WriteAsync(responseBytes);

                connection.Close();
            }
        }
    }
}
