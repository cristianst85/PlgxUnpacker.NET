namespace KeePassDummyPlugin
{
    partial class FormAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLicense = new System.Windows.Forms.Label();
            this.linkLabelSource = new System.Windows.Forms.LinkLabel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelPluginName = new System.Windows.Forms.Label();
            this.labelContact = new System.Windows.Forms.Label();
            this.linkLabelContact = new System.Windows.Forms.LinkLabel();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLicense
            // 
            this.labelLicense.Location = new System.Drawing.Point(21, 73);
            this.labelLicense.Name = "labelLicense";
            this.labelLicense.Size = new System.Drawing.Size(256, 15);
            this.labelLicense.TabIndex = 4;
            this.labelLicense.Text = "Released under the MIT License.";
            this.labelLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelSource
            // 
            this.linkLabelSource.AutoSize = true;
            this.linkLabelSource.Location = new System.Drawing.Point(21, 88);
            this.linkLabelSource.Name = "linkLabelSource";
            this.linkLabelSource.Size = new System.Drawing.Size(113, 13);
            this.linkLabelSource.TabIndex = 5;
            this.linkLabelSource.TabStop = true;
            this.linkLabelSource.Text = "GitHub project source.";
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(21, 35);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(259, 15);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Version {version}";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPluginName
            // 
            this.labelPluginName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPluginName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPluginName.Location = new System.Drawing.Point(21, 20);
            this.labelPluginName.Name = "labelPluginName";
            this.labelPluginName.Size = new System.Drawing.Size(259, 15);
            this.labelPluginName.TabIndex = 1;
            this.labelPluginName.Text = "PlgxUnpackerNet.KeePassDummyPlugin";
            this.labelPluginName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelContact
            // 
            this.labelContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContact.Location = new System.Drawing.Point(21, 108);
            this.labelContact.Name = "labelContact";
            this.labelContact.Size = new System.Drawing.Size(255, 15);
            this.labelContact.TabIndex = 6;
            this.labelContact.Text = "Contact:";
            this.labelContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelContact
            // 
            this.linkLabelContact.AutoSize = true;
            this.linkLabelContact.Location = new System.Drawing.Point(21, 123);
            this.linkLabelContact.Name = "linkLabelContact";
            this.linkLabelContact.Size = new System.Drawing.Size(138, 13);
            this.linkLabelContact.TabIndex = 7;
            this.linkLabelContact.TabStop = true;
            this.linkLabelContact.Text = "cristianstoica85@gmail.com";
            // 
            // labelCopyright
            // 
            this.labelCopyright.Location = new System.Drawing.Point(21, 58);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(256, 15);
            this.labelCopyright.TabIndex = 3;
            this.labelCopyright.Text = "Copyright (c) 2023 Cristian Stoica.\r\n";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(117, 150);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // FormAbout
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(294, 185);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelLicense);
            this.Controls.Add(this.linkLabelSource);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelPluginName);
            this.Controls.Add(this.labelContact);
            this.Controls.Add(this.linkLabelContact);
            this.Controls.Add(this.labelCopyright);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About {title}";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLicense;
        private System.Windows.Forms.LinkLabel linkLabelSource;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelPluginName;
        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.LinkLabel linkLabelContact;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Button buttonClose;
    }
}