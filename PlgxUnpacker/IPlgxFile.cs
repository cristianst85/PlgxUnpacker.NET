using System.Collections.Generic;

namespace PlgxUnpacker
{
    /// <summary>
    /// Provides an interface for <see cref="PlgxFile"/>.
    /// </summary>
    public interface IPlgxFile
    {
        /// <summary>
        /// The PLGX file information metadata.
        /// </summary>
        PlgxFileInfo Info { get; }

        /// <summary>
        /// The absolute file path of the PLGX file.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// A collection of unpacked file entries contained within the PLGX file.
        /// </summary>
        /// <returns>A collection of <see cref="PlgxFileEntry"/>.</returns>
        IEnumerable<PlgxFileEntry> GetUnpackedFiles();

        /// <summary>
        /// Unpacks the PLGX file content to the given directory path.
        /// </summary>
        /// <param name="directoryPath">The directory path to unpack the PLGX file content to.</param>
        void UnpackTo(string directoryPath);
    }
}
