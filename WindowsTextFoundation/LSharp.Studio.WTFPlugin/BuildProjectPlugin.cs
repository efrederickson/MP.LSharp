/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 12/1/2011
 * Time: 3:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Forms;
using LSharp.Studio.Plugins;

namespace LSharp.Studio.WTFPlugin
{
    /// <summary>
    /// Description of BuildProjectPlugin.
    /// </summary>
    public class BuildProjectPlugin : IPlugin
    {
        ToolStripMenuItem i;
        public BuildProjectPlugin()
        {
        }
        
        public string Version {
            get {
                return "1.0";
            }
        }
        
        public string Name {
            get {
                return "WTF Builder";
            }
        }
        
        public string Description {
            get {
                return "WTF Builder";
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
                return i;
            }
        }
        
        public string MenuItemPath {
            get {
                return "new/Windows Text Foundation";
            }
        }
        
        public void Initialize()
        {
            i = new ToolStripMenuItem("Build Project");
            i.Click += delegate(object sender, EventArgs e) { 
                CompilerResults r = WindowsTextFoundation.LSharpProvider.Compiler.Compile(GlobalCurrentProject.Project.GetLSharpSources(),System.IO.Path.GetDirectoryName(GlobalCurrentProject.Project.XmlFilename) + "\\" + GlobalCurrentProject.Project.OutputFileName, WindowsTextFoundation.LSharpProvider.Compiler.OutputType.Exe, GlobalCurrentProject.Project.GetWTFFileNames());
                foreach (CompilerError err in r.Errors)
                    Console.WriteLine(err.ToString());
                if (r.Errors.Count == 0)
                {
                    Console.WriteLine("Compiled Successfully!");
                    Process.Start(System.IO.Path.GetDirectoryName(GlobalCurrentProject.Project.XmlFilename) + "\\" + GlobalCurrentProject.Project.OutputFileName);
                }
            };
        }
        
        public void Dispose()
        {
            GlobalCurrentProject.Project.Save(GlobalCurrentProject.Project.XmlFilename);
            i.Dispose();
            i =  null;
        }
    }
}
