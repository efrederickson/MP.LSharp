/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/13/2011
 * Time: 11:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace LSharp.Studio.Core.Utils
{
	/// <summary>
	/// Watches the Output of something
	/// </summary>
	public class OutputWatcher
	{
		System.Collections.Generic.Queue<string> outputQueue = new System.Collections.Generic.Queue<string>();
		public OutputType _OutputType;
		public Timer timer;
		public Alsing.SourceCode.SyntaxDocument Document = new Alsing.SourceCode.SyntaxDocument();
		public System.IO.StringWriter writer = new System.IO.StringWriter();
		public bool changed = false;
		public string Text
		{
			get {
				return _OutputType.ToString();
			}
		}
		public OutputWatcher(OutputType type)
		{
			timer = new Timer();
			this._OutputType=type;
			timer.Enabled = true;
			timer.Interval = 100;
			if (_OutputType == OutputType.Console)
			{
				System.Console.SetOut(writer);
				System.Console.SetError(writer);
			} else if (_OutputType == OutputType.Debug) {
				//TODO
			} else {
				throw new ArgumentException("Cannot Find " + _OutputType.ToString() + "!");
			}
			timer.Tick += delegate(object sender, EventArgs e) { 
				if (Document.Text != writer.ToString())
				{
					Document.Text = writer.ToString();
					changed = true;
				}
			};
			
			Document = new Alsing.SourceCode.SyntaxDocument();
			changed = true;
		}
	}
}
