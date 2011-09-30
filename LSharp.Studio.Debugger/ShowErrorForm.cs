/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/26/2011
 * Time: 11:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LSharp.Studio.Debugger
{
	/// <summary>
	/// Description of ShowErrorForm.
	/// </summary>
	public partial class ShowErrorForm : Form
	{
		public ShowErrorForm(Exception ex)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			textBox1.Text = ex.ToString();
			label1.Text = "An Error '" + ex.Message.Replace("\n", "") + "' occured!";
			this.Text = "Error - " + ex.Message;
		}
		
		void Button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
