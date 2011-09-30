/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/8/2011
 * Time: 3:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace LSharp.Studio
{
	/// <summary>
	/// Entry Point. Loads the Program
	/// </summary>
	internal sealed class Program
	{
		private static SplashScreen _splashScreen;
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			// Allow user to watch the Loading Of Assemblies O_o
			AppDomain.CurrentDomain.AssemblyLoad += OnAssemblyLoad;
			// Set basic Application settings
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Initialize program
            _splashScreen = new SplashScreen();
            _splashScreen.Show();
            Application.DoEvents();
            AppDomain.CurrentDomain.AssemblyLoad -= OnAssemblyLoad;
            
            
            _splashScreen.LoadingMsg = "Loading Settings...";
            LSharp.Studio.Core.OptionsLoader.Load();
            
            _splashScreen.LoadingMsg = "Loading Code Editor...";
            MainForm mainDlg = new MainForm();
            
            _splashScreen.LoadingMsg = "Loading Plugins...";
            LSharp.Studio.Plugins.PluginService pm = new LSharp.Studio.Plugins.PluginService(mainDlg);
            pm.FindPlugins();
            
            _splashScreen.LoadingMsg = "Loading Command Line Arguments...";
            foreach (string filename in System.Environment.GetCommandLineArgs())
            {
                try {
                    if (!string.IsNullOrEmpty(filename))
                    {
                        if (!(filename == Application.ExecutablePath))
                            mainDlg.LoadFile(filename);
                    }
                } catch (Exception e) {
                    MessageBox.Show(e.ToString());
                }
            }
            
            _splashScreen.LoadingMsg = "Loading...";
            _splashScreen.Close();
            // Run Application
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Console.WriteLine("Started!");
            Application.Run(mainDlg);
        }

        private static void OnAssemblyLoad(object sender, AssemblyLoadEventArgs e)
        {
        	// Update Splash Screen
            _splashScreen.LoadingMsg = string.Format("Loading {0}...", e.LoadedAssembly.ManifestModule.Name);
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            LSharp.Studio.Core.Properties.Settings.Default.Save();
        }
	}
}
