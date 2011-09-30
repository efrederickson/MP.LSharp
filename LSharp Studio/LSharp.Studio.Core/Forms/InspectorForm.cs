using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LSharp.Studio.Core.Forms
{
    public partial class InspectorForm : Form
    {
        private object Element;
        public InspectorForm(object ElementToInspect)
        {
            InitializeComponent();
            textBox1.Text = Inspector.Inspect(ElementToInspect);
            this.Element = ElementToInspect;
            label1.Text = "Element Type: " + ElementToInspect.GetType().Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
