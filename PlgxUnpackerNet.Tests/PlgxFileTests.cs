using NUnit.Framework;
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
            Assert.That(plgxFileInfo.PluginName, Is.EqualTo("KeePassDummyPlugin"));
            Assert.That(plgxFileInfo.PluginCreationToolName, Is.EqualTo("KeePass"));
            Assert.That(plgxFileInfo.PluginCreationDateTime, Is.EqualTo(new FileInfo(PlgxFilePath).CreationTime).Within(1).Seconds);
            Assert.That(plgxFileInfo.PreBuildCommand, Is.Null);
            Assert.That(plgxFileInfo.PostBuildCommand, Is.Null);

            CollectionAssert.AreEqual(FileNamesList, plgxFileInfo.FileNames);
        }

        [TestCase]
        public void PlgxFile_WithCommands_PlgxFileInfo()
        {
            var plgxFileInfo = PlgxFile.GetPlgxFileInfo(PlgxFileWithCommandsPath);
            VerifyPlgxFileInfo_WithCommands(plgxFileInfo);
        }

        [TestCase]
        public void PlgxFile_WithCommands_LoadFromFile()
        {
            PlgxFile plgxFile = null;

            Assert.DoesNotThrow(() => plgxFile = PlgxFile.LoadFromFile(PlgxFileWithCommandsPath));
            Assert.IsNotNull(plgxFile);
            Assert.AreEqual(Path.GetFullPath(PlgxFileWithCommandsPath), plgxFile.Path);

            VerifyPlgxFileInfo_WithCommands(plgxFile.Info);

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

        private void VerifyPlgxFileInfo_WithCommands(PlgxFileInfo plgxFileInfo)
        {
            Assert.That(plgxFileInfo.PluginName, Is.EqualTo("KeePassDummyPlugin"));
            Assert.That(plgxFileInfo.PluginCreationToolName, Is.EqualTo("KeePass"));
            Assert.That(plgxFileInfo.PluginCreationDateTime, Is.EqualTo(new FileInfo(PlgxFileWithCommandsPath).CreationTime).Within(1).Seconds);
            Assert.That(plgxFileInfo.PreBuildCommand, Is.EqualTo(@"""{PLGX_TEMP_DIR}Resources\Scripts\PreBuildScript.bat"""));
            Assert.That(plgxFileInfo.PostBuildCommand, Is.EqualTo(@"""{PLGX_TEMP_DIR}Resources\Scripts\PostBuildScript.bat"""));

            CollectionAssert.AreEqual(FileNamesList, plgxFileInfo.FileNames);
        }
    }
}
