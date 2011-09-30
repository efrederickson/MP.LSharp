/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/22/2011
 * Time: 3:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LSharp.Studio.Core.Forms
{
	/// <summary>
	/// Description of HelpForm.
	/// </summary>
	public partial class HelpForm : Form
	{
		public HelpForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CloseButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
