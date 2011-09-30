using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LSharp.Studio.Core.Forms
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
        	// Set up the form
            DefaultSaveLocationTextBox.Text = LSharp.Studio.Core.Properties.Settings.Default.DefaultSaveLocation;
            if (LSharp.Studio.Core.Properties.Settings.Default.CompileType == "Exe")
            	exeRadioButton.Checked = true;
            else if (LSharp.Studio.Core.Properties.Settings.Default.CompileType =="WinFormsExe")
            	winFormsExeRadioButton.Checked = true;
            else if (LSharp.Studio.Core.Properties.Settings.Default.CompileType == "Dll")
            	dllRadioButton.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        	// Save settings 
            LSharp.Studio.Core.Properties.Settings.Default.DefaultSaveLocation = DefaultSaveLocationTextBox.Text;
            if (exeRadioButton.Checked)
            	LSharp.Studio.Core.Properties.Settings.Default.CompileType = "Exe";
            else if (winFormsExeRadioButton.Checked)
            	LSharp.Studio.Core.Properties.Settings.Default.CompileType = "WinFormsExe";
            else if (dllRadioButton.Checked)
            	LSharp.Studio.Core.Properties.Settings.Default.CompileType = "Dll";
            
            LSharp.Studio.Core.Properties.Settings.Default.Save();
            this.Close();
        }
        
        void Button3_Click(object sender, EventArgs e)
        {
            SetDefaultProgramsForm SDPF = new SetDefaultProgramsForm();
            SDPF.ShowDialog();
        }
    }
}
