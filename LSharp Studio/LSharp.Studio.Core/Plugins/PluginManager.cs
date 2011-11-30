using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using LSharp.Studio;

namespace LSharp.Studio.Plugins
{
public class PluginService
{
	public static readonly string PluginInterface = "LSharp.Studio.Plugins.IPlugin";
	
	//Inherits IPluginHost
	public MainForm Parent;
	//Keeps previously "PluginInfo"d plugins for faster access
		//String()
	private Hashtable Hashes = new Hashtable();

	public PluginService(MainForm parent)
	{
		this.Parent = parent;
		AvailablePlugins = new AvailablePlugins();
	}

	/// <summary>
	/// A Collection of all Plugins Found and Loaded
	/// </summary>
	public AvailablePlugins AvailablePlugins { get; set; }

	/// <summary>
	/// Searches the Application's Startup Directory for Plugins
	/// </summary>
	public void FindPlugins()
	{
		FindPlugins(AppDomain.CurrentDomain.BaseDirectory);
	}

	/// <summary>
	/// Searches the Path for Plugins in .DLL format
	/// </summary>
	/// <param name="Path">Directory to search for Plugins in</param>
	public void FindPlugins(string Path)
	{
		//First empty the collection, we're reloading them all
		// AvailablePlugins.Clear()

		//Go through all the files in the plugin directory
		foreach (string fileOn in Directory.GetFiles(Path)) {
			FileInfo File = new FileInfo(fileOn);

			//Preliminary check, must be .dll
			if ((File.Extension.ToLower().Equals(".dll"))) {
				//Add the 'plugin'
				AddPlugin(fileOn);
			}
		}
	}

	/// <summary>
	/// Unloads and Closes pluginNameOrPath
	/// </summary>
	public void ClosePlugin(string pluginNameOrPath)
	{
		AvailablePlugin tmp = null;
		foreach (AvailablePlugin pluginOn in AvailablePlugins) {
			if (pluginOn.Instance.Name.ToLower().Equals(pluginNameOrPath.ToLower()) | pluginOn.AssemblyPath.ToLower().Equals(pluginNameOrPath.ToLower())) {
				pluginOn.Instance.Dispose();
				pluginOn.Instance = null;
				tmp = pluginOn;
				break; // FIXED. IS CORRECT.: might not be correct. Was : Exit For
			}
		}
		if (tmp != null) {
			@remove(tmp);
		}
	}

	private void @remove(AvailablePlugin pl)
	{
		AvailablePlugins.Remove(pl);
		pl = null;
	}

	/// <summary>
	/// Close all the plugins
	/// </summary>
	public void ClosePlugins()
	{
		foreach (AvailablePlugin pluginOn in AvailablePlugins) {
			try {
				//Close all plugin instances
				//We call the plugins Dispose sub first incase it has to do 
				//Its own cleanup stuff
				pluginOn.Instance.Dispose();

				//After we give the plugin a chance to tidy up, get rid of it
				pluginOn.Instance = null;
			} catch (Exception ex) {
			}
		}

		//Finally, clear our collection of available plugins
		AvailablePlugins.Clear();
	}

