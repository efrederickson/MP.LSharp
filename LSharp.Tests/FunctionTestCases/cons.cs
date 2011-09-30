using System;
using System.Reflection;
using System.IO;

namespace LSharp
{
	/// <summary>
	/// the LSharp script that is compiled to an EXE
	/// </summary>
	public class Compiled
	{
		string[] LSharpCode = {"(= foo (cons 'a 'b))","","(and","	(eq (car foo) 'a)","	(eq (cdr foo) 'b))"};
		LSharp.Runtime runtime;
		//Environment globalEnvironment;
				
		[STAThread()]
		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Resolver);
			new Compiled().Activate(args);
		}
		
		public void Activate(string[] args)
		{
			bool verbose = false;
			if (args.Length > 0)
			{
				foreach (string arg in args)
				{
					if (arg.ToLower() ==  "/verbose")
						verbose = true;
				}
			}
			try
			{
				runtime = new Runtime();
				Environment globalEnvironment = new Environment();
				foreach (string line in LSharpCode)
				{
					if (verbose)
						Console.Write(line + " --> ");
					System.IO.StringReader reader = new System.IO.StringReader(line);
					object output = Runtime.EvalString(line, globalEnvironment);
					Console.WriteLine(Printer.WriteToString(output));
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
			System.Console.WriteLine("Press any key to Continue...");
			System.Console.ReadKey(true);
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