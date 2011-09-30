/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/19/2011
 * Time: 4:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Reflection;
namespace LSharp_Studio_Installer
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveZipLib);
			AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs e) {  MessageBox.Show("Unhandled Error: " + e.ExceptionObject.ToString()); };
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		static System.Reflection.Assembly ResolveZipLib(object sender, ResolveEventArgs args)
    	{
			System.Diagnostics.Debug.WriteLine("Loading Ionic->Zip");
    	    Assembly a1 = Assembly.GetExecutingAssembly();
    	    System.IO.Stream s = a1.GetManifestResourceStream("LSharp_Studio_Installer.Ionic.Zip.dll");
    	    if (s == null)
    	    	throw new Exception("Cannot Load Ionic.Zip.dll");
    	    byte[] block = new byte[s.Length];
    	    s.Read(block, 0, block.Length);
    	    Assembly a2 = Assembly.Load(block);
    	    System.Diagnostics.Debug.WriteLine("Loaded Ionic->Zip");
    	    return a2;
    	}
	}
}
