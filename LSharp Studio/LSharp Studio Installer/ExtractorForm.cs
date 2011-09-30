/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/20/2011
 * Time: 9:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;

namespace LSharp_Studio_Installer
{
	/// <summary>
	/// Description of ExtractorForm.
	/// </summary>
	public partial class ExtractorForm : Form
	{
		MainForm _F;
		public ExtractorForm(MainForm frm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			_F = frm;
			this.Text = "Extracting L# Studio...";
		}
		
		public void setMsg(string msg)
		{
			label1.Text = msg;
		}
		
		void ExtractorForm_Load(object sender, EventArgs e)
		{
			bool failed = false;
			this.setMsg("Extracting Zip...");
			string randomfilename = Application.LocalUserAppDataPath + "\\" + new Random(DateTime.Now.Millisecond).Next() + ".zip";
			System.IO.FileStream fs = new System.IO.FileStream(randomfilename, System.IO.FileMode.Create);
			Stream s = MainForm.GetZipFile();
			s.CopyTo(fs);
			s.Close();
			fs.Close();
			Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(randomfilename);
			zip.ExtractProgress += delegate(object sender2, Ionic.Zip.ExtractProgressEventArgs e2) { setMsg("Extracting " + e2.CurrentEntry + "... Bytes: " + e2.BytesTransferred + "/" + e2.TotalBytesToTransfer); };
			try {
				zip.ExtractAll(_F.textBox1.Text, ExtractExistingFileAction.OverwriteSilently);
			} catch (Exception e2) {
				MessageBox.Show(e2.ToString());
 				failed = true;
			}
			if (!failed)
				this.DialogResult = DialogResult.Yes;
			else
				this.DialogResult = DialogResult.No;
			this.Close();
		}
	}
}
