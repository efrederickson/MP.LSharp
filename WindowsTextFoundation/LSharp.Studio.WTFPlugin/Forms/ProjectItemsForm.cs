/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 11/30/2011
 * Time: 9:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LSharp.Studio.WTFPlugin.Forms
{
    /// <summary>
    /// form that holds project items
    /// </summary>
    public partial class ProjectItemsForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public ProjectItemsForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        public void UpdateForm()
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(GlobalCurrentProject.Project.ProjectName);
            foreach (File file in GlobalCurrentProject.Project.Files)
            {
                TreeNode n = new TreeNode(System.IO.Path.GetFileName(file.Path));
                n.Tag = file.Path;
                treeView1.Nodes[0].Nodes.Add(n);
            }
        }
        
        void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try {
                if (treeView1.SelectedNode != null)
            {
                if (((string) treeView1.SelectedNode.Tag).EndsWith(GlobalCurrentProject.Project.ProjectName))
                {
                    GlobalCurrentProject.SelectPropertyItem(-1);
                }
                else
                    GlobalCurrentProject.SelectPropertyItem(treeView1.SelectedNode.Index);
            }
            } catch (Exception) {
                
            }
            
        }
        
        void TreeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                GlobalCurrentProject.OpenDocumentFromName(treeView1.SelectedNode.Tag as string);
            }
        }
    }
}
