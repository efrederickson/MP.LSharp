/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 11/30/2011
 * Time: 9:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace LSharp.Studio.WTFPlugin.Forms
{
    /// <summary>
    /// Properties manipulator form
    /// </summary>
    public partial class PropertiesForm : DockContent
    {
        public PropertiesForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        public void UpdateForm()
        {
            // ...
        }
        
        public void SelectObject(object c)
        {
            propertyGrid1.SelectedObject = c;
        }
    }
}
