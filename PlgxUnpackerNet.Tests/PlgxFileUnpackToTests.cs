using NUnit.Framework;
using System.IO;
using System.Linq;

namespace PlgxUnpackerNet.Tests
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

			Assert.That(Directory.GetFiles(directoryPath), Is.Empty);
		}

		[TestCase]
		public void PlgxFile_UnpackTo()
		{
			var directoryPath = Path.GetFullPath(TestWorkspaceDirectoryPath);

			PlgxFile plgxFile = null;

			Assert.DoesNotThrow(() => plgxFile = PlgxFile.LoadFromFile(PlgxFilePath));
			Assert.That(plgxFile, Is.Not.Null);

			Assert.DoesNotThrow(() => plgxFile.UnpackTo(directoryPath));

			var unpackedFiles = plgxFile.GetUnpackedFiles();

			Assert.That(unpackedFiles.Select(x => x.Name), Is.EqualTo(FileNamesList));

			foreach (var fileEntry in unpackedFiles)
			{
				var fileEntryPath = Path.Combine(directoryPath, fileEntry.Name);
				fileEntryPath = Path.GetFullPath(fileEntryPath);

				Assert.That(File.Exists(fileEntryPath), Is.True);
				Assert.That(fileEntry.Content, Is.EqualTo(File.ReadAllBytes(fileEntryPath)));
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

			Assert.That(Directory.Exists(directoryPath), Is.False);
		}
	}
}
