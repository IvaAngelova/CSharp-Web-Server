﻿using System.Collections.Generic;

using SIS.Data.Models;

namespace SIS.Data
{
    public class MyDbContext : IData
    {
        public MyDbContext()
            => this.Cats = new List<Cat>
            {
                new Cat
                {
                    Id =1,
                    Name="Sharo",
                    Age=5
                },
                new Cat
                {
                    Id=2,
                    Name="Lady",
                    Age = 13
                }
            };

        public IEnumerable<Cat> Cats { get; }
    }
}
