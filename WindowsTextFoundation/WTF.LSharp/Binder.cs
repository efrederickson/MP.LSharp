using System;
using System.Collections;
using System.Reflection;
using System.Globalization;

namespace WindowsTextFoundation.LSharpProvider.NewCompiler
{

    sealed class Binder : System.Reflection.Binder
    {
    public override MethodBase BindToMethod(BindingFlags bindingAttr, MethodBase[] match, ref object[] args, 
      ParameterModifier[] modifiers, CultureInfo culture, string[] names, out object state)
    {
      state = null;
      return null;
    }

    public override FieldInfo BindToField(BindingFlags bindingAttr, FieldInfo[] match, object value, 
      CultureInfo culture)
    {
      return null;
    }

    public override object ChangeType(object value, Type type, CultureInfo culture)
    {
      return null;
    }

    public override void ReorderArgumentArray(ref object[] args, object state)
    {
      //Console.WriteLine(args);
    }

    public override MethodBase SelectMethod(BindingFlags bindingAttr, MethodBase[] match, 
      Type[] types, ParameterModifier[] modifiers)
    {
      if (match.Length == 0)
      {
        return null;
      }
      return match[0];
    }

    public override PropertyInfo SelectProperty(BindingFlags bindingAttr, PropertyInfo[] match, 
      Type returnType, Type[] indexes, ParameterModifier[] modifiers)
    {
      if (match.Length == 0)
      {
        return null;
      }
      return match[0];
    }
    }
}
