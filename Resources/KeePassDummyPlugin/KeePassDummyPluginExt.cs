using KeePass.Plugins;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace KeePassDummyPlugin
{
    public sealed class KeePassDummyPluginExt : Plugin
    {
        public const string Title = "PlgxUnpacker.KeePassDummyPlugin";

        private const string PluginName = "KeePassDummyPluginExt";
        private const string PluginUpdateUrl = "https://raw.githubusercontent.com/cristianst85/PlgxUnpacker/master/Resources/KeePassDummyPlugin.version";

        private IPluginHost pluginHost;

        public override bool Initialize(IPluginHost pluginHost)
        {
            Debug.Assert(pluginHost != null);

            if (pluginHost == null)
            {
                return false;
            }

            this.pluginHost = pluginHost;

            return true;
        }

        public override string UpdateUrl
        {
            get
            {
                return PluginUpdateUrl;
            }
        }

        public override ToolStripMenuItem GetMenuItem(PluginMenuType t)
        {
            if (t == PluginMenuType.Main)
            {
                var menuItem = new ToolStripMenuItem
                {
                    Name = PluginName,
                    Text = Title + "..."
                };

                menuItem.Click += OnMainMenuItemClick;

                return menuItem;
            }

            return null;
        }

        private void OnMainMenuItemClick(object sender, EventArgs e)
        {
            using (var form = new FormAbout())
            {
                form.Text = form.Text.Replace("{title}", Title);
                form.ShowDialog(pluginHost.MainWindow);
            }
        }
    }
}
