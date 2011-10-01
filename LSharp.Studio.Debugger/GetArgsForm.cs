/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 10/1/2011
 * Time: 3:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LSharp.Studio.Debugger
{
    /// <summary>
    /// Description of GetArgsForm.
    /// </summary>
    public partial class GetArgsForm : Form
    {
        public string RESULT;
        public GetArgsForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        void Button2_Click(object sender, EventArgs e)
        {
            RESULT = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
        void Button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
                textBox1.Text = OFD.FileName;
        }
    }
}
