/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 12/1/2011
 * Time: 1:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace LSharp.Studio.WTFPlugin
{
    /// <summary>
    /// Description of OpenProjectPlugin.
    /// </summary>
    public class OpenProjectPlugin : LSharp.Studio.Plugins.IPlugin
    {
        ToolStripMenuItem _item;
        
        public OpenProjectPlugin()
        {
        }
        
        public string Version {
            get {
                return "1.0";
            }
        }
        
        public string Name {
            get {
                return "Open L# Projects";
            }
        }
        
        public string Description {
            get {
                return "Open L# Projects in L# Studio";
            }
        }
        
        public string Author {
            get {
                return "Elijah";
            }
        }
        
        public string DownloadURL {
            get {
                return "";
            }
        }
        
        public string OriginalFileName {
            get {
                return "";
            }
        }
        
        public System.Windows.Forms.ToolStripMenuItem ToolStripItem {
            get {
                return _item;
            }
        }
        
        public string MenuItemPath {
            get {
                return "new/Windows Text Foundation";
            }
        }
        
        public void Initialize()
        {
            _item = new ToolStripMenuItem("Open a WTF project...");
            _item.Click += delegate(object sender, EventArgs e) { 
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "L# Projects (*.lsproj)|*.lsproj|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    WTFProject proj = new WTFProject();
                    proj.Load(ofd.FileName);
                    GlobalCurrentProject.Project = proj;
                    GlobalCurrentProject.UpdateWindows();
                }
            };
        }
        
        public void Dispose()
        {
            _item.Dispose();
            _item = null;
        }
    }
}
