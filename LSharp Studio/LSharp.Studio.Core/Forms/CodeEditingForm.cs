/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/8/2011
 * Time: 4:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;
using Alsing.SourceCode;
using Alsing.Windows.Forms;

namespace LSharp.Studio.Core
{
    /// <summary>
    /// The L# Code Editor.
    /// </summary>
    public partial class CodeEditingForm : WeifenLuo.WinFormsUI.Docking.DockContent, LSharp.Studio.Plugins.ICodeEditor
    {
        private string _filename;
        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
            }
        }
        public CodeEditingForm(string docname)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            // Sets the L# language syntax document
            SyntaxDefinitionList list = new SyntaxDefinitionList();
            if (!System.IO.File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location) + "\\LSharp.syn"))
            {
                // create from Embedded Resource
    	       string embeddedName = String.Format("LSharp.Studio.Core.LSharp.syn");
    	       var me = System.Reflection.Assembly.GetExecutingAssembly();
    	       System.IO.Stream StreAm =  me.GetManifestResourceStream(embeddedName);
    	       FileStream fs = new FileStream(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location) + "\\LSharp.syn", FileMode.Create);
    	       StreAm.CopyTo(fs);
    	       fs.Close();
    	       StreAm.Close();
            }
            System.Collections.Generic.List<SyntaxDefinition>l2 = list.GetSyntaxDefinitions();
            l2.Add(new SyntaxDefinitionLoader().Load(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location) + "\\LSharp.syn"));
            Alsing.SourceCode.SyntaxDefinition def = l2[0];
            syntaxDocument1.Parser.Init(def);
            Filename = LSharp.Studio.Core.Properties.Settings.Default.DefaultSaveLocation + "\\" + docname;
        }
        
        public void LoadFile(string filename)
        {
            syntaxDocument1.Text = System.IO.File.ReadAllText(filename);
            syntaxDocument1.ReParse();
            this.TabText = System.IO.Path.GetFileName(filename);
            this.Filename = filename;
        }
                
        public SyntaxBoxControl TextBox
        {
            get {
                return syntaxBoxControl1;
            }
        }
        private void SyntaxBox1_TextChanged(object sender, EventArgs e)
        {
            if (! this.TabText.EndsWith(" *"))
            	this.TabText += " *";
            else
            {}
        }
        
        
        public void Save()
        {
            if (Filename == "")
            {
                SaveFileDialog dlg = new SaveFileDialog();
                // TODO: load a filter
                dlg.Filter = "L# Scripts (*.ls)|*.ls|All Files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(dlg.FileName, syntaxDocument1.Text);
                    Filename = dlg.FileName;
                    this.TabText = System.IO.Path.GetFileName(dlg.FileName);
                }
            } else {
                System.IO.File.WriteAllText(Filename, syntaxDocument1.Text);
                this.TabText = System.IO.Path.GetFileName(Filename);
            }
        }
        
        public void SaveAs()
        {
            Filename = "";
            Save();
        }

        private void CodeEditingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.TabText.EndsWith(" *"))
            {
                switch (MessageBox.Show("Save Document \"" + Filename + "\"?", "L# Studio", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                            Save();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

    	
		public SyntaxDocument SyntaxDoc {
			get {
				return syntaxDocument1;
			}
		}
    }
}