	/// <summary>
	/// Reads a toolbar file and returns the properties as array (Name,Author,Version,Description,DownloadURL)
	/// </summary>
	/// <returns>String array (Name,Author,Version,Description, DownloadURL)</returns>
	/// <param name="FileName">Filename of the plugin</param>
	public string[] GetPluginInfo(string FileName, string InterfaceToFind)
	{
		if (Hashes.Contains(FileName)) {
			return (string[]) Hashes[FileName];
		}
		string[] ret = null;
		try {
			Assembly pluginAssembly = Assembly.LoadFrom(FileName);
			foreach (Type pluginType in pluginAssembly.GetTypes()) {
				if (pluginType.IsPublic) {
					if (!pluginType.IsAbstract) {
						Type typeInterface = pluginType.GetInterface(InterfaceToFind, true);
						if ((typeInterface != null)) {
							AvailablePlugin newPlugin = new AvailablePlugin();
							newPlugin.AssemblyPath = FileName;
							newPlugin.Instance = (IPlugin)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()));
							ret = new string[6];
							ret[0] = newPlugin.Instance.Name;
							ret[1] = newPlugin.Instance.Author;
							ret[2] = newPlugin.Instance.Version;
							ret[3] = newPlugin.Instance.Description;
							ret[4] = newPlugin.Instance.DownloadURL;
							ret[5] = newPlugin.Instance.OriginalFileName;
							Hashes[FileName] = ret;
							newPlugin.Instance = null;
							newPlugin = null;
						}
						typeInterface = null;
					}
				}
			}
			pluginAssembly = null;
		} catch (Exception ex) {
			ret = null;
		}
		return ret;
	}

	public void AddPlugin(string FileName)
	{
		try
		{
		//Create a new assembly from the plugin file we're adding..
		Debug.WriteLine("PluginManager: Loading " + FileName);
		Assembly pluginAssembly = Assembly.LoadFrom(FileName);
		//Next we'll loop through all the Types found in the assembly
		if (pluginAssembly != null) {
			int itemcount = 0;
			int pluginsfound = 0;
			foreach (Type pluginType in pluginAssembly.GetTypes()) {
				//Only look at public types
				if (pluginType.IsPublic) {
					//Only look at non-abstract types
					if (!pluginType.IsAbstract) {
						//Log.WriteLine(String.Format("PluginManager: Checking Type '{0}' from {1}", pluginType.Name, FileName))
						itemcount += 1;
						//Gets a type object of the interface we need the plugins to match
						Type typeInterface = pluginType.GetInterface(PluginInterface, true);

						//Make sure the interface we want to use actually exists
						if ((typeInterface != null)) {
							//Create a new available plugin since the type implements the IPlugin interface
							AvailablePlugin newPlugin = new AvailablePlugin();

							//Set the filename where we found it
							newPlugin.AssemblyPath = FileName;

							//Create a new instance and store the instance in the collection for later use
							//We could change this later on to not load an instance.. we have 2 options
							//1- Make one instance, and use it whenever we need it.. it's always there
							//2- Don't make an instance, and instead make an instance whenever we use it, then close it
							//For now we'll just make an instance of all the plugins
							try {
								newPlugin.Instance = (IPlugin)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()));
								Debug.WriteLine(string.Format("PluginManager: Type Match: '{0}' (from {2}) Implements '{1}'. Creating Plugin...", pluginType.Name, PluginInterface, FileName));
								pluginsfound += 1;
								//Add the new plugin to our collection here
								this.AvailablePlugins.Add(newPlugin);
								//Call initialization for the plugin
								newPlugin.Instance.Initialize();
								
								GetMenuItemFromString(newPlugin.Instance.MenuItemPath, newPlugin.Instance.ToolStripItem);
								//cleanup a bit
								newPlugin = null;
							} catch (Exception ex) {
								newPlugin = null;
								Debug.WriteLine("Error: " + ex.ToString());
								MessageBox.Show(string.Format("Error Loading Plugin \"{0}\": {1}", FileName, ex));
								try {
									System.IO.File.Delete(FileName);
								} catch (Exception ex2) {
								}
							}
						} else {
						}
						typeInterface = null;
						// Clean up
					}
				}
			}
			Debug.WriteLine(string.Format("Scanned {0} Items from {1}, {2} Plugins found.", itemcount, FileName, pluginsfound));
		}
		if (pluginAssembly == null) {
			throw new Exception("Empty Assembly!");
		}
		pluginAssembly = null;
		//more cleanup
		}catch (Exception e) {
			Debug.WriteLine(e.ToString());
		}
	}

	public void GetMenuItemFromString(string path, ToolStripMenuItem item)
	{
		if (path.ToLower().StartsWith("new/")) {
			ToolStripMenuItem toolstrip = null;
			string path2 = path.Substring("new/".Length);
			foreach (ToolStripMenuItem item2 in Parent.MenuStrip.Items) {
				if (item2.Text == path2) {
					toolstrip = item2;
				}
			}
			ToolStripMenuItem tmpitem = new ToolStripMenuItem("[plugin helper]") { Name = "pluginhelper" };
			if (toolstrip == null) {
				toolstrip = new ToolStripMenuItem(path2, null, new ToolStripMenuItem[] { tmpitem });
			} else {
				toolstrip.DropDownItems["pluginhelper"].GetCurrentParent().Items.Add(item);
				return;
			}
			tmpitem.Visible = false;
			//Parent.MenuStrip.Items.Insert(Parent.MenuStrip.Items.IndexOfKey("INSERT"), toolstrip);
                        Parent.MenuStrip.Items.Add(toolstrip);
			//toolstrip.Owner = Parent.MenuStrip
			tmpitem.GetCurrentParent().Items.Add(item);
			return;
		} else if (path.ToLower().StartsWith("file")) {
			Parent.newToolStripMenuItem1.GetCurrentParent().Items.Add(item);
			return;
		} else if (path.ToLower().StartsWith("tools")) {
			Parent.optionsToolStripMenuItem1.GetCurrentParent().Items.Add(item);
			return;
		} else if (path.ToLower().StartsWith("help")) {
			Parent.helpToolStripMenuItem2.GetCurrentParent().Items.Add(item);
			return;
	    } else if (path.ToLower().StartsWith("build")) {
	        Parent.buildToolStripMenuItem.GetCurrentParent().Items.Add(item);
	        return;
	    }
		Parent.pluginsToolStripMenuItem.GetCurrentParent().Items.Add(item);
		return;
	}
}
}