#region Copyright (C) 2006 Llewellyn Pritchard
//
// L Sharp .NET Compiler extension
// Copyright (C) 2006 Llewellyn Pritchard
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Library General Public
// License as published by the Free Software Foundation; either
// version 2 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Library General Public License for more details.
// 
// You should have received a copy of the GNU Library General Public
// License along with this library; if not, write to the Free
// Software Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
//
#endregion

using LSharp;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.IO;
using System;

namespace WindowsTextFoundation.LSharpProvider.NewCompiler
{
    enum Target
    {
        Exe,
        Dll
    }

    sealed class Compiler
    {
        static readonly string[] AssemblyNames = { "mscorlib.dll", 
                                                 typeof(Runtime).Assembly.Location, 
                                                 "System.dll", 
                                                 "System.Core.dll", 
                                                 "System.Windows.Forms.dll"
                                                 };
        static readonly CodeDomProvider comp = new Microsoft.CSharp.CSharpCodeProvider();
        static readonly Hashtable currsymbols = new Hashtable();
        static string extracode;
        static readonly Binder binder = new Binder();
        static readonly CompilerParameters copts = new CompilerParameters(AssemblyNames);

        static Compiler()
        {
            copts.CompilerOptions = "/o+";
            copts.IncludeDebugInformation = true;
        }

        public static CompilerResults CompileExe(string infile, LSharp.Environment environment)
        {
            currsymbols.Clear();
            extracode = string.Empty;
            LSharp.Environment localEnvironment = new LSharp.Environment(environment);

            using (TextReader r = File.OpenText(infile))
            {
                string src = "(do " + r.ReadToEnd() + ")";
                object fc = Reader.Read(new StringReader(src), ReadTable.DefaultReadTable()); // reads string into parsed data
                try
                {
                    Runtime.Eval(fc, environment); // so that .NET calls work... fix this
                }
                catch (Exception)
                {
                    // quietly ignore.
                }
                
                string gc = Compiler.Generate(fc, localEnvironment);

                string code = @"
using System;

sealed class generated
{
  [STAThread]
  static int Main(string[] cmdargs)
  {
    LSharp.Environment environment = new LSharp.Environment();
    object retval = null;
";
                code += gc;

                code += @"
    if (retval is int)
    {
      return (int) retval;
    }
    return 0;
  }
";
                code += extracode;
                code += @"
}";
                CompilerResults cr=null;
                if (false) //(args.processonly)
                {
                    string outfile = Path.ChangeExtension(infile, ".cs");

                    using (TextWriter w = File.CreateText(outfile))
                    {
                        w.WriteLine(code);
                        return null;
                    }
                }
                else
                {
                    if (false) //(args.optimize)
                    {
                        copts.CompilerOptions = "/o+";
                    }
                    else
                    {
                        copts.CompilerOptions = "/o-";
                    }

                    copts.IncludeDebugInformation = true;  //args.debug;
                    copts.GenerateExecutable = true; //args.target == Target.Exe;

                    copts.GenerateExecutable = true;
                    string name = Path.ChangeExtension(infile, copts.GenerateExecutable ? ".exe" : ".dll");
                    Console.WriteLine(code); // to see the code created
                    File.WriteAllText(Path.ChangeExtension(infile, ".cs"), code); // write to a *.cs file
                    copts.OutputAssembly = name;
                    cr = comp.CompileAssemblyFromSource(copts, code);

                    if (cr.NativeCompilerReturnValue == 0)
                    {
                        return cr;
                    }
                    else
                    {
                        foreach (CompilerError err in cr.Errors)
                        {
                            Console.Error.WriteLine("Compiler error: {0}", err.ToString());
                        }
                    }
                    //}
                }
                return cr;
            }
        }
    
