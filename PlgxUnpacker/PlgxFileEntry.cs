using System;

namespace PlgxUnpacker
{
    /// <summary>
    /// This class represents a file entry in a PLGX file.
    /// </summary>
    public sealed class PlgxFileEntry
    {
        /// <summary>
        /// Gets the name of the file entry.
        /// <para>This name represents a relative path to the directory structure of the original plugin folder.</para>
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the unpacked binary content of the file entry.
        /// </summary>
        public byte[] Content { get; private set; }

        /// <summary>
        /// <see cref="PlgxFileEntry"/> constructor.
        /// </summary>
        /// <param name="name">The name of the file entry.</param>
        /// <param name="content">The unpacked binary content of the file entry.</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal PlgxFileEntry(string name, byte[] content)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Content = content ?? throw new ArgumentNullException(nameof(content));
        }
    }
}
