// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.ComponentModel;
using System.IO;

using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Dom;
using ICSharpCode.SharpDevelop.Internal.Templates;
using ICSharpCode.SharpDevelop.Project;

namespace LSharp.SharpDevelop.AddIn
{
	public class LSharpProject : CompilableProject
	{
		public static readonly string LSharpBinPath = Path.GetDirectoryName(typeof(LSharpProject).Assembly.Location);
		
		void Init()
		{
			reparseReferencesSensitiveProperties.Add("TargetFrameworkVersion");
		}
		
		public override string Language {
			get { return LSharpProjectBinding.LanguageName; }
		}
		
		public override LanguageProperties LanguageProperties {
			get { return LSharpLanguageProperties.Instance; }
		}
		
		public LSharpProject(ProjectLoadInformation info)
			: base(info)
		{
			Init();
		}
		
		public LSharpProject(ProjectCreateInformation info)
			: base(info)
		{
			Init();
			
			SetProperty("Debug", null, "DefineConstants", "DEBUG;TRACE",
			            PropertyStorageLocations.ConfigurationSpecific, false);
			SetProperty("Release", null, "DefineConstants", "TRACE",
			            PropertyStorageLocations.ConfigurationSpecific, false);
		}
		
		void AddReference(string assembly)
		{
			foreach (ProjectItem item in this.Items) {
				if (item.ItemType == ItemType.Reference && item.Include == assembly)
					return;
			}
			((IProjectItemListProvider)this).AddProjectItem(new ReferenceProjectItem(this, assembly));
		}
		
		public override ItemType GetDefaultItemType(string fileName)
		{
			if (string.Equals(Path.GetExtension(fileName), ".ls", StringComparison.OrdinalIgnoreCase))
				return ItemType.Compile;
			else
				return base.GetDefaultItemType(fileName);
		}
		
		internal static IProjectContent LSharpCompilerPC;
		
		protected override ParseProjectContent CreateProjectContent()
		{
			if (LSharpCompilerPC == null) {
				ReferenceProjectItem LSharpCompilerItem = new ReferenceProjectItem(this, typeof(LSharp.Compiler).Assembly.Location);
				LSharpCompilerPC = AssemblyParserService.GetProjectContentForReference(LSharpCompilerItem);
			}
			ParseProjectContent pc = base.CreateProjectContent();
			ReferenceProjectItem systemItem = new ReferenceProjectItem(this, "System");
			pc.AddReferencedContent(AssemblyParserService.GetProjectContentForReference(systemItem));
			pc.DefaultImports = new DefaultUsing(pc);
			pc.DefaultImports.Usings.Add("LSharp");
			return pc;
		}
		
		public override IAmbience GetAmbience()
		{
			return new NetAmbience();
		}
		
	}
}
