/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/20/2011
 * Time: 3:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace LSharp.CodeDom
{
	/// <summary>
	/// Description of LSharpCodeCompiler.
	/// </summary>
	public class LSharpCodeCompiler : ICodeCompiler
	{
		
		public CompilerResults CompileAssemblyFromDom(CompilerParameters options, CodeCompileUnit compilationUnit)
		{
			return CompileAssemblyFromDomBatch(options, new CodeCompileUnit[] { compilationUnit });
		}
		
		public CompilerResults CompileAssemblyFromFile(CompilerParameters options, string fileName)
		{
			return CompileAssemblyFromFileBatch(options, new string[] {fileName});
		}
		
		public CompilerResults CompileAssemblyFromSource(CompilerParameters options, string source)
		{
			return CompileAssemblyFromSourceBatch(options, new string[] { source });
		}
		
		public CompilerResults CompileAssemblyFromDomBatch(CompilerParameters options, CodeCompileUnit[] compilationUnits)
		{
			throw new NotImplementedException();
		}
		
		public CompilerResults CompileAssemblyFromFileBatch(CompilerParameters options, string[] fileNames)
		{
			string[] sources = new string[fileNames.Length];
			int i = 0;
			foreach (string filename in fileNames)
				sources[i] = System.IO.File.ReadAllText(filename);
			
			return CompileAssemblyFromSourceBatch(options, sources);
		}
		
		public CompilerResults CompileAssemblyFromSourceBatch(CompilerParameters options, string[] sources)
		{
			throw new NotImplementedException();
		}
	}
}
