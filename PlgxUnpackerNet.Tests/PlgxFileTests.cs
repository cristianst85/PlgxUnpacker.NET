using NUnit.Framework;
using PlgxUnpackerNet.Tests.Extensions;
using System.IO;
using System.Linq;

namespace PlgxUnpackerNet.Tests
{
    [TestFixture]
    public class PlgxFileTests : PlgxFileTestsBaseClass
    {
        [TestCase]
        public void PlgxFile_IsPlgxFile_Returns_True()
        {
            Assert.IsTrue(PlgxFile.IsPlgxFile(PlgxFilePath));
        }

        [TestCase("EmptyTextFile.txt")]
        [TestCase("RandomBinaryFile.bin")]
        [TestCase("RandomBinaryFile1K.bin")]
        public void PlgxFile_IsPlgxFile_Returns_False(string fileName)
        {
            var filePath = Path.Combine(TestResourcesDirectoryPath, fileName);
            filePath = Path.GetFullPath(filePath);

            Assert.IsFalse(PlgxFile.IsPlgxFile(filePath));
        }

        [TestCase]
        public void PlgxFile_PlgxFileInfo()
        {
            var plgxFileInfo = PlgxFile.GetPlgxFileInfo(PlgxFilePath);
            VerifyPlgxFileInfo(plgxFileInfo);
        }

        [TestCase]
        public void PlgxFile_LoadFromFile()
        {
            PlgxFile plgxFile = null;

            Assert.DoesNotThrow(() => plgxFile = PlgxFile.LoadFromFile(PlgxFilePath));
            Assert.IsNotNull(plgxFile);
            Assert.AreEqual(Path.GetFullPath(PlgxFilePath), plgxFile.Path);

            VerifyPlgxFileInfo(plgxFile.Info);

            var unpackedFiles = plgxFile.GetUnpackedFiles();

            CollectionAssert.AreEqual(FileNamesList, unpackedFiles.Select(x => x.Name));

            foreach (var fileEntry in unpackedFiles)
            {
                var fileEntryPath = Path.Combine(PlgxProjectDirectoryPath, fileEntry.Name);
                fileEntryPath = Path.GetFullPath(fileEntryPath);

                Assert.IsTrue(File.Exists(fileEntryPath));
                Assert.AreEqual(File.ReadAllBytes(fileEntryPath), fileEntry.Content);
            }
        }

        private void VerifyPlgxFileInfo(PlgxFileInfo plgxFileInfo)
        {
            Assert.AreEqual("KeePassDummyPlugin", plgxFileInfo.PluginName);
            Assert.AreEqual("KeePass", plgxFileInfo.PluginCreationToolName);
            Assert.AreEqual(new FileInfo(PlgxFilePath).CreationTime.TruncateMilliseconds(), plgxFileInfo.PluginCreationDateTime);

            CollectionAssert.AreEqual(FileNamesList, plgxFileInfo.FileNames);
        }
    }
}
