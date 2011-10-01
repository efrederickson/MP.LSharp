using System;
using System.Reflection;
using System.IO;

namespace LSharp
{
	/// <summary>
	/// the LSharp script that is compiled to an EXE/DLL
	/// </summary>
	public class ClassName402072949
	{
		string[] LSharpCode = {";;; Provides a command line interpreter for L Sharp",";;; NOW IT IS IN L#!!!",";;; TODO: load command line arguments","",";;; Banner","(prl \"Welcome to L Sharp .NET, a powerful lisp-based scripting language for .NET.\")","(prl \"Copyright (C) 2005 - 2006 Rob Blackwell & Active Web Solutions.\")","(prl \"Copyright (C) 2011 mlnlover11 Productions\")","(prl \"This version of LSI was written in L#\")","(prl \"This program is free software and is distributed under the terms of\")","(prl \"the GNU General Public License.\")","(prl \"For more information, see www.lsharp.org and \")","(prl \"http://elijah.awesome99.org/index.php/lsharp\")","(prl \"\")","(= environment System.Environment)","(foreach filename (GetCommandLineArgs environment)","	(prl filename)","	(if (endswith filename \"lsi.exe\") (prl \"\") (","		(if (endswith filename \"lsi.ls\") (prl \"\") (","			(= filename (replace filename \"\\\\\" \"\\\\\\\\\"))","			(prl \"Loading \" filename)","			(load filename)","		))","	))",")","(= top (new toploop))","(call run top)"};
		LSharp.Runtime runtime;
		//Environment globalEnvironment;
				
		[STAThread()]
		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Resolver);
			new ClassName402072949().Activate(args);
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