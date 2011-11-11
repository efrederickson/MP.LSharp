/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 11/10/2011
 * Time: 4:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace WindowsTextFoundation.CSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> sources = new List<string>();
            string cscode = "using System.Windows.Forms;\n";
            foreach (string filename in args)
            {
                if (filename.EndsWith(".wtf"))
                {
                    WindowsTextFoundation.Core.WindowsTextFoundation wtf = WindowsTextFoundation.Core.WindowsTextFoundation.FromFile(filename);
                    cscode += @"namespace WTFCSharp
{
public class WTFCSharp
{
public WTFCSharp()" + "\r\n{\r\n" +
                        wtf.Objects[0].ToCSharp() +
@"frm.ShowDialog();" +  //FIXME
@"}
}
}";
                }
                else 
                {
                    sources.Add(System.IO.File.ReadAllText(filename));
                }
            }
            sources.Add(cscode);
            Console.WriteLine(cscode);
            Microsoft.CSharp.CSharpCodeProvider csc = new Microsoft.CSharp.CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Drawing.dll");
            cp.GenerateExecutable = true;
            cp.OutputAssembly = "wtfcs.exe";
            cp.MainClass = "WTFCSharpTest.a"; //FIXME
            CompilerResults r = csc.CompileAssemblyFromSource(cp,sources.ToArray());
            if (r.Errors.Count != 0)
            {
                foreach (CompilerError err in r.Errors)
                {
                    Console.WriteLine(err.ToString());
                }
            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}