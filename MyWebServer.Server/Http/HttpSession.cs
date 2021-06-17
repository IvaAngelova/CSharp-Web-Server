using MyWebServer.Server.Common;
using System.Collections.Generic;

namespace MyWebServer.Server.Http
{
    public class HttpSession
    {
        public const string SessionCookieName = "MyWebServerSID";
        
        private Dictionary<string, string> data;

        public HttpSession(string id)
        {
            Guard.AgainstNull(id, nameof(id));

            this.Id = id;
            this.data = new Dictionary<string, string>();
        }

        public string Id { get; init; }

        public int Count => this.data.Count;
        
        public string this[string key]
        {
            get => this.data[key];
            set => this.data[key] = value;
        }

        public bool ContainsKey(string key)
            => this.data.ContainsKey(key);
<<<<<<< HEAD

        public void Remove(string key)
        {
            if (this.data.ContainsKey(key))
            {
                this.data.Remove(key);
            }
        }
=======
>>>>>>> ba9ce9cc7bc97caa059ea28a9c51bc5c13644b7e
    }
}