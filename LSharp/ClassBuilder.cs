#region Copyright (C) 2005 Rob Blackwell & Active Web Solutions.
//
// L Sharp .NET, a powerful lisp-based scripting language for .NET.
// Copyright (C) 2005 Rob Blackwell & Active Web Solutions.
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Library General Public
// License as published by the Free Software Foundation; either
// version 2 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Library General Public License for more details.
// 
// You should have received a copy of the GNU Library General Public
// License along with this library; if not, write to the Free
// Software Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
//
#endregion

using System;

// Highly experimental class definition facility !

using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
namespace LSharp
{
	/// <summary>
	/// Experimental, unfinished, but it works
	/// </summary>
	public class ClassBuilder
	{
		public static Type CreateClass(string className, string superClass, string interfaces, DefinedMethod[] LSharpCode)
		{
			
			StringBuilder source = new StringBuilder("using System;\n");
			source.AppendLine("using LSharp; ");
			if (superClass == null)
				source.AppendLine(string.Format("class {0} {{",className));
			else
				source.AppendLine(string.Format("class {0} : {1} {{",className, superClass));
			foreach (DefinedMethod method in LSharpCode)
			{
				try 
				{
					source.Append("public object " + method.Name + "(");
					// 9/30/11 fixed so 0 arguments are allowed.
					if (method.args.Length > 0 & !string.IsNullOrEmpty(method.args[0]))
					{
						source.Append("object " + method.args[0]);
						for (int i = 1; i < method.args.Length; i++)
							source.Append(", object " + method.args[i]);
					}
					source.Append(") {\n");
					source.Append("object retValue = null;");
					source.Append("\tLSharp.Environment env = new LSharp.Environment();\n");
					if (method.args.Length > 0 & !string.IsNullOrEmpty(method.args[0]))
					{
						source.AppendLine("\tRuntime.EvalString(\"(= " + method.args[0] + " \" + " + method.args[0] +  " + \")\", env);");
						for (int i = 1; i < method.args.Length; i++)
													source.AppendLine("\tRuntime.EvalString(\"(= " + method.args[i] + " \" + " + method.args[i] +  " + \")\", env);");
					}
					source.Append("\tretValue = Runtime.Eval(Reader.Read(new System.IO.StringReader(\"" + method.Commands + "\"), ReadTable.DefaultReadTable()), env);\n");
					source.Append("return retValue;\n"); 
					// TODO: return results of above commands
					source.Append("}\n");
				} catch (Exception e) {
					Console.WriteLine(e.Message);
					source.AppendLine("// ERROR: " + e.Message);
				}
			}
			source.AppendLine("}");
			Console.WriteLine(source.ToString());
			
			CSharpCodeProvider cscompiler = new CSharpCodeProvider();
			ICodeCompiler compiler = cscompiler.CreateCompiler();
			CompilerParameters compparams = new CompilerParameters();
			compparams.GenerateInMemory = true;
			
			compparams.ReferencedAssemblies.Add("LSharp.dll");
//			foreach (Assembly a in AssemblyCache.Instance().Assemblies()) {
//				compparams.ReferencedAssemblies.Add(a.FullName);
//			}
																				 
			CompilerResults compresult = compiler.CompileAssemblyFromSource(
			compparams, source.ToString());
			if ( compresult == null | compresult.Errors.Count > 0 ) 
			{
				foreach (CompilerError e in compresult.Errors) 
				{
					Console.WriteLine(e);
				}
				throw new Exception("class creation error");
			}

			Object o = TypeCache.Instance().FindType(className);
			if (o != null)
			{
				Assembly a = Assembly.GetAssembly(o as Type);
				AssemblyCache.Instance().Remove(a);
			}

			AssemblyCache.Instance().Add(compresult.CompiledAssembly);
			return compresult.CompiledAssembly.GetType(className);
		}
	}
}
