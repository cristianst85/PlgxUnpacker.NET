using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace PlgxUnpacker
{
    public class PlgxFile : IPlgxFile
    {
        public static string Extension
        {
            get
            {
                return ".plgx";
            }
        }

        public string Path { get; private set; }

        public PlgxFileInfo Info { get; private set; }

        private PlgxFile(string filePath, PlgxFileInfo plgxFileInfo)
        {
            this.Path = filePath;
            this.Info = plgxFileInfo;
        }

        public static PlgxFile LoadFromFile(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            filePath = System.IO.Path.GetFullPath(filePath);

            if (!IsPlgxFile(filePath))
            {
                throw new Exception(Properties.Resource.InvalidKeePassPlgxFile);
            }

            var plgxFileInfo = GetPlgxFileInfo(filePath);

            return new PlgxFile(filePath, plgxFileInfo);
        }

        public IEnumerable<PlgxFileEntry> GetUnpackedFiles()
        {
            var filesStartPattern = BitConverter.GetBytes(PlgxFileConstants.FilesStartPattern);

            using (var fileStream = File.Open(Path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    // Advance to the file list.
                    var bytesCount = 512;
                    var filesStartPosition = Search(binaryReader.ReadBytes(bytesCount), filesStartPattern);

                    if (filesStartPosition == -1)
                    {
                        throw new Exception(Properties.Resource.FileListWasNotFound);
                    }

                    fileStream.Position = fileStream.Position - bytesCount + filesStartPosition + 14;

                    while (true)
                    {
                        var size = binaryReader.ReadInt32();

                        if (size < 1)
                        {
                            break;
                        }

                        var value = binaryReader.ReadBytes(size);

                        // Filename.
                        var fileName = Encoding.UTF8.GetString(value);
                        fileStream.Position += 2; // Skip type.

                        // GZip file size.
                        size = binaryReader.ReadInt32();

                        using (var decompressedStream = GZipDecompress(binaryReader.ReadBytes(size)))
                        {
                            // Remove relative path.
                            fileName = fileName.Replace("../", string.Empty).Replace(@"..\", string.Empty);

                            // A size of zero means there is an empty file.
                            if (decompressedStream.Length > 0 || size == 0)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    decompressedStream.Seek(0, SeekOrigin.Begin);
                                    decompressedStream.CopyTo(memoryStream);

                                    yield return new PlgxFileEntry(fileName, memoryStream.ToArray());
                                }
                            }
                            else
                            {
                                throw new Exception($"Cannot unpack file '{fileName}'.");
                            }

                            fileStream.Position += 14;
                        }
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "Dispose is idempotent")]
        public static bool IsPlgxFile(string filePath)
        {
            using (var fileStream = GetFileStream(filePath))
            {
                if (fileStream.Length < sizeof(int))
                {
                    return false;
                }

                using (var binaryReader = new BinaryReader(fileStream))
                {
                    return binaryReader.ReadInt32() == PlgxFileConstants.Magic;
                }
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "Dispose is idempotent")]
        public static PlgxFileInfo GetPlgxFileInfo(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            filePath = System.IO.Path.GetFullPath(filePath);

            if (!IsPlgxFile(filePath))
            {
                throw new Exception(Properties.Resource.InvalidKeePassPlgxFile);
            }

            using (var fileStream = GetFileStream(filePath))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    // Plugin name.
                    fileStream.Position = 0x24;
                    var size = binaryReader.ReadInt32();
                    var value = binaryReader.ReadBytes(size);
                    var pluginName = Encoding.UTF8.GetString(value);

                    // Plugin creation date.
                    fileStream.Position += 2; // Skip type.
                    size = binaryReader.ReadInt32();
                    value = binaryReader.ReadBytes(size);
                    var creationDate = DateTime.Parse(Encoding.UTF8.GetString(value));

                    // Plugin creation tool name.
                    fileStream.Position += 2; // Skip type.
                    size = binaryReader.ReadInt32();
                    value = binaryReader.ReadBytes(size);
                    var creationToolName = Encoding.UTF8.GetString(value);

                    var filesStartPattern = BitConverter.GetBytes(PlgxFileConstants.FilesStartPattern);

                    // Advance to the file list.
                    var bytesCount = 512;
                    var filesStartPosition = Search(binaryReader.ReadBytes(bytesCount), filesStartPattern);

                    if (filesStartPosition == -1)
                    {
                        throw new Exception(Properties.Resource.FileListWasNotFound);
                    }

                    fileStream.Position = fileStream.Position - bytesCount + filesStartPosition + 14;

                    var fileNames = new List<string>();

                    while (true)
                    {
                        size = binaryReader.ReadInt32();

                        if (size < 1)
                        {
                            break;
                        }

                        value = binaryReader.ReadBytes(size);

                        // Filename.
                        var fileName = Encoding.UTF8.GetString(value);
                        fileStream.Position += 2; // Skip type.

                        // GZip file size.
                        size = binaryReader.ReadInt32();

                        using (var decompressedStream = GZipDecompress(binaryReader.ReadBytes(size)))
                        {
                            // Remove relative path.
                            fileName = fileName.Replace("../", string.Empty).Replace(@"..\", string.Empty);
                            fileNames.Add(fileName);
                            fileStream.Position += 14;
                        }
                    }

                    return new PlgxFileInfo(pluginName, creationDate, creationToolName, fileNames);
                }
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "Dispose is idempotent")]
        public void UnpackTo(string outputDirectoryPath)
        {
            if (outputDirectoryPath == null)
            {
                throw new ArgumentNullException(nameof(outputDirectoryPath));
            }

            if (!Directory.Exists(outputDirectoryPath))
            {
                throw new Exception("Output directory does not exist.");
            }

            if (Directory.Exists(outputDirectoryPath) && Directory.GetFiles(outputDirectoryPath).Length > 0 || Directory.GetDirectories(outputDirectoryPath).Length > 0)
            {
                throw new Exception("Output directory must be empty.");
            }

            outputDirectoryPath = System.IO.Path.GetFullPath(outputDirectoryPath);

            if (!IsPlgxFile(Path))
            {
                throw new Exception(Properties.Resource.InvalidKeePassPlgxFile);
            }

            var filesStartPattern = BitConverter.GetBytes(PlgxFileConstants.FilesStartPattern);

            using (var fileStream = File.Open(Path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    // Advance to the file list.
                    var bytesCount = 512;
                    var filesStartPosition = Search(binaryReader.ReadBytes(bytesCount), filesStartPattern);

                    if (filesStartPosition == -1)
                    {
                        throw new Exception(Properties.Resource.FileListWasNotFound);
                    }

                    fileStream.Position = fileStream.Position - bytesCount + filesStartPosition + 14;

                    while (true)
                    {
                        var size = binaryReader.ReadInt32();

                        if (size < 1)
                        {
                            break;
                        }

                        var value = binaryReader.ReadBytes(size);

                        // Filename.
                        var fileName = Encoding.UTF8.GetString(value);
                        fileStream.Position += 2; // Skip type.

                        // GZip file size.
                        size = binaryReader.ReadInt32();

                        using (var decompressedStream = GZipDecompress(binaryReader.ReadBytes(size)))
                        {
                            // Remove relative path.
                            fileName = fileName.Replace("../", string.Empty).Replace(@"..\", string.Empty);

                            var outputFilePath = System.IO.Path.Combine(outputDirectoryPath, fileName);
                            var directoryPath = System.IO.Path.GetDirectoryName(outputFilePath);

                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            // A size of zero means there is an empty file.
                            if (decompressedStream.Length > 0 || size == 0)
                            {
                                using (var outputFileStream = File.Open(directoryPath, FileMode.CreateNew))
                                {
                                    decompressedStream.Seek(0, SeekOrigin.Begin);
                                    decompressedStream.CopyTo(outputFileStream);
                                }
                            }
                            else
                            {
                                throw new Exception($"Cannot unpack file '{fileName}'.");
                            }

                            fileStream.Position += 14;
                        }
                    }
                }
            }
        }

        private static int Search(byte[] sIn, byte[] sFor)
        {
            int[] numArray = new int[256];
            int num1 = 0;
            int num2 = sFor.Length - 1;

            for (int index = 0; index < 256; ++index)
            {
                numArray[index] = sFor.Length;
            }

            for (int index = 0; index < num2; ++index)
            {
                numArray[(int)sFor[index]] = num2 - index;
            }

            while (num1 <= sIn.Length - sFor.Length)
            {
                for (int index = num2; (int)sIn[num1 + index] == (int)sFor[index]; --index)
                {
                    if (index == 0)
                    {
                        return num1;
                    }
                }

                num1 += numArray[(int)sIn[num1 + num2]];
            }

            return -1;
        }

        private static FileStream GetFileStream(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            filePath = System.IO.Path.GetFullPath(filePath);

            return File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "Dispose is idempotent")]
        private static Stream GZipDecompress(byte[] data)
        {
            var decompressedStream = new MemoryStream();

            using (var compressedStream = new MemoryStream(data))
            {
                using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    gzipStream.CopyTo(decompressedStream);
                }
            }

            return decompressedStream;
        }
    }
}
