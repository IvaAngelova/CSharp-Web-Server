using System.Collections.Generic;

using SIS.Data.Models;

namespace SIS.Data
{
    public interface IData
    {
        IEnumerable<Cat> Cats { get; }
    }
}
