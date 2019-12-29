using System;
using System.Collections.Generic;

namespace XML.Logic
{
    public interface IProvider
    {
        IEnumerable<URL> Load();
    }
}
