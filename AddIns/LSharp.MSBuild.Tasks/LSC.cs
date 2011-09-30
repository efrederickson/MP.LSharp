/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/23/2011
 * Time: 11:23 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.Build.Tasks;
using Microsoft.Build.Utilities;

namespace LSharp.MSBuild.Tasks
{
	/// <summary>
	/// LSC Task
	/// </summary>
	public class lsc : ToolTask
	{
		public lsc()
		{
		}
		
		protected override string ToolName {
			get {
				return "lsc.exe";
			}
		}
		
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
		protected string TargetType
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
		
		protected override string GenerateFullPathToTool()
		{
			string text = string.Empty;
			if (!string.IsNullOrEmpty(this.ToolPath))
			{
				text = System.IO.Path.Combine(this.ToolPath, this.ToolName);
			}
			string arg_94_0;
			if (System.IO.File.Exists(text))
			{
				arg_94_0 = text;
			}
			else
			{
				text = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(typeof(LSC.Compiler).Assembly.Location), this.ToolName);
				if (System.IO.File.Exists(text))
				{
					arg_94_0 = text;
				}
				else
				{
					text = ToolLocationHelper.GetPathToDotNetFrameworkFile(this.ToolName, TargetDotNetFrameworkVersion.VersionLatest);
					if (System.IO.File.Exists(text))
					{
						arg_94_0 = text;
					}
					else
					{
						text = "lsc";
						arg_94_0 = text;
					}
				}
			}
			return arg_94_0;
		}
	}
}