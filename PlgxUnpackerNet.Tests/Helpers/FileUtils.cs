using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace PlgxUnpackerNet.Tests.Helpers
{
    internal class FileUtils
    {
        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "Dispose is idempotent")]
        internal static void CreateFileWithRandomData(string filePath, long size)
        {
            if (File.Exists(filePath))
            {
                throw new Exception(string.Format("File '{0}' already exists.", filePath));
            }

            if (size < 0)
            {
                throw new ArgumentException("File size cannot be less than zero.", "size");
            }

            var random = new Random();

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (var binaryWriter = new BinaryWriter(fileStream))
                {
                    while (binaryWriter.BaseStream.Length <= size)
                    {
                        byte[] buffer = new byte[Math.Min(size, 4096)];
                        random.NextBytes(buffer);
                        binaryWriter.Write(buffer);
                    }
                }
            }
        }
    }
}
