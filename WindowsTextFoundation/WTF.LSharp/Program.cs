/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 11/10/2011
 * Time: 3:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.CodeDom.Compiler;

namespace WindowsTextFoundation.LSharpProvider
{
    class Program
    {
        public static void Main(string[] args)
        {
            string lscode ="";
            try {
                List<string> WTFFiles = new List<string>();
                // Parse by filetype: *.WTF, *.LS
                // others shall be ignored and written to screen.
                for (int i = 0; i < args.Length; i++)
                {
                    string lFilename = args[i].ToLower();
                    if (lFilename.EndsWith(".wtf"))
                    {
                        // add to WTF file list
                        WTFFiles.Add(args[i]);
                    }
                    else if (lFilename.EndsWith(".ls"))
                    {
                        // add LS file contents to L# code variable
                        lscode += System.IO.File.ReadAllText(args[i]);
                    }
                    else
                    {
                        //TODO: attempt to parse as compiler argument
                        // currently just write it to the screen and notify user
                        Console.WriteLine("Unknown filetype/file: " + args[i]);
                    }
                }
                args[0] = "";
                CompilerResults r = Compiler.Compile(lscode, "sample.exe", Compiler.OutputType.Exe, WTFFiles.ToArray());
                foreach (CompilerError rr in r.Errors)
                {
                    Console.WriteLine(rr.ToString());
                }
                /*using (StreamWriter s = new StreamWriter("lscode.ls"))
                {
                    foreach (string wtffile in WTFFiles)
                    {
                        WindowsTextFoundation.Core.WindowsTextFoundation wtf = new Core.WindowsTextFoundation(System.IO.File.ReadAllText(wtffile));
                        foreach (Core.AST.WTFObject o in wtf.Objects)
                            s.WriteLine(o.ToLSharp());
                    }
                    s.WriteLine(lscode);
                }
                NewCompiler.Compiler.CompileExe("lscode.ls", new LSharp.Environment());*/
                Console.WriteLine("Compiled!");
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}