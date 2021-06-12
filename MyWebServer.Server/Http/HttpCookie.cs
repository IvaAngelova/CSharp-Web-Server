﻿using MyWebServer.Server.Common;

namespace MyWebServer.Server.Http
{
    public class HttpCookie
    {
        public HttpCookie(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            this.Name = name;
            this.Value = value;
        }

        public string Name { get; init; }

        public string Value { get; set; }

        public override string ToString()
            => $"{this.Name}={this.Value}";
    }
}
