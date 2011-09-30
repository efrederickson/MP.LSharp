// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Xml;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.SharpDevelop.Internal.Templates;
using ICSharpCode.SharpDevelop.Project;

namespace LSharp.SharpDevelop.AddIn
{
	public class LSharpProjectBinding : IProjectBinding
	{
		public const string LanguageName = "LSharp";
		
		public string Language {
			get {
				return LanguageName;
			}
		}
		
		public IProject LoadProject(ProjectLoadInformation loadInformation)
		{
			return new LSharpProject(loadInformation);
		}
		
		public IProject CreateProject(ProjectCreateInformation info)
		{
			return new LSharpProject(info);
		}
		
		public LanguageProperties LanguageProperties {
			get {
				return LSharpLanguageProperties.Instance;
			}
		}
		
		public bool HandlingMissingProject {
			get { 
				return false; 
			}
		}
	}
}
