using NUnit.Framework;
using System.IO;
using System.Linq;

namespace PlgxUnpacker.Tests
{
    [TestFixture]
	public class PlgxFileUnpackToTests : PlgxFileTestsBaseClass
    {
		[SetUp]
		public void Setup()
		{
			var directoryPath = Path.GetFullPath(TestWorkspaceDirectoryPath);

			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}

			Assert.IsEmpty(Directory.GetFiles(directoryPath));
		}

		[TestCase]
		public void PlgxFile_UnpackTo()
		{
			var directoryPath = Path.GetFullPath(TestWorkspaceDirectoryPath);

			PlgxFile plgxFile = null;

			Assert.DoesNotThrow(() => plgxFile = PlgxFile.LoadFromFile(PlgxFilePath));
			Assert.IsNotNull(plgxFile);

			Assert.DoesNotThrow(() => plgxFile.UnpackTo(directoryPath));

			var unpackedFiles = plgxFile.GetUnpackedFiles();

			CollectionAssert.AreEqual(FileNamesList, unpackedFiles.Select(x => x.Name));

			foreach (var fileEntry in unpackedFiles)
			{
				var fileEntryPath = Path.Combine(directoryPath, fileEntry.Name);
				fileEntryPath = Path.GetFullPath(fileEntryPath);

				Assert.IsTrue(File.Exists(fileEntryPath));
				Assert.AreEqual(File.ReadAllBytes(fileEntryPath), fileEntry.Content);
			}
		}

		[TearDown]
		public void TearDown()
		{
			var directoryPath = Path.GetFullPath(TestWorkspaceDirectoryPath);

			if (Directory.Exists(directoryPath))
			{
				Directory.Delete(directoryPath, true);
			}

			Assert.IsFalse(Directory.Exists(directoryPath));
		}
	}
}
