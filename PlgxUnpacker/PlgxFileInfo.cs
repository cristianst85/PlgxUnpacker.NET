using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PlgxUnpacker
{
    /// <summary>
    /// This class represents the PLGX file information metadata.
    /// </summary>
    public sealed class PlgxFileInfo
    {
        /// <summary>
        /// Gets the plugin name.
        /// </summary>
        public string PluginName { get; private set; }

        /// <summary>
        /// Gets the date and time when the plugin/PLGX file was created.
        /// </summary>
        public DateTime PluginCreationDateTime { get; private set; }

        /// <summary>
        /// Gets the tool name that was used to create the plugin/PLGX file.
        /// </summary>
        public string PluginCreationToolName { get; private set; }

        /// <summary>
        /// Gets a list of file names contained within the PLGX file.
        /// <para>Each name represents a relative path to the directory structure of the original plugin folder.</para>
        /// </summary>
        public IList<string> FileNames { get; private set; }

        /// <summary>
        /// <see cref="PlgxFileInfo"/> constructor.
        /// </summary>
        /// <param name="pluginName">The plugin name.</param>
        /// <param name="pluginCreationDateTime">The date and time when the plugin/PLGX file was created.</param>
        /// <param name="pluginCreationToolName">The tool name that was used to create the plugin/PLGX file.</param>
        /// <param name="fileNames">A list of file names contained within the PLGX file.</param>
        internal PlgxFileInfo(string pluginName, DateTime pluginCreationDateTime, string pluginCreationToolName, IList<string> fileNames)
        {
            this.PluginName = pluginName;
            this.PluginCreationDateTime = pluginCreationDateTime;
            this.PluginCreationToolName = pluginCreationToolName;
            this.FileNames = new ReadOnlyCollection<string>(fileNames);
        }
    }
}
