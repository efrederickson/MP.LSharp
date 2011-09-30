/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/24/2011
 * Time: 1:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LSharp.Studio.Debugger
{
	/// <summary>
	/// Description of Plugin.
	/// </summary>
	public class Plugin : LSharp.Studio.Plugins.IPlugin
	{
		System.Windows.Forms.ToolStripMenuItem _menu;
		DebugMenu debugMenu;
		public Plugin()
		{
		}
		
		public string Version {
			get {
				return "1.0";
			}
		}
		
		public string Name {
			get {
				return "L# Studio Debugger";
			}
		}
		
		public string Description {
			get {
				return "A Debugger for L# Studio";
			}
		}
		
		public string Author {
			get {
				return "Elijah Frederickson";
			}
		}
		
		public string DownloadURL {
			get {
				return "";
			}
		}
		
		public string OriginalFileName {
			get {
				return DownloadURL;
			}
		}
		
		public System.Windows.Forms.ToolStripMenuItem ToolStripItem {
			get {
				return _menu;
			}
		}
		
		public string MenuItemPath {
			get {
				return "tools/";
			}
		}
		
		public void Initialize()
		{
			_menu = new System.Windows.Forms.ToolStripMenuItem("Initialize Debugger", null, delegate { 
			                                                   	DebugManagerForm frm = new DebugManagerForm();
			                                                   	frm.Controls.Add(debugMenu);
			                                                   	debugMenu.Parent = frm;
			                                                   	debugMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			                                                   	_menu.Visible = false;
			                                                   	frm.Show();
			                                                   });
			debugMenu = new DebugMenu();
		}
		
		public void Dispose()
		{
			_menu.Dispose();
			debugMenu.Dispose();
		}
	}
}
