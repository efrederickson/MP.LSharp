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
using System.CodeDom.Compiler;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;

namespace LSharp
{    
	/// <summary>
	/// Compile an L Sharp program.
	/// Eventually change this to IL Generation
	/// </summary>	
	public class Compiler
	{
		public enum OutputType
    {
        Exe,
        Dll,
        //NetModule
        WinFormsExe
    }
				
//		private static void Compile(string filename, object program)
//		{
//			AppDomain appDomain = Thread.GetDomain();
//			AssemblyName assemblyName = new AssemblyName();
//			assemblyName.Name = Path.GetFileName(filename);
//			AssemblyBuilder assemblyBuilder = appDomain.DefineDynamicAssembly(assemblyName,AssemblyBuilderAccess.RunAndSave,Path.GetDirectoryName(filename));
//			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(Path.GetFileName(filename), Path.GetFileName(filename));
//			TypeBuilder typeBuilder = moduleBuilder.DefineType(Path.GetFileName(filename));
//			MethodBuilder methodBuilder = typeBuilder.DefineMethod("Main", MethodAttributes.Static | MethodAttributes.Public,typeof(void),null);
//			ILGenerator iLGenerator = methodBuilder.GetILGenerator();
//			
//			iLGenerator.EmitWriteLine("IL Generator not implemented. You can help by creating the IL Generator.");
//			iLGenerator.Emit(OpCodes.Ret);
//			typeBuilder.CreateType();
//			assemblyBuilder.SetEntryPoint((moduleBuilder.GetType(Path.GetFileName(filename))).GetMethod("Main"));
//
//			assemblyBuilder.Save(Path.GetFileName(filename));
//		}
		
