/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 11/10/2011
 * Time: 3:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;

namespace WindowsTextFoundation.LSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            try {
                // load args[0] as a L# script, others as WTF files
                string lscode = System.IO.File.ReadAllText(args[0]);
                args[0] = "";
                Compiler.Compile(lscode, "wtf.exe", Compiler.OutputType.Exe, args);
                Console.WriteLine("Compiled!");
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}