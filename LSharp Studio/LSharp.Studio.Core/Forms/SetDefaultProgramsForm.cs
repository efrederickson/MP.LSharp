/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/29/2011
 * Time: 10:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LSharp.Studio.Core.Forms
{
    /// <summary>
    /// Description of SetDefaultProgramsForm.
    /// </summary>
    public partial class SetDefaultProgramsForm : Form
    {
        public SetDefaultProgramsForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            listBox1.Items.Add(".ls");
            listBox1.Items.Add(".lsi");
        }
        
        void Button1_Click(object sender, EventArgs e)
        {
            try {
                listBox1.Items.Remove(listBox1.SelectedItem);
            } catch (Exception) {
                MessageBox.Show("Please select an item!");
            }
        }
        
        void Button2_Click(object sender, EventArgs e)
        {
            foreach (string item in listBox1.Items)
                ExtensionMods.Set(item, "L# Studio Document", Application.ExecutablePath);
            this.Close();
        }
    }
}

public class ExtensionMods
{
	public static void Set(string extension, string extInfo, string myName)
	{
	    Microsoft.Win32.Registry.SetValue(string.Format("HKEY_CURRENT_USER\\Software\\Classes\\LSharpStudio{0}.File", extension), "", "");
		Microsoft.Win32.Registry.SetValue(string.Format("HKEY_CURRENT_USER\\software\\Classes\\LSharpStudio{0}.File\\", extension), "", extInfo);
		Microsoft.Win32.Registry.SetValue(string.Format("HKEY_CURRENT_USER\\software\\Classes\\LSharpStudio{0}.File\\shell", extension), "", "");
		Microsoft.Win32.Registry.SetValue(string.Format("HKEY_CURRENT_USER\\software\\Classes\\LSharpStudio{0}.File\\shell\\open", extension), "", "");
		Microsoft.Win32.Registry.SetValue(string.Format("HKEY_CURRENT_USER\\software\\Classes\\LSharpStudio{0}.File\\shell\\open\\command", extension), "", string.Format("\"{0}\" \"%1\"", myName));
		Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\" + extension, "", string.Format("LSharpStudio{0}.File", extension));
	}
}
