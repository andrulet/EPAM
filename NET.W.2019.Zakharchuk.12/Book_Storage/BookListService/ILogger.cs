using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Storage
{
    public interface ILogger
    {
        void Trace(string massage);
        void Debug(string message);
        void Info(string message);        
        void Error(string message);        
    }
}
