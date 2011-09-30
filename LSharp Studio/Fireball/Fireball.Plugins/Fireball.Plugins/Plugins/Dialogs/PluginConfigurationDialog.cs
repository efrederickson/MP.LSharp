//    Copyright (C) 2005  Sebastian Faltoni
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Fireball.Plugins.Dialogs
{
    public partial class PluginConfigurationDialog : Form
    {
        public PluginConfigurationDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (PluginLoadInfo current in 
                PluginApplication.Istance.Manager.Plugins)
            {
                AddItem(current);
            }
        }

        void AddItem(PluginLoadInfo pluginInfo)
        {
            ListViewItem item = new ListViewItem(pluginInfo.ClassName);
            ListViewItem.ListViewSubItem sub1 = new ListViewItem.ListViewSubItem(item, pluginInfo.Filename);
            ListViewItem.ListViewSubItem sub2 = new ListViewItem.ListViewSubItem(item, pluginInfo.Loaded.ToString());

            item.SubItems.Add(sub1);
            item.SubItems.Add(sub2);

            item.Tag = pluginInfo;

            lstPlugins.Items.Add(item);
        }

        private void btnBrowsePlugin_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            opf.Filter = "File Assembly .NET|*.dll";

            if (opf.ShowDialog(this) == DialogResult.OK)
            {
                Assembly assembly = Assembly.LoadFile(opf.FileName);

                Type[] tps = assembly.GetTypes();

                bool havePlugin = false;

                foreach (Type current in tps)
                {
                    if (current.IsSubclassOf(PluginApplication.Istance.Manager.PluginBaseType))
                    {
                        havePlugin = true;                        

                        if (!opf.FileName.Contains(PluginApplication.Istance.
                            Manager.AssemblySearchPath))
                        {
                            File.Copy(opf.FileName,
                                Path.Combine(PluginApplication.Istance.Manager.AssemblySearchPath,
                                Path.GetFileName(opf.FileName)),true);
                        }

                        string file = Path.GetFileName(opf.FileName);

                        string className = current.FullName;

                        PluginLoadInfo info = new PluginLoadInfo(false, file, className);

                        PluginApplication.Istance.Manager.Plugins.Add(info.ClassName, info);

                        AddItem(info);
                    }
                }

                if (!havePlugin)
                {
                    MessageBox.Show("The assembly not contain a valid plugin");
                }
            }
        }

        private void btnLoadAtStart_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem current in lstPlugins.SelectedItems)
            {
                PluginLoadInfo info = (PluginLoadInfo)current.Tag;

                info.Loaded = !info.Loaded;

                current.SubItems[2].Text = info.Loaded.ToString();
            }
        }

        private void btnLoadNow_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem current in lstPlugins.SelectedItems)
            {
                PluginLoadInfo info = (PluginLoadInfo)current.Tag;

                PluginApplication.Istance.Manager.LoadPlugin(info);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            PluginApplication.Istance.Manager.Save();
        }
    }
}