/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/13/2011
 * Time: 1:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LSharp.Studio.Plugins
{
	/// <summary>
	/// Interface for Text Editors
	/// </summary>
	public interface ICodeEditor
	{
		
		void Save();
		void SaveAs();
		Alsing.Windows.Forms.SyntaxBoxControl TextBox
		{
			get;
		}
		Alsing.SourceCode.SyntaxDocument SyntaxDoc
		{get; }
		
        string Filename { get; set;  }
	}
}
