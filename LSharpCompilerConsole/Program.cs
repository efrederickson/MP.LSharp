/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/8/2011
 * Time: 9:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;

namespace LSharp.LSC
{
	public class Compiler
	{
		public static int Main(string[] args)
		{
			Console.WriteLine("L# Compiler version 1.0");
			Console.WriteLine();
			if (args.Length == 0)
			{
				Console.WriteLine("Usage: lsc <options> <filenames>");
				Console.WriteLine("Options: -out:<winexe|exe|dll>");
				return 1;
			}
			LSharp.Compiler.OutputType ot = LSharp.Compiler.OutputType.Exe;
			Console.Write("Compiling ");
			List<string> newArgs1 = new List<string>();
			foreach (string arg in args)
			{
				if (arg.StartsWith("-out:"))
				{
					if (arg.ToLower().EndsWith("winexe"))
					{
						ot = LSharp.Compiler.OutputType.WinFormsExe;
					}
					else if (arg.ToLower().EndsWith("dll"))
					{
						ot = LSharp.Compiler.OutputType.Dll;
					}
					else
					{
						ot = LSharp.Compiler.OutputType.Exe;
					}
				}
				else {
				    Console.Write(arg + " ");
				    if (System.IO.File.Exists(arg))
				        newArgs1.Add(arg);
				    else
				    {
				        if (System.IO.File.Exists(arg + ".ls"))
				            newArgs1.Add(arg + ".ls");
				    }
				}
			}
			Console.WriteLine("...");
			string[] newArgs = new string[newArgs1.Count];
			newArgs1.TrimExcess();
			newArgs1.CopyTo(newArgs);
			CompilerResults r = LSharp.Compiler.Compile(newArgs, ot);
			if (r == null) 
			{
				Console.WriteLine("Failed to Compile: Unspecified error!");
				return 1;
			}
			if (r.Errors.Count > 0)
			{
				foreach (CompilerError err in r.Errors)
					Console.WriteLine(err.ToString());
				return 1;
			}
			else
			{
				Console.WriteLine("Compiled to " + System.IO.Path.GetFileNameWithoutExtension(newArgs[0]) + (ot == LSharp.Compiler.OutputType.Dll ? ".dll" : ".exe"));
				//Process.Start(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(args[0]), System.IO.Path.GetFileNameWithoutExtension(args[0]) + ".exe"));
				return 0;
			}
		}
	}
}