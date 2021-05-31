using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

using MyWebServer.Server.Http;

namespace MyWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress iPAddress;
        private readonly int port;
        private readonly TcpListener listener;

        public HttpServer(string ipAddress, int port)
        {
            this.iPAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.listener = new TcpListener(this.iPAddress, port);
        }

        public async Task Start()
        {
            this.listener.Start();

            Console.WriteLine($"Server started on port {port}...");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await this.listener.AcceptTcpClientAsync();

                var networkStream = connection.GetStream();

                var requestText = await this.ReadRequest(networkStream);

                Console.WriteLine(requestText);

                var request = HttpRequest.Parse(requestText);

                await WriteResponse(networkStream);
                
                connection.Close();
            }
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();

            while (networkStream.DataAvailable)
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            return requestBuilder.ToString().Trim();
        }

        private async Task WriteResponse(NetworkStream networkStream)
        {
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
        }
    }
}
