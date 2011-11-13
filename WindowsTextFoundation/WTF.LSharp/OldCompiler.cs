using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;
using System.Windows.Forms;
using LSharp;

namespace WindowsTextFoundation.LSharpProvider
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

        public static CompilerResults Compile(string code, string filename, OutputType ot, string[] WTFScripts)
        {
            //Generate Parameters and Code Provider
            Microsoft.CSharp.CSharpCodeProvider csharp = new Microsoft.CSharp.CSharpCodeProvider();
            CompilerParameters param = new CompilerParameters();
            param.GenerateInMemory = false;
            param.IncludeDebugInformation = true;
            param.GenerateExecutable=ot == OutputType.Dll ? false : true;
            param.OutputAssembly =System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filename), System.IO.Path.GetFileNameWithoutExtension(filename) + (ot == OutputType.Dll ? ".dll" : ".exe"));
            param.EmbeddedResources.Add(Application.StartupPath + "\\LSharp.dll");
            param.ReferencedAssemblies.Add(Application.StartupPath + "\\LSharp.dll");
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
                default: // this shouldnt ever happen though...
                    param.CompilerOptions = "/target:exe";
                    break;
            }
            
            // Generate LSharp Code
            string lsscript = GetLSScript();
            lsscript = lsscript.Replace("{ClassName}", "ClassName" + classname2);
            string lscode = "";
             // add WTF Code
            foreach (string wtffile in WTFScripts)
            {
                if (wtffile == "")
                    continue;
                List<WindowsTextFoundation.Core.AST.WTFObject> o = WindowsTextFoundation.Core.WindowsTextFoundation.FromFile(wtffile).Objects;
                foreach (WindowsTextFoundation.Core.AST.WTFObject oo in o)
                    lscode += oo.ToLSharp();
            }
            lscode += code;
            // Compiling
            lscode = lscode.Replace("\\", "\\\\"); // \ to \\
            lscode = lscode.Replace("\"", "\\\""); // " to \"
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
                bool verbose = false;
                foreach (string arg in args)
                {
                    if (arg == " + "\"/verbose\"" + @")
                        verbose = true;
                }
                runtime = new Runtime();
                Environment globalEnvironment = new Environment();
                string code = " + "\"(do \"" +  @";
                foreach (string line in LSharpCode)
                {
                    code += " + "\"\\n\"" + @" + line;
                    if (verbose)
                        Console.WriteLine(" + "\"Adding \" + line + \"...\"" + @");
                    //object o = Runtime.EvalString(line);
                    //Console.WriteLine(Printer.WriteToString(o));
                }
                code += " + "\")\"" + @";
                if (verbose)
                    Console.WriteLine(""Code:"" + code);
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