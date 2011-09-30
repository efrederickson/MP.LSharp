/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/22/2011
 * Time: 4:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace LSharp.Studio.Core.Forms
{
	/// <summary>
	/// Description of ViewEnvContentsForm.
	/// </summary>
	public partial class ViewEnvContentsForm : Form
	{
		Hashtable env = new Hashtable();
		public ViewEnvContentsForm(LSharp.Environment e, string lsharpcode)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			lsharpcode = "(do " + lsharpcode + ")";
			Runtime.EvalString(lsharpcode, e);
			try {
				string contents = e.Contents();
				string[] splitted = contents.Split(new string[] { "\n", ":"}, StringSplitOptions.None);
				for (int i = 0; i < splitted.Length; i+=0)
				{
				    env[splitted[i]] = LSharp.Printer.WriteToString(splitted[i + 1]);
					listBox1.Items.Add(splitted[i]);
					i += 2;
				}
			} catch (Exception e2) {
				textBox1.Text = e2.ToString();
			}
		}
		
		void Button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try {
			string item= (string) listBox1.SelectedItem;
			textBox1.Text = (string) env[item];
			} catch (Exception) {
			
			}
		}
	}
}
