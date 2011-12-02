using System;
using System.Reflection;
using System.IO;

namespace LSharp
{
    /// <summary>
    /// the LSharp script that is compiled to an EXE/DLL
    /// </summary>
    public class ClassName1281368029
    {
        string[] LSharpCode = {"(= frm (new System.Windows.Forms.Form ))","(set_Size frm (new System.Drawing.Size 100 100))","(set_Name frm \"Form1\")","(set_TabIndex frm 1)","~NAMESPACE = LSharp.Sample~","~CLASS = SampleClass~","(reference \"$(SDKPath)System.Windows.Forms.dll\")","(= frm (new \"System.Windows.Forms.Form\"))","(ShowDialog frm)"};
        LSharp.Runtime runtime;
        //Environment globalEnvironment;
                
        [STAThread()]
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Resolver);
            new ClassName1281368029().Activate(args);
        }
        
        public void Activate(string[] args)
        {
            try
            {
                bool verbose = false;
                foreach (string arg in args)
                {
                    if (arg == "/verbose")
                        verbose = true;
                }
                runtime = new Runtime();
                Environment globalEnvironment = new Environment();
                string code = "(do ";
                foreach (string line in LSharpCode)
                {
                    code += "\n" + line;
                    if (verbose)
                        Console.WriteLine("Adding " + line + "...");
                    //object o = Runtime.EvalString(line);
                    //Console.WriteLine(Printer.WriteToString(o));
                }
                code += ")";
                if (verbose)
                    Console.WriteLine("Code:" + code);
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