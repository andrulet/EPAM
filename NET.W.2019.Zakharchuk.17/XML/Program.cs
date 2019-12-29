using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML.Logic;
using static XML.Logic.CreateXML;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            Provider provider = new Provider(@"D:\Учеба\C#\EPAM\День 17\XML\XML\url.txt", new Parser());
            CreateXmlFromUrl(provider.Load(), @"D:\Учеба\C#\EPAM\День 17\XML\XML\xml.xml");
        }
    }
}
