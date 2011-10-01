/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/24/2011
 * Time: 1:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Alsing.SourceCode;

namespace LSharp.Studio.Debugger
{
	/// <summary>
	/// Description of Debugger.
	/// </summary>
	public class Debugger
	{
	    private string Arguments = "";
		private Alsing.Windows.Forms.SyntaxBoxControl syntaxBox;
		private Alsing.SourceCode.SyntaxDocument syntaxDocument;
		private System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
		private bool _stopped = true;
		public Debugger()
		{
			worker.DoWork += new DoWorkEventHandler(worker_DoWork);
		}

		void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			LSharp.Environment env = new LSharp.Environment();
			env.AssignLocal(Symbol.FromName("*debugger*"), this);
			int line = 0;
			syntaxDocument.Text += "\n";
			_stopped = false; //TODO: Set arguments
			while (line < syntaxDocument.Lines.Length)
			{
				if (_stopped)
				{
					MessageBox.Show("Stopped!");
					break;
				}
				// Run the next line
				string Nextcommand = syntaxDocument.GetRange(new TextRange(0, line, 0, line + 1));
				try
				{
				object result = Runtime.EvalString(Nextcommand, env);
				Console.WriteLine("Output from line '" + Nextcommand + "' (Line number " + line + "): " + Printer.WriteToString(result));
				} catch (Exception ex) {
					ShowErrorForm err = new ShowErrorForm(ex);
					err.ShowDialog();
				}
				line++;
			}
			syntaxDocument.Text = syntaxDocument.Text.Remove(syntaxDocument.Text.LastIndexOf("\n"));
		}
		
		public void Start(Alsing.Windows.Forms.SyntaxBoxControl syntaxbox, Alsing.SourceCode.SyntaxDocument syntaxdoc, string arguments)
		{
			this.syntaxBox = syntaxbox;
			this.syntaxDocument = syntaxdoc;
			this.Arguments = arguments;
			_stopped = false;
			try {
			worker.RunWorkerAsync();
			} catch {
			}
		}
		
		public void Stop()
		{
			_stopped = true;
			worker.WorkerSupportsCancellation=true;
			worker.CancelAsync();
		}
		
		public void StepOver()
		{
		//TODO	
		}
	}
}
