/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 11/10/2011
 * Time: 1:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsTextFoundation.Core.AST
{
    /// <summary>
    /// Basic object
    /// </summary>
    public class WTFObject
    {
        public List<WTFProperty> properties = new List<WTFProperty>();
        
        public List<WTFProperty> Properties {
            get { return properties; }
            set { properties = value; }
        }
        public string Name;
        public string Type;
        public List<string> ConstructorArgs;
        
        public WTFObject(string name, string type, List<string> constructorArgs)
        {
            this.Name = name;
            this.Type = type;
            this.ConstructorArgs = constructorArgs;
        }
        
        public string ToCSharp()
        {
            // StringBuilder for Memory management
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} {1} = new {0}(", this.Type.Trim(), this.Name.Trim()));
            for(int i = 0; i < this.ConstructorArgs.Count; ++i)
            {
                string arg = this.ConstructorArgs[i];
                sb.Append(arg);
                if (i == this.ConstructorArgs.Count - 1)
                { }
                else
                    sb.Append(", ");
            }
            sb.AppendLine(");");
            foreach (WTFProperty p in this.properties)
            {
                sb.AppendLine(this.Name + "." + p.Name + " = " + CreateCSharpConstructor(p.Value) + ";");
            }
            return sb.ToString();
        }
        
        public string ToVB()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Dim {1} As New {0}(", this.Type.Trim(), this.Name.Trim()));
            if (this.ConstructorArgs.Count != 0)
            {
                for(int i = 0; i < this.ConstructorArgs.Count; i++)
                {
                    string arg = this.ConstructorArgs[i];
                    sb.Append(arg);
                    if (i == this.ConstructorArgs.Count - 1)
                    { }
                    else
                        sb.Append(", ");
                }
            }
            sb.AppendLine(")");
            foreach (WTFProperty p in this.properties)
            {
                sb.AppendLine(this.Name + "." + p.Name + " = " + CreateVBConstructor(p.Value) + "");
            }
            return sb.ToString();
        }
        
        public string ToLSharp()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("(= {1} (new {0} ", this.Type, this.Name));
            if (this.ConstructorArgs.Count == 0)
                sb.Append("\b");
            for(int i = 0; i < this.ConstructorArgs.Count; ++i)
            {
                string arg = this.ConstructorArgs[i];
                sb.Append(arg);
                if (i == this.ConstructorArgs.Count)
                    break;
                else
                    sb.Append(" ");
            }
            sb.AppendLine("))");
            foreach (WTFProperty p in this.properties)
            {
                sb.AppendLine("(set_" + p.Name + " " + this.Name + " " + CreateLSharpConstructor(p.Value) + ")");
            }
            // This is not an excessive change. It is actually a character
            // that VS and SD do not display. Open in notepad if you dont believe me.
            return sb.ToString().Replace("", ""); ;
        }
        
        private string CreateCSharpConstructor(string wtfobj)
        {
            int tmpInt;
            double tmpDouble;
            if (int.TryParse(wtfobj, out tmpInt))
                return wtfobj; // int
            else if (double.TryParse(wtfobj, out tmpDouble))
                return wtfobj; //double/decimal
            else if (wtfobj.StartsWith("\""))
                return wtfobj; //string
            else if (wtfobj.Contains(".") || wtfobj.Contains("("))
            {
                // its a .Net object
                return "new " + wtfobj;
            }
            return wtfobj;
        }
        
        private string CreateVBConstructor(string wtfobj)
        {
            int tmpInt;
            double tmpDouble;
            if (int.TryParse(wtfobj, out tmpInt))
                return wtfobj; // int
            else if (double.TryParse(wtfobj, out tmpDouble))
                return wtfobj; //double/decimal
            else if (wtfobj.StartsWith("\""))
                return wtfobj; //string
            else if (wtfobj.Contains(".") || wtfobj.Contains("("))
            {
                // its a .Net object
                return "New " + wtfobj;
            }
            return wtfobj;
        }
        
        private string CreateLSharpConstructor(string wtfobj)
        {
            // more complicated for L#
            int tmpInt;
            double tmpDouble;
            if (int.TryParse(wtfobj, out tmpInt))
                return wtfobj; // int
            else if (double.TryParse(wtfobj, out tmpDouble))
                return wtfobj; //double/decimal
            else if (wtfobj.StartsWith("\""))
                return wtfobj; //string
            else if (wtfobj.Contains(".") || wtfobj.Contains("("))
            {
                // its a .NET constructor
                string returnval =  "(new ";
                int parenI = wtfobj.IndexOf("(");
                int lastParenI = wtfobj.LastIndexOf(")");
                returnval += wtfobj.Substring(0, parenI).Trim() + " ";
                string constructorString = wtfobj.Substring(parenI + 1, lastParenI - parenI - 1).Trim();
                returnval += constructorString.Replace(", ", " ");
                returnval += ")";
                return returnval; // format: (new obj args)
            }
            // unknown type, probably safe to do this.
            return wtfobj;
        }
    }
    
    /// <summary>
    /// Property object for WTFObject
    /// </summary>
    public class WTFProperty
    {
        public string Name;
        public string Value;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value">Format: "new System.Drawing.Point(x, y)", 11, "string"</param>
        public WTFProperty(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
