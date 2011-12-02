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
            foreach (File file in GlobalCurrentProject.Project.Files)
            {
                TreeNode n = AddTreeNode(file.NodePath);
            }
        }
        
        private TreeNode AddTreeNode(string name)
        {
            if ((name.EndsWith("/"))) {
                name = name.Substring(0, name.Length - 1);
            }
            TreeNode node = FindNodeForTag(name, treeView1.Nodes);
            if ((node != null)) {
                return node;
            }
            TreeNodeCollection pnodeCollection = null;
            string parent = System.IO.Path.GetDirectoryName(name);
            if ((string.IsNullOrEmpty(parent))) {
                pnodeCollection = this.treeView1.Nodes;
            } else {
                pnodeCollection = AddTreeNode(parent.Replace("\\", "/")).Nodes;
            }
            node = new TreeNode();
            node.Text = System.IO.Path.GetFileName(name);
            node.Tag = name;
            // full path
            pnodeCollection.Add(node);
            return node;
        }

        private TreeNode FindNodeForTag(string name, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes) {
                if ((name == node.Tag)) {
                    return node;
                } else if ((name.StartsWith(node.Tag + "/"))) {
                    return FindNodeForTag(name, node.Nodes);
                }
            }
            return null;
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
                GlobalCurrentProject.OpenDocumentFromIndex(treeView1.SelectedNode.Index);
            }
        }
    }
}
