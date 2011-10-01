using System;
using System.Reflection;
using System.IO;

namespace LSharp
{
	/// <summary>
	/// the LSharp script that is compiled to an EXE/DLL
	/// </summary>
	public class ClassName610785615
	{
		string[] LSharpCode = {"(using \"System\")","(using \"System.CodeDom.Compiler\")","(using \"System.Collections.Generic\")","(using \"System.Collections.Specialized\")","(using \"System.Diagnostics\")","(using \"System.IO\")",";;;(using \"LSharp.Compiler\")","","(prl \"L# Compiler version 1.0 (Written in L#)\")","(prl \"\")","(= env System.Environment)","(= args (GetCommandLineArgs env))","","(if (eql (length args) 0)","	(do ","		(prl \"Usage: lsc <options> <filenames>\\nOptions: -out:<winexe|exe|dll>\") ","		(exit 1) ;;; Return failed because no specified input","	)",")","","(= ot LSharp.Compiler.OutputType.Exe)","(prl \"Compiling \")","(= newArgs1 (new System.Collections.Specialized.StringCollection)) ;;; FIXME","(foreach arg args","	(if (startswith arg \"-out:\")","		(do ","			(if (endswith arg \"winexe\")","				(= ot LSharp.Compiler.OutputType.WinFormsExe))","			(if (endswith arg \"dll\")","				(= ot LSharp.Compiler.OutputType.Dll))","			(if (endswith arg \"exe\")","				(= ot LSharp.Compiler.OutputType.Exe))","		)","		(do ","			(prl arg \" \")","			(add newArgs1 arg)","		)","	)",")","(prl \"...\")","(= newArgs null)) ;;; FIXME (new string[])","(TrimExcess newArgs1)","(CopyTo newArgs1 newArgs)","(= r (call Compile Compiler newArgs, ot))","(if (eql r null) ","	(do ","		(prl \"Failed to Compile: Unspecified error!\")","		(exit 1)","	)",")","(if (> (length (errors r)) 0)","	(do ","		(foreach err (errors r)","			(prl (tostring err))","			(exit 1)","		)","	)",")","(prl \"Compiled to \"  (GetFileNameWithoutExtension Path newArgs[0]) (if (eql ot LSharp.Compiler.OutputType.Dll) \".dll\" \".exe\"));",";;;Process.Start(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(args[0]), System.IO.Path.GetFileNameWithoutExtension(args[0]) + \".exe\"));","(exit 0)"};
		LSharp.Runtime runtime;
		//Environment globalEnvironment;
				
		[STAThread()]
		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Resolver);
			new ClassName610785615().Activate(args);
		}
		
		public void Activate(string[] args)
		{
			try
			{
				runtime = new Runtime();
				Environment globalEnvironment = new Environment();
				string code = "(do ";
				foreach (string line in LSharpCode)
					code += "\n" + line;
				code += ")";
				object output = Runtime.Eval(Reader.Read(new System.IO.StringReader(code),ReadTable.DefaultReadTable()), globalEnvironment);
				Console.WriteLine(Printer.WriteToString(output));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
			//TODO: enable this as a CMD Arg
			//System.Console.WriteLine("Press any key to Continue...");
			//System.Console.ReadKey(true);
		}
		
    static System.Reflection.Assembly Resolver(object sender, ResolveEventArgs args)
    {
        Assembly a1 = Assembly.GetExecutingAssembly();
        Stream s = a1.GetManifestResourceStream("LSharp.dll");
        byte[] block = new byte[s.Length];
        s.Read(block, 0, block.Length);
        Assembly a2 = Assembly.Load(block);
        return a2;
    }
	}
}