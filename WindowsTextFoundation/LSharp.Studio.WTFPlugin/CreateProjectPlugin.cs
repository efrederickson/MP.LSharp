using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSharp.Studio.WTFPlugin
{
    public class CreateProjectPlugin : LSharp.Studio.Plugins.IPlugin
    {
        System.Windows.Forms.ToolStripMenuItem menu;

        public string Version
        {
            get { return "1.0"; }
        }

        public string Name
        {
            get { return "Create Project Menu for WTF Binding"; }
        }

        public string Description
        {
            get { return "WTF Binding Piece"; }
        }

        public string Author
        {
            get { return "Elijah Frederickson"; }
        }

        public string DownloadURL
        {
            get { return ""; }
        }

        public string OriginalFileName
        {
            get { return ""; }
        }

        public System.Windows.Forms.ToolStripMenuItem ToolStripItem
        {
            get { return menu; }
        }

        public string MenuItemPath
        {
            get { return "new/Windows Text Foundation"; }
        }

        public void Initialize()
        {
            menu = new System.Windows.Forms.ToolStripMenuItem("Create a WTF Project...");
            menu.Click += new EventHandler(menu_Click);
        }

        void menu_Click(object sender, EventArgs e)
        {
            new Forms.CreateProjectForm().ShowDialog();
        }

        public void Dispose()
        {
            menu.Dispose();
            menu = null;
        }
    }
}
