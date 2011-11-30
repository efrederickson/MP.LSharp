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
                projectInfoLabel.Text = "";
        }
        
        void Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
                new LSharp.Studio.WTFPlugin.Projects.BasicProject().Create;
            if (listBox1.SelectedIndex == 1)
                new LSharp.Studio.WTFPlugin.Projects.InstructionalProject().Create;
            else
                return;
        }
        
        void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
