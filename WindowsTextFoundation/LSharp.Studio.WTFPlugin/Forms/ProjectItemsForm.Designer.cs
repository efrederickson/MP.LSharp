/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 11/30/2011
 * Time: 9:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LSharp.Studio.WTFPlugin.Forms
{
    partial class ProjectItemsForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("{File}");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("{Project Name}", new System.Windows.Forms.TreeNode[] {
                                    treeNode1});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "tempChildNode";
            treeNode1.Text = "{File}";
            treeNode2.Name = "tempNode";
            treeNode2.Text = "{Project Name}";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                                    treeNode2});
            this.treeView1.Size = new System.Drawing.Size(284, 262);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.TreeView1_DoubleClick);
            // 
            // ProjectItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.treeView1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
                                    | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
                                    | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
                                    | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Name = "ProjectItemsForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Float;
            this.TabText = "Project Items";
            this.Text = "Project Items";
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.TreeView treeView1;
    }
}
