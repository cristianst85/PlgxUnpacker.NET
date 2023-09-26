using System.Collections.Generic;

namespace PlgxUnpacker
{
    public interface IPlgxFile
    {
        PlgxFileInfo Info { get; }

        string Path { get; }

        IEnumerable<PlgxFileEntry> GetUnpackedFiles();

        void UnpackTo(string outputDirectoryPath);
    }
}
