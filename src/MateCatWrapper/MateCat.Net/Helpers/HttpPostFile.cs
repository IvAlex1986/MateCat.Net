using System;
using System.IO;

namespace MateCat.Net.Helpers
{
    internal class HttpPostFile
    {
        public HttpPostFile()
        {
            ContentType = "application/octet-stream";
        }

        public String Name { get; set; }

        public String FileName { get; set; }

        public Stream Stream { get; set; }

        public String ContentType { get; set; }
    }
}
