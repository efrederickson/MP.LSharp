/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/20/2011
 * Time: 10:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LSharp.Studio.Core.Forms
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		}
		
		void Button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
