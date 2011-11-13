
using System;

sealed class generated
{
  [STAThread]
  static int Main(string[] cmdargs)
  {
    LSharp.Environment environment = new LSharp.Environment();
    object retval = null;
{
// system.windows.forms.form
retval = system.windows.forms.form;
retval = LSharp.Functions.New(new LSharp.Cons(retval), environment);
}

System.Windows.Forms.Form, Text:  = retval;

retval = LSharp.Cons.FromList(args_0002);

retval = LSharp.Cons.FromList(args_0004);

retval = LSharp.Cons.FromList(args_0005);

retval = LSharp.Cons.FromList(args_0006);

{
retval = LSharp.Functions.Prl(new LSharp.Cons("WTF Tester from L#!"), environment);
}


    if (retval is int)
    {
      return (int) retval;
    }
    return 0;
  }

}