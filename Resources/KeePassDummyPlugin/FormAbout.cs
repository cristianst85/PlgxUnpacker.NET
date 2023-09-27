using KeePassDummyPlugin.Helpers;
using System.Diagnostics;
using System.Windows.Forms;

namespace KeePassDummyPlugin
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            labelVersion.Text = labelVersion.Text.Replace("{version}", AssemblyUtils.GetProductVersion());
            linkLabelContact.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabelContact_LinkClicked);
            linkLabelSource.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabelSource_LinkClicked);

            KeyDown += new KeyEventHandler(FormAbout_KeyPress);
        }

        private void FormAbout_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void LinkLabelContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(string.Format("mailto:{0}?subject=About {1} v{2}", linkLabelContact.Text, KeePassDummyPluginExt.Title, AssemblyUtils.GetVersion()));
        }

        private void LinkLabelSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/cristianst85/PlgxUnpacker");
        }
    }
}
