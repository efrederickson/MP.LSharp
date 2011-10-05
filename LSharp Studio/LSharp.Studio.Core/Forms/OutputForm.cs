using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace LSharp.Studio.Core
{
	public enum OutputType : int
    {
        Console = 0, 
        Debug = 1, //TODO
    }
	
    public partial class OutputForm : DockContent
    {
    	System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    	internal Utils.OutputWatcher[] watchers = new LSharp.Studio.Core.Utils.OutputWatcher[2]; //FIX
        #region Constructors

        public OutputForm()
        {
            InitializeComponent();
            this.ShowHint = DockState.DockBottom;
            
            // Set Console
            Utils.OutputWatcher consoleWatcher = new LSharp.Studio.Core.Utils.OutputWatcher(OutputType.Console);
            tscboOutputTypes.Items.Add("Console");
            watchers[0] = consoleWatcher;
            tscboOutputTypes.SelectedIndex = 0;
            
            // Set Timer 
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += delegate(object sender, EventArgs e) {
            	tscboOutputTypes_SelectedIndexChanged(sender, e);
            };
        }

        #endregion

        private void tscboOutputTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
        	Utils.OutputWatcher _current = (Utils.OutputWatcher)watchers[tscboOutputTypes.SelectedIndex];
        	if (_current == null)
        	{
        		System.Diagnostics.Debug.WriteLine("Cannot get watcher at index " + tscboOutputTypes.SelectedIndex);
        		MessageBox.Show("Cannot get watcher at index " + tscboOutputTypes.SelectedIndex);
        		return;
        	}
            txtOutput.SuspendLayout();
            if (_current.changed)
            {
            	txtOutput.GotoLine(0);
            	txtOutput.Document = _current.Document;
            	_current.changed = false;
            	txtOutput.GotoLine(txtOutput.Document.Lines.Length - 1);
            }
            txtOutput.ResumeLayout();
        }

        private void tsbClearAll_Click(object sender, EventArgs e)
        {
            Utils.OutputWatcher _current = (Utils.OutputWatcher)watchers[tscboOutputTypes.SelectedIndex];
        	_current.writer.Flush();
        	_current.writer = new System.IO.StringWriter(); // FIXME
            txtOutput.Document.Clear();
        }

        private void tsbToggleWordWrap_Click(object sender, EventArgs e)
        {
            // TODO
        }

        #region Methods

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }
        
        #endregion
    }
}