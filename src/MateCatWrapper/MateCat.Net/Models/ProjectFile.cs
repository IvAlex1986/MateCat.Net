using System;
using System.IO;

namespace MateCat.Net.Models
{
    /// <summary>
    /// The file to be uploaded to project
    /// </summary>
    public class ProjectFile
    {
        public ProjectFile(String fileName, Stream stream)
        {
            FileName = fileName;
            Stream = stream;
        }

        public ProjectFile(FileInfo fileInfo)
        {
            FileName = fileInfo.Name;
            Stream = fileInfo.OpenRead();
        }

        public ProjectFile(String filePath)
            : this(new FileInfo(filePath))
        {
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public String FileName { get; set; }

        /// <summary>
        /// Gets or sets the stream.
        /// </summary>
        /// <value>
        /// The stream.
        /// </value>
        public Stream Stream { get; set; }
    }
}
