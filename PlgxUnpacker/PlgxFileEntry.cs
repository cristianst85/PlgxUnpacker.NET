using System;

namespace PlgxUnpacker
{
    public class PlgxFileEntry
    {
        public string Name { get; private set; }

        public byte[] Content { get; private set; }

        public PlgxFileEntry(string name, byte[] content)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Content = content ?? throw new ArgumentNullException(nameof(content));
        }
    }
}