		public static CompilerResults Compile(string[] filenames, OutputType ot)
		{
			//Generate Parameters and Code Provider
			Microsoft.CSharp.CSharpCodeProvider csharp = new Microsoft.CSharp.CSharpCodeProvider();
			CompilerParameters param = new CompilerParameters();
			param.GenerateInMemory = false;
			param.IncludeDebugInformation = true;
			param.GenerateExecutable=ot == OutputType.Dll ? false : true;
			param.OutputAssembly =System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filenames[0]), System.IO.Path.GetFileNameWithoutExtension(filenames[0]) + (ot == OutputType.Dll ? ".dll" : ".exe"));
			param.EmbeddedResources.Add(System.Reflection.Assembly.GetExecutingAssembly().Location);
            param.ReferencedAssemblies.Add(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string classname2 =(new System.Random(DateTime.Now.Millisecond)).Next().ToString();
            switch (ot)
            {
           	case OutputType.Dll:
            		param.CompilerOptions = "/target:library";
            		break;
            	case OutputType.Exe:
            		param.CompilerOptions = "/target:exe";
            		break;
            	case OutputType.WinFormsExe:
            		param.CompilerOptions = "/target:winexe";
            		break;
            	default:
            		param.CompilerOptions = "/target:exe";
            		break;
            }
            param.MainClass = "LSharp.ClassName" + classname2;
            
			// Generate LSharp Code
			string lsscript = GetLSScript();
			lsscript = lsscript.Replace("{ClassName}", "ClassName" + classname2);
			string lscode ="";
			foreach (string filename in filenames)
			{
				try {
					lscode += System.IO.File.ReadAllText(filename);
				} catch {
					
				}
				// Attempt basic parsing.
				try
				{
					LSharp.Reader.Read(new System.IO.StringReader(lscode), LSharp.ReadTable.DefaultReadTable());
				}catch (Exception e){
					Console.WriteLine("Parsing Error: " + e.ToString());
					return null;
				}
					
				// Compiling
				lscode = lscode.Replace("\\", "\\\\");
				lscode = lscode.Replace("\"", "\\\"");
				string[] codes  = lscode.Split(new string[] {"\n"}, StringSplitOptions.None);
				string newcodes = "";
				for (int i = 0; i < codes.Length; i++)
					newcodes += "\"" + codes[i].Replace("\n","").Replace("\r","") + "\",";
				
				if (newcodes.EndsWith(","))
				    newcodes = newcodes.Substring(0, newcodes.Length -1);
				lsscript = lsscript.Replace("|insertcodehere|", newcodes);
				System.IO.File.WriteAllText(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filename), System.IO.Path.GetFileNameWithoutExtension(filename) + ".cs"), lsscript);
			}
			// Compile and return the results
			CompilerResults results= csharp.CompileAssemblyFromSource(param, lsscript);
			return results;
		}
		
		public static CompilerResults Compile(string code, string filename, OutputType ot)
		{
			//Generate Parameters and Code Provider
			Microsoft.CSharp.CSharpCodeProvider csharp = new Microsoft.CSharp.CSharpCodeProvider();
			CompilerParameters param = new CompilerParameters();
			param.GenerateInMemory = false;
			param.IncludeDebugInformation = true;
			param.GenerateExecutable=ot == OutputType.Dll ? false : true;
			param.OutputAssembly =System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filename), System.IO.Path.GetFileNameWithoutExtension(filename) + (ot == OutputType.Dll ? ".dll" : ".exe"));
			param.EmbeddedResources.Add(System.Reflection.Assembly.GetExecutingAssembly().Location);
		    param.ReferencedAssemblies.Add(System.Reflection.Assembly.GetExecutingAssembly().Location);
		    string classname2 =(new System.Random(DateTime.Now.Millisecond)).Next().ToString();
		    param.MainClass = "LSharp.ClassName" + classname2;
            switch (ot)
            {
           	case OutputType.Dll:
            		param.CompilerOptions = "/target:library";
            		break;
            	case OutputType.Exe:
            		param.CompilerOptions = "/target:exe";
            		break;
            	case OutputType.WinFormsExe:
            		param.CompilerOptions = "/target:winexe";
            		break;
            	default:
            		param.CompilerOptions = "/target:exe";
            		break;
            }
            
			// Generate LSharp Code
			string lsscript = GetLSScript();
			lsscript = lsscript.Replace("{ClassName}", "ClassName" + classname2);
			string lscode =code;
			// Compiling
			lscode = lscode.Replace("\\", "\\\\"); // \ to \\
			lscode = lscode.Replace("\"", "\\\""); // " tp \"
			string[] codes  = lscode.Split(new string[] {"\n"}, StringSplitOptions.None);
			string newcodes = "";
			for (int i = 0; i < codes.Length; i++)
				newcodes += "\"" + codes[i].Replace("\n","").Replace("\r","") + "\",";
			
			if (newcodes.EndsWith(","))
			    newcodes = newcodes.Substring(0, newcodes.Length -1);
			lsscript = lsscript.Replace("|insertcodehere|", newcodes);
			System.IO.File.WriteAllText(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filename), System.IO.Path.GetFileNameWithoutExtension(filename) + ".cs"), lsscript);
			
			// Compile and return the results
			CompilerResults results= csharp.CompileAssemblyFromSource(param, lsscript);
			return results;
		}
	
		private static System.IO.Stream GetEmbeddedStream(string name)
    	{
    	    string embeddedName = String.Format("LSharp.Compiler.{0}", name);
    	    var me = System.Reflection.Assembly.GetExecutingAssembly();
    	    System.IO.Stream ret =  me.GetManifestResourceStream(embeddedName);
    	    if (ret == null)
    	    	throw new Exception("Cannot find '" + embeddedName + "'");
    	    return ret;
    	}
		
		private static string GetLSScript()
		{ 
			return @"using System;
using System.Reflection;
using System.IO;

namespace LSharp
{
	/// <summary>
	/// the LSharp script that is compiled to an EXE/DLL
	/// </summary>
	public class {ClassName}
	{
		string[] LSharpCode = {|insertcodehere|};
		LSharp.Runtime runtime;
		//Environment globalEnvironment;
				
		[STAThread()]
		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Resolver);
			new {ClassName}().Activate(args);
		}
		
		public void Activate(string[] args)
		{
			try
			{
				runtime = new Runtime();
				Environment globalEnvironment = new Environment();
				string code = " + "\"(do \"" +  @";
				foreach (string line in LSharpCode)
					code += " + "\"\\n\"" + @" + line;
				code += " + "\")\"" + @";
				object output = Runtime.Eval(Reader.Read(new System.IO.StringReader(code),ReadTable.DefaultReadTable()), globalEnvironment);
				Console.WriteLine(Printer.WriteToString(output));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
			//TODO: enable this as a CMD Arg
			//System.Console.WriteLine(" + "\"" + "Press any key to Continue..." + "\"" + @");
			//System.Console.ReadKey(true);
		}
		
    static System.Reflection.Assembly Resolver(object sender, ResolveEventArgs args)
    {
        Assembly a1 = Assembly.GetExecutingAssembly();
        Stream s = a1.GetManifestResourceStream(" + "\"" + "LSharp.dll" + "\"" + @");
        byte[] block = new byte[s.Length];
        s.Read(block, 0, block.Length);
        Assembly a2 = Assembly.Load(block);
        return a2;
    }
	}
}";
	}
    } // end class
} // end namespace