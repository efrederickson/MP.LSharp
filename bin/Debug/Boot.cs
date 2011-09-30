using System;
using System.Reflection;
using System.IO;

namespace LSharp
{
	/// <summary>
	/// the LSharp script that is compiled to an EXE/DLL
	/// </summary>
	public class ClassName43610125
	{
		string[] LSharpCode = {"(reference \"System.Windows.Forms\")","(using \"System.Windows.forms\")","","(= top (new TopLoop))","(run top)"};
		LSharp.Runtime runtime;
		//Environment globalEnvironment;
				
		[STAThread()]
		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Resolver);
			new ClassName43610125().Activate(args);
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