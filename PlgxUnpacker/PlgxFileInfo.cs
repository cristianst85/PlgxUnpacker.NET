using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PlgxUnpacker
{
    public sealed class PlgxFileInfo
    {
        public string PluginName { get; private set; }

        public DateTime PluginCreationDateTime { get; private set; }

        public string PluginCreationToolName { get; private set; }

        public IList<string> FileNames { get; private set; }

        public PlgxFileInfo(string pluginName, DateTime pluginCreationDateTime, string pluginCreationToolName, IList<string> fileNames)
        {
            this.PluginName = pluginName;
            this.PluginCreationDateTime = pluginCreationDateTime;
            this.PluginCreationToolName = pluginCreationToolName;
            this.FileNames = new ReadOnlyCollection<string>(fileNames);
        }
    }
}
