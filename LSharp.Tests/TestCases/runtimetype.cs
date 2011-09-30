using System;
using System.Reflection;
using System.IO;

namespace LSharp
{
	/// <summary>
	/// the LSharp script that is compiled to an EXE/DLL
	/// </summary>
	public class ClassName814138053
	{
		string[] LSharpCode = {";; Test changes to evaluator suggested by Patrick",";; ... how do you translate this code in LSharp?",";;",";; Object o = new DateTime(2005,8,10);",";; Object p = o.GetType();",";; Console.WriteLine(p.ToString());","","(= o (new DateTime 2005 8 10))","(= p (GetType o))","(prl (ToString p))",""};
		LSharp.Runtime runtime;
		//Environment globalEnvironment;
				
		[STAThread()]
		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Resolver);
			new ClassName814138053().Activate(args);
		}
		
		public void Activate(string[] args)
		{
			try
			{
				runtime = new Runtime();
				Environment globalEnvironment = new Environment();
				string code = "";
				foreach (string line in LSharpCode)
					code += "\n" + line;

				object output = Runtime.EvalString(code, globalEnvironment);
				Console.WriteLine(Printer.WriteToString(output));
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