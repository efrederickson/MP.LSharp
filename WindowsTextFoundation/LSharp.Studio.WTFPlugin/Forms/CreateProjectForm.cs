using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LSharp.Studio.WTFPlugin.Forms
{
    public partial class CreateProjectForm : Form
    {
        public CreateProjectForm()
        {
            InitializeComponent();
            projectOutDirTextBox.Text = LSharp.Studio.Core.Properties.Settings.Default.DefaultSaveLocation + "\\";
        }
        
        void CreateProjectForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Basic Project");
            listBox1.Items.Add("Tutorial");
        }
        
        void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
                projectInfoLabel.Text = new LSharp.Studio.WTFPlugin.Projects.BasicProject().Info;
            if (listBox1.SelectedIndex == 1)
                projectInfoLabel.Text = new LSharp.Studio.WTFPlugin.Projects.InstructionalProject().Info;
            else
                projectInfoLabel.Text = new LSharp.Studio.WTFPlugin.Projects.BasicProject().Info;
        }
        
        void Button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                projectOutDirTextBox.Text += "\\" + projectNameTextBox.Text;
            if (!System.IO.Directory.Exists(projectOutDirTextBox.Text))
                System.IO.Directory.CreateDirectory(projectOutDirTextBox.Text);
            if (listBox1.SelectedIndex == 0)
                GlobalCurrentProject.Project = new LSharp.Studio.WTFPlugin.Projects.BasicProject().Create(projectOutDirTextBox.Text, projectOutDirTextBox.Text + "\\" + (projectNameTextBox.Text.ToLower().EndsWith(".lsproj") ? projectNameTextBox.Text : projectNameTextBox.Text + ".lsproj"), projectNameTextBox.Text);
            if (listBox1.SelectedIndex == 1)
                GlobalCurrentProject.Project = new LSharp.Studio.WTFPlugin.Projects.InstructionalProject().Create(projectOutDirTextBox.Text, projectOutDirTextBox.Text + "\\" + (projectNameTextBox.Text.ToLower().EndsWith(".lsproj") ? projectNameTextBox.Text : projectNameTextBox.Text + ".lsproj"), projectNameTextBox.Text);
            else 
                GlobalCurrentProject.Project = new LSharp.Studio.WTFPlugin.Projects.BasicProject().Create(projectOutDirTextBox.Text, projectOutDirTextBox.Text + "\\" + (projectNameTextBox.Text.ToLower().EndsWith(".lsproj") ? projectNameTextBox.Text : projectNameTextBox.Text + ".lsproj"), projectNameTextBox.Text);
            GlobalCurrentProject.UpdateWindows();
            Close();
        }
        
        void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        void Button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
                projectOutDirTextBox.Text = f.SelectedPath;
        }
        
    }
}
