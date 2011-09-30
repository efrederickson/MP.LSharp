using ICSharpCode.SharpDevelop.Editor;
using System;
using ICSharpCode.SharpDevelop;

namespace LSharp.SharpDevelop.AddIn
{
	public class LSharpLanguageBinding : DefaultLanguageBinding
	{
		public override IFormattingStrategy FormattingStrategy {
			get { return new DefaultFormattingStrategy(); }
		}
	}
}
