using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace PlgxUnpackerNet.Tests
{
    public class PlgxFileTestsBaseClass
    {
        internal static readonly string PlgxFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\..\plgx\PlgxUnpackerNet.KeePassDummyPlugin.plgx");
        internal static readonly string PlgxFileWithCommandsPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\..\plgx\PlgxUnpackerNet.KeePassDummyPlugin.WithCommands.plgx");
        internal static readonly string PlgxProjectDirectoryPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\..\Resources\KeePassDummyPlugin");
        internal static readonly string TestResourcesDirectoryPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\Resources");
        internal static readonly string TestWorkspaceDirectoryPath = Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\..\PlgxUnpackerNet.Tests.Workspace");

        internal List<string> FileNamesList
        {
            get
            {
                return new List<string>()
                {
                    "FormAbout.cs",
                    "FormAbout.Designer.cs",
                    "FormAbout.resx",
                    "KeePassDummyPlugin.csproj",
                    "KeePassDummyPluginExt.cs",
                    "Helpers/AssemblyUtils.cs",
                    "Properties/AssemblyInfo.cs",
                    "Resources/EmptyTextFile.txt",
                    "Resources/Scripts/PostBuildScript.bat",
                    "Resources/Scripts/PreBuildScript.bat"
                };
            }
        }
    }
}