    /// <summary>
    /// (compile symbols*)
    /// </summary>
        public static CompilerResults CompileDll(Cons args, LSharp.Environment environment)
    {
        currsymbols.Clear();
        extracode = string.Empty;
        LSharp.Environment localEnvironment = new LSharp.Environment(environment);

        string name = MakeUnique("gen");
        while (File.Exists(name + ".dll"))
        {
            name = MakeUnique("gen");
        }
        string gc = Closure(args, localEnvironment) as string;
        if (gc.Length == 0)
        {
            return null;
        }

        string code = string.Format(@"
public sealed class {0}
{{
", name);
        code += gc;
        code += extracode;
        code += "\n}";
        
        copts.GenerateExecutable = false;
        copts.OutputAssembly = name + ".dll";
        
        CompilerResults cr = comp.CompileAssemblyFromSource(copts, code);

        if (cr.NativeCompilerReturnValue == 0)
        {
            //Assembly genass = cr.CompiledAssembly;
            //return Runtime.Import(genass.Location, environment);
        }
        else
        {
            foreach (CompilerError err in cr.Errors)
            {
                Console.Error.WriteLine("Compiler error: {0}", err);
            }
            return cr;
        }
        return cr;
    }

        public static string Generate(object obj, LSharp.Environment environment)
    {
        if (obj is Cons)
        {
            return GenerateCons(obj as Cons, environment);
        }
        string s = "// " + Printer.WriteToString(obj) + NewLine;
        if (obj is Symbol)
        {
            if (environment.Contains(obj as Symbol))
            {
                string symn = environment.GetValue(obj as Symbol) as string;
                return s + "retval = " + symn + ";" +  NewLine;
            }
            else
            {
                return s + "retval = " + obj + ";" +  NewLine;
            }
        }
        else
        {
            return s + "retval = "  + Printer.WriteToString(obj) + ";" + NewLine;
        }
    }

        public static string GenerateList(Cons rest, LSharp.Environment environment, string margs)
    {
        string v = string.Format(@"System.Collections.ArrayList {0} = new System.Collections.ArrayList({1});
", margs, rest.Length());
        // load args
        foreach (object argo in rest)
        {
            if (argo is Symbol)
            {
                Symbol sarg = (Symbol)argo;

                if (environment.Contains(sarg))
                {
                    v += string.Format(@"{1}.Add({0});
", environment.GetValue(sarg), margs);
                }
                else
                {
                    v += Generate(argo, environment);
                    v += margs + @".Add(retval);
";
                }
            }
            else if (argo is Cons)
            {
                v += Generate(argo, environment);
                v += margs + @".Add(retval);
";
            }
            else
            {
                // load primitive
                v += string.Format(@"{1}.Add({0});
", Printer.WriteToString(argo), margs);
            }
        }
        return v;
    }

        public static string GenerateFuncCall(string type, string method, Cons rest, LSharp.Environment environment)
    {
        string v = string.Empty;
        string typemeth = method;
        if (type != null)
        {
            typemeth = type + "." + method;
        }

        if (rest == null)
        {
            return v + "retval = " + typemeth
                + string.Format(@"(null, environment);
");
        }
        else
        {
            if (rest.Length() == 1)
            {
                object argo = rest.First();
                string argn = "retval";
                if (argo is Symbol)
                {
                    Symbol sarg = (Symbol)argo;

                    if (environment.Contains(sarg))
                    {
                        argn = environment.GetValue(sarg) as string;
                    }
                    else
                    {
                        v += Generate(argo, environment);
                    }
                }
                else if (argo is Cons)
                {
                    v += Generate(argo, environment);
                }
                else
                {
                    // load primitive
                    argn = Printer.WriteToString(argo);
                }

                return v + "retval = " + typemeth
                    + string.Format(@"(new LSharp.Cons({0}), environment);
", argn);
                
            }
            else
            {
                string margs = GetArgs();
                v += GenerateList(rest, environment, margs);

                return v + "retval = " + typemeth
                    + string.Format(@"(LSharp.Cons.FromList({0}), environment);
", margs);
            }
        }
    }

        public static string GenerateCons(Cons args, LSharp.Environment environment)
    {
        // ananlysi cons
        if (args == null)
        {
            return @"//retval = null; // dont null mite need retval
";
        }
        else
        {
            Symbol sym = args.Car() as Symbol;

            object e = Runtime.Eval(sym, environment);

            if (e is Function)
            {
                Function f = e as Function;
                
                string v = "{" + NewLine;
                Cons rest = args.Rest() as Cons;
                v += GenerateFuncCall(f.Method.DeclaringType.ToString(), f.Method.Name, rest, environment);
                return v + "}" + NewLine;
            }

            else if (e is SpecialForm)
            {
                SpecialForm f = e as SpecialForm;

                Cons rest = args.Rest() as Cons;

                string r = Printer.ConsToString(rest);
                string lFName = f.Method.Name.ToLower();
                if (lFName == "while")
                    return While(rest, environment) as string;
                if (lFName == "for")
                    return For(rest, environment) as string;
                if (lFName == "and")
                    return And(rest, environment) as string;
                if (lFName == "call")
                    return Call(rest, environment) as string;
                if (lFName == "cond")
                    return Cond(rest, environment) as string;
                if (lFName == "do")
                    return Do(rest, environment) as string;
                if (lFName == "foreach")
                    return ForEach(rest, environment) as string;
                if (lFName == "if")
                    return If(rest, environment) as string;
                if (lFName == "let")
                    return Let(rest, environment) as string;
                if (lFName == "or")
                    return Or(rest, environment) as string;
                if (lFName == "quote")
                    return Quote(rest, environment) as string;
                if (lFName == "setq")
                    return Setq(rest, environment) as string;
                if (lFName == "the")
                    return The(rest, environment) as string;
                if (lFName == "to")
                    return To(rest, environment) as string;
                if (lFName == "try")
                    return Try(rest, environment) as string;
                if (lFName == "when")
                    return When(rest, environment) as string;
                if (lFName == "with")
                    return With(rest, environment) as string;
                
                return Runtime.EvalString("(" + f.Method.Name + " " + r + ")", environment) as string;
            }

            else if (e is Macro)
            {
                Macro m = e as Macro;
                Cons rest = args.Rest() as Cons;
                Cons em = m.Expand(rest) as Cons;

                return Generate(em, environment);
            }
            else if (e is Closure)
            {
                extracode += Closure(new Cons(sym), environment) as string;
                
                string v = "{" + NewLine;
                Cons rest = args.Rest() as Cons;
                v += GenerateFuncCall(null, environment.GetValue(sym) as string, rest, environment);
                return v + "}" + NewLine;
                
            }
            else if (currsymbols.ContainsKey(sym))
            {
                string v = "{" + NewLine;
                Cons rest = args.Rest() as Cons;
                v += GenerateFuncCall(null, environment.GetValue(sym) as string, rest, environment);
                return v + "}" + NewLine;
            }
            else
            {
                // not good, lets not support this for now: .NET method call
                try
                {
                    // try: LSharp.Runtime.Appy(<args>);
                    Cons rest = args.Rest() as Cons;
                    string ret = GenerateList(rest, environment, "temporarytableforspecialfunctioncall");
                    ret += "\nLSharp.Runtime.Apply(retval, LSharp.Cons.FromList(temporarytableforspecialfunctioncall), environment);";
                    //return ret; //"// call not supported";// Call(args, environment).ToString();
                    return Call(args, environment) as string;
                }
                catch
                {
                    string margs = GetArgs();
                    string v = GenerateList(args.Rest() as Cons, environment, margs);
                    return string.Format("retval = LSharp.Cons.FromList({0});{1}",
                                         margs, NewLine);
                }
            }
        }
    }

        public static string GenerateAssign(Symbol s, object value, LSharp.Environment environment)
    {
        if (environment.Contains(s))
        {
            object sn = environment.GetValue(s);
            return string.Format(@"{1}
{0} = retval;",
                                 sn, value) + NewLine;
        }
        else
        {
            environment.Assign(s, s.Name);
            return string.Format(@"{1}
object {0} = retval;",
                                 s.Name, value) + NewLine;
        }
    }

    static int uniquectr = 0;

    static string MakeUnique(string input)
    {
        return string.Format("{0}{1}", input, uniquectr++);
    }

    public static string GenerateAssignLocal(Symbol s, object value, LSharp.Environment environment)
    {
        if (environment.Contains(s))
        {
            string ns = MakeUnique(s.Name);

            environment.AssignLocal(s, ns);

            if (value is string)
            {
                return string.Format(@"{1}
object {0} = retval;", ns, value) + NewLine;
            }
            else
            {
                return string.Format(@"{2} {0} = {1};",
                                     ns, value, value.GetType()) + NewLine;
            }
        }
        else
        {
            environment.AssignLocal(s, s.Name);

            if (value is string)
            {
                return string.Format(@"{1}
object {0} = retval;", s.Name, value) + NewLine;
            }
            else
            {
                return string.Format(@"{2} {0} = {1};", s.Name, value, value.GetType()) + NewLine;
            }
        }
    }
    
    static string NewLine = System.Environment.NewLine;

    static string MakeCompat(string input)
    {
        string o = string.Empty;
        foreach (char c in input)
        {
            if (char.IsLetterOrDigit(c) || c == '_')
            {
                o += c.ToString();
            }
            else
            {
                o += "_";
            }
        }
        return o;
    }

    //TODO: args processing
    public static Object Closure(Cons symbols, LSharp.Environment environment)
    {
        string v = string.Empty;

        Symbol s = symbols.First() as Symbol;
        if (s != null)
        {
            string name = s.Name;
            string cname = MakeCompat(name);
            
            Closure c = Runtime.Eval(s, environment) as Closure;
            
            if (c == null)
            {
                return NewLine;
            }

            v += string.Format(@"
[LSharp.Symbol(""{0}"")]
public static object {1}(LSharp.Cons args, LSharp.Environment environment)
{{
object retval = null;
", name, cname);
            
            
            currsymbols.Add(s, c);
            //after eval
            environment.AssignLocal(s, cname);

            Cons argnames = c.GetArgumentNames();
            Cons body = c.GetBody();
            
            if (argnames != null)
            {
                int i = 0;
                int al = argnames.Length();

                foreach (Symbol arg in argnames)
                {
                    environment.AssignLocal(arg, MakeCompat(arg.Name));

                    v += string.Format("object {0} = args.Car();\n", environment.GetValue(arg));

                    if (++i < al)
                    {
                        v += "args = (LSharp.Cons)args.Cdr();\n";
                    }
                }
            }

            // BODY
            if (body != null)
            {
                foreach (object con in body)
                {
                    v += Generate(con, environment);
                }
            }

            // RETURN
            v += @"
return retval;
}
";

        }
        return v;
    }

    static int labelcnt = 0;

    static string GetLabel(string prefix)
    {
        return string.Format("{1}_{0:X4}", labelcnt++, prefix);
    }

    static int argcnt = 0;

    static string GetArgs()
    {
        return string.Format("args_{0:X4}", argcnt++);
    }

    /// <summary>
    /// (and expression*)
    /// </summary>
    public static object And(Cons args, LSharp.Environment environment)
    {
        string label = GetLabel("and");
        //string v = "//(and " + Printer.ConsToString(args) + ")" + NewLine;
        string v = string.Empty;
        foreach (Object item in args)
        {
            string sv = Generate(item,environment) + NewLine +
                string.Format(@"if (LSharp.Conversions.ObjectToBoolean(retval) == false)
{{
  retval = false;
  goto {0};
}}
", label);
            v += sv;
        }
        v +=
            string.Format(@"retval = true;
{0}:;
", label);
        return v;
    }

    /// <summary>
    /// (call method object argument*)
    /// </summary>
    public static Object Call(Cons args, LSharp.Environment environment)
    {
        string v = //"//(call " + Printer.ConsToString(args) + ")" + NewLine +
            "{" + NewLine;

        ArrayList argtypes = new ArrayList();
        ArrayList argz = new ArrayList();

        if (args.Length() > 2)
        {
            foreach (object arg in (args.Cddr() as Cons))
            {
                if (Primitives.IsAtom(arg))
                {
                    argz.Add(Printer.WriteToString(arg));
                }
                else
                {
                    string argn = MakeUnique("arg");
                    string sv = Generate(arg, environment);
                    sv += string.Format(@"{0} {1} = ({0}) retval;
", typeof(object) , argn);

                    argz.Add(argn);

                    v += sv;
                }
                argtypes.Add(typeof(object));
            }
        }

        string typemethname = args.Car().ToString();

        string methname = typemethname;
        string typename = string.Empty;
        Type type = typeof(object);

        int i = methname.LastIndexOf(".");
        
        if (i >= 0)
        {
            methname = methname.Substring(i + 1);
            typename = typemethname.Substring(0, i);
            type = TypeCache.FindType(typename);
        }
        MethodInfo mi = null;
        
        mi = type.GetMethod(methname, BindingFlags.IgnoreCase
                            | BindingFlags.Public | BindingFlags.Instance, binder, argtypes.ToArray(typeof(Type)) as Type[], null);

        string objn = string.Empty;

        if (mi == null)
        {
            type = TypeCache.FindType(args.Second().ToString());
            mi = type.GetMethod(methname, BindingFlags.IgnoreCase
                                | BindingFlags.Public | BindingFlags.Static, binder, argtypes.ToArray(typeof(Type)) as Type[], null);

            if (mi == null)
            {
                // use reflection
                v += Generate(args.Second(), environment);
                v += string.Format(@"retval = retval.GetType().InvokeMember(""{0}"",
BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, retval,
new object[]{{", methname) +
                    string.Join(", ", argz.ToArray(typeof(string)) as string[]) + @"});
}
";
                return v;
            }
            else
            {
                objn = type.ToString();
            }
        }
        else
        {
            objn = MakeUnique("obj");
            v += Generate(args.Second(), environment);
            v += string.Format(@"{0} {1} = ({0}) retval;
", type, objn);
        }

        v += "retval = " + (mi.ReturnType == typeof(void) ? @"null;
" : "") + objn + "." + mi.Name + "(" +
            string.Join(", ", argz.ToArray(typeof(string)) as string[]);
        
        return v + @");
}
";
    }

    /// <summary>
    /// (cond (test expression)* [default])
    /// </summary>
    public static Object Cond(Cons args, LSharp.Environment environment)
    {
        //string v = "//(cond " + Printer.ConsToString(args) + ")" + NewLine;
        string v = string.Empty;
        Cons clauses = args;
        string label = GetLabel("cond");

        while (clauses.Length() > 0)
        {
            if (clauses.Length() == 1)
            {
                // This is a default (else) clause, so just execute it
                string sv = Generate(clauses.First(),environment) + NewLine;
                v += sv;
                break;
            }

            if (clauses.Length() >= 2)
            {
                string sv = Generate(clauses.First(),environment) + NewLine +
                    string.Format(@"if (LSharp.Conversions.ObjectToBoolean(retval))
{{
  {0}
  goto {1};
}}
",  Generate(clauses.Second(),environment), label);

                v += sv;

                clauses = (Cons)clauses.Cddr();
            }
        }
        v += string.Format(@"{0}:;
", label);
        return v;
    }

    /// <summary>
    /// (do expression*)
    /// </summary>
    public static Object Do(Cons args, LSharp.Environment environment)
    {
        //string v = "//(do " + Printer.ConsToString(args) + ")" + NewLine;
        string v = string.Empty;
        if (args != null)
        {
            foreach (object item in args)
            {
                string sv = Generate(item, environment) + NewLine;
                v += sv;
            }
        }
        return v;
    }

    /// <summary>
    /// (for initialiser test iterator statement)
    /// </summary>
    public static Object For(Cons args, LSharp.Environment environment)
    {
        //string v = "//(for " + Printer.ConsToString(args) + ")" + NewLine + "{" + NewLine;
        string v = "{" + NewLine;
        LSharp.Environment localEnvironment = new LSharp.Environment(environment);
        v += Generate(args.First(),localEnvironment);
        v += Generate(args.Second(),localEnvironment);
        v += @"while ((Conversions.ObjectToBoolean(retval))
{
";
        foreach (object item in (Cons)args.Cdddr())
        {
            v += Generate(item, localEnvironment);
        }

        v += Generate(args.Third(),localEnvironment);

        v += Generate(args.Second(),localEnvironment);

        v += @"}
";
        return v + "}" + NewLine;
    }

    /// <summary>
    /// (each symbol IEnumerable expression)
    /// </summary>
    public static Object ForEach(Cons args, LSharp.Environment environment)
    {
        //string v = "//(each " + Printer.ConsToString(args) + ")" + NewLine;
        string v = "";
        LSharp.Environment localEnvironment = new LSharp.Environment(environment);
        Symbol variable = (Symbol) args.First();
        
        string vn = localEnvironment.AssignLocal(variable, MakeUnique(variable.Name)) as string;
        
        v += Generate(args.Second(),environment) +
            string.Format(@"
foreach (object {0} in (System.Collections.IEnumerable)retval)
{{", vn);
        
        foreach (object item in (Cons)args.Cddr())
        {
            v += Generate(item, localEnvironment);
        }

        v += "}" + NewLine;

        return v;
    }

    /// <summary>
    /// (if test then [else])
    /// </summary>
    public static Object If(Cons args, LSharp.Environment environment)
    {
        string v = //"//(if " + Printer.ConsToString(args) + ")" + NewLine +
            Generate(args.First(),environment) +
            string.Format(@"
if (LSharp.Conversions.ObjectToBoolean(retval))
{{  // Evaluate the then part
  {0}
}}
", Generate(args.Second(),environment));

        if (args.Length() > 2)
        {
            // Evaluate the optional else part
            v += string.Format(@"
else
{{
  {0}
}}
", Generate(args.Third(),environment));
        }

        return v;
    }

    /// <summary>
    /// (let symbol value expression*)
    /// </summary>
    public static Object Let(Cons args, LSharp.Environment environment)
    {
        string v = //"//(let " + Printer.ConsToString(args) + ")" + NewLine +
            "{"  + NewLine;
        LSharp.Environment localEnvironment = new LSharp.Environment(environment);
        v += GenerateAssignLocal((Symbol) args.First(), Generate(args.Second(),environment), localEnvironment);
        
        foreach (object item in (Cons)args.Cddr())
        {
            v += Generate(item, localEnvironment);
        }

        return v + "}" + NewLine;
    }

    /// <summary>
    /// (or expression*)
    /// </summary>
    public static Object Or(Cons args, LSharp.Environment environment)
    {
        string v = "";//"//(or " + Printer.ConsToString(args) + ")" + NewLine;
        string label = GetLabel("or");

        foreach (Object item in args)
        {
            v += Generate(item,environment);
            v += string.Format(@"
if (LSharp.Conversions.ObjectToBoolean(retval) == true)
{{
  retval = true;
  goto {0};
}}
", label);

        }
        v += string.Format(@"
retval = false;
{0}:;
", label);
        return v;
    }

    /// <summary>
    /// (quote object)
    /// </summary>
    public static Object Quote(Cons args, LSharp.Environment environment)
    {
        string v = "//(quote " + Printer.ConsToString(args) + ")" + NewLine;
        //string v = string.Empty;
        //reconstruct

        Cons c = args.First() as Cons;
        if (c != null)
        {
            string margs = GetArgs();
            v += GenerateList(c, environment, margs);
            v += string.Format("retval = LSharp.Cons.FromList({0});", margs);
        }
        Symbol s = args.First() as Symbol;
        if (s != null)
        {
            v += string.Format("retval = (LSharp.Symbol)\"{0}\";", s);
        }

        return v + NewLine;
    }

    /// <summary>
    /// (= { symbol value}*)
    /// </summary>
    public static Object Setq(Cons args, LSharp.Environment environment)
    {
        string v = "";//"//(setq " + Printer.ConsToString(args) + ")" + NewLine;

        while (args != null)
        {
            Symbol s = (Symbol)args.First();
            Cons sec = args.Second() as Cons;
            if (sec != null)
            {
                Symbol ss = sec.First() as Symbol;
                if (ss == Symbol.FromName("fn"))
                {
                    Closure c =  Runtime.Eval(sec, environment) as Closure;
                    environment.Assign(s, c);
                    extracode += Closure( new Cons(s), environment);
                    args = (Cons)args.Cddr();
                    continue;
                }
                if (ss == Symbol.FromName("macro"))
                {
                    Macro m =  Runtime.Eval(sec, environment) as Macro;
                    environment.Assign(s, m);
                    args = (Cons)args.Cddr();
                    continue;
                }
            }
            v += GenerateAssign(s,Generate(args.Second(),environment), environment);
            args = (Cons)args.Cddr();
        }

        return v;
    }

    /// <summary>
    /// (the type value)
    /// </summary>
    public static Object The(Cons args, LSharp.Environment environment)
    {
        string v = "";// "//(the " + Printer.ConsToString(args) + ")" + NewLine;
        Type o = TypeCache.FindType(args.First().ToString());
        v += Generate(args.Second(),environment);
        return v + string.Format("retval = LSharp.Conversions.The(typeof({0}), retval);", o) + NewLine;
    }

    /// <summary>
    /// (to variable limit expression)
    /// </summary>
    public static Object To(Cons args, LSharp.Environment environment)
    {
        string v = //"//(to " + Printer.ConsToString(args) + ")" + NewLine +
            "{" + NewLine;
        LSharp.Environment localEnvironment = new LSharp.Environment(environment);

        v += GenerateAssignLocal(args.First() as Symbol, 0, localEnvironment);
        v += Generate(args.Second(),environment);
        string lbl = MakeUnique("endstop");
        v += string.Format(@"
int {1} = (int)retval;
while ({0} < {1})
{{
", localEnvironment.GetValue(args.First() as Symbol), lbl);

        foreach (object item in (Cons)args.Cddr())
        {
            v += Generate(item, localEnvironment);
        }

        v += localEnvironment.GetValue(args.First() as Symbol) + "++;";
        
        v += "}" + NewLine;
        v += string.Format(@"
retval = null;
");
        return v + "}" + NewLine;
    }

    /// <summary>
    /// (try expression catch [finally])
    /// </summary>
    public static Object Try(Cons args, LSharp.Environment environment)
    {
        string v = "";//"//(try " + Printer.ConsToString(args) + ")" + NewLine +
        string.Format(@"
try
{{
  {0}
}}
catch (Exception e)
{{
  {1}
}}", Generate(args.First(), environment) ,(args.Second() as Symbol == Symbol.NULL) ?
                      "throw" :
                      Generate(args.Second(),environment));
        if  (args.Length() > 2)
        {
            v += string.Format(@"
finally
{{
  {0}
}}
", Generate(args.Third(),environment));
        }
        return v;
    }
    
    /// <summary>
    /// (when test expression*)
    /// </summary>
    public static Object When(Cons args, LSharp.Environment environment)
    {
        string v = //"//(when " + Printer.ConsToString(args) + ")" + NewLine +
            Generate(args.First(),environment) +
            string.Format(@"
if (LSharp.Conversions.ObjectToBoolean(retval))
{{  // Evaluate the then part
  {0}
}}
", Generate(args.Second(),environment));
        return v;
    }

    /// <summary>
    /// (while test expression*)
    /// </summary>
    public static Object While(Cons args, LSharp.Environment environment)
    {
        string v = "";//"//(while " + Printer.ConsToString(args) + ")" + NewLine;
        v += Generate(args.First(),environment);
        v += @"
while (LSharp.Conversions.ObjectToBoolean(retval))
{
";
        foreach (object item in (Cons)args.Rest())
        {
            v += Generate(item, environment);
        }

        v += Generate(args.First(),environment);

        v += "}" + NewLine;
        return v;
    }

    /// <summary>
    /// (with ((symbol value)* ) expression*)
    /// </summary>
    public static Object With(Cons args, LSharp.Environment environment)
    {
        string v = //"//(with " + Printer.ConsToString(args) + ")" + NewLine +
            "{"  + NewLine;
        Cons bindings = (Cons)args.First();
        LSharp.Environment localEnvironment = new LSharp.Environment(environment);

        while ((bindings != null) && (bindings.Length() > 1))
        {
            v += GenerateAssignLocal((Symbol) bindings.First(), Generate(bindings.Second(),environment), localEnvironment);
            bindings = (Cons)bindings.Cddr();
        }
        
        foreach (object item in (Cons)args.Cdr())
        {
            v += Generate(item, localEnvironment);
        }
        return v + "}";
    }
}
}
