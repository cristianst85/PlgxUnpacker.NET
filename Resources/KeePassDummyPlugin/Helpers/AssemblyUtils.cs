using System;
using System.Diagnostics;
using System.Reflection;

namespace KeePassDummyPlugin.Helpers
{
    internal class AssemblyUtils
    {
        internal static string GetProductVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.ProductVersion;
        }

        public static Version GetVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetName().Version;
        }
    }
}
