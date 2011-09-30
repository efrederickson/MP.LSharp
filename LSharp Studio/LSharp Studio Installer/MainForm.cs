/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/19/2011
 * Time: 4:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Ionic.Zip;

namespace LSharp_Studio_Installer
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		}
		
		void BtnAnnulla_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void BtnNext_Click(object sender, EventArgs e)
		{
			ExtractorForm ext = new ExtractorForm(this);
			ext.ShowDialog();
			if (ext.DialogResult == DialogResult.Yes) {
				System.Diagnostics.Process.Start(textBox1.Text);
				this.Close();
			} else
				MessageBox.Show("Please try installing L# Studio again!\n(Do you have write access to this path?)");
		}
		
		
		internal static System.IO.Stream GetZipFile()
    	{
    	    Assembly a1 = Assembly.GetExecutingAssembly();
    	    System.IO.Stream s = a1.GetManifestResourceStream("LSharp_Studio_Installer.LSharpStudio.zip");
            return s;
    	}
		
		void Button1_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog b = new FolderBrowserDialog();
			if (b.ShowDialog() == DialogResult.OK)
				textBox1.Text = b.SelectedPath;
		}
		
		void Button2_Click(object sender, EventArgs e)
		{
			BtnNext_Click(sender, e);
		}
		
		void Button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
