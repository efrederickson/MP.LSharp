using Microsoft.Build.Framework;
using Microsoft.Build.Tasks;
using Microsoft.Build.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
namespace LSharp.MSBuild.Tasks
{
	[System.Serializable]
	public class ExecLSharp : Task
	{
		protected string _src;
		[Microsoft.Build.Framework.Required]
		public string Source
		{
			get
			{
				return this._src;
			}
			set
			{
				this._src = value;
			}
		}
		
		protected string outputtype;
		[Microsoft.Build.Framework.Required]
		public string TargetType
		{
			get{
				return this.outputtype;
			}
			set
			{
				this.outputtype = value;
			}
		}
		
		protected string _sourceDir;
		protected string SourceDirectory
		{
			get
			{
				return _sourceDir;
			}
			set 
			{
				_sourceDir = value;
			}
		}
		
		public ExecLSharp()
		{
			
		}
		
		public override bool Execute()
		{
			string filename = (base.BuildEngine as IBuildEngine).ProjectFileOfTaskNode;
			//TODO: define dll/exe/winexe
			int result = LSC.Compiler.Main(new string[] {filename, "-out:exe"});
			if (result == 1)
				return false;
			else
				return true;
		}
	}
}
