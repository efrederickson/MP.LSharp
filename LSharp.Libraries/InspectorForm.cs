using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LSharp
{
    /// <summary>
    /// The form for Gui-Inspect
    /// </summary>
    public partial class InspectorForm : Form
    {
        private object Element;
        /// <summary>
        /// Initializes the form with ElementToInspect as the object being inspected
        /// </summary>
        /// <param name="ElementToInspect"></param>
        /// <param name="env"></param>
        public InspectorForm(object ElementToInspect,LSharp.Environment env)
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
