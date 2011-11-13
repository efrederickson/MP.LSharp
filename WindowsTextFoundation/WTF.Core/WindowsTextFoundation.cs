/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 11/10/2011
 * Time: 1:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsTextFoundation.Core
{
    /// <summary>
    /// Wrapper for a WTF File
    /// </summary>
    public class WindowsTextFoundation
    {
        public List<AST.WTFObject> Objects = new List<AST.WTFObject>();
        
        /// <summary>
        /// Creates an empty WTF Document
        /// </summary>
        public WindowsTextFoundation()
        {
        }
        
        /// <summary>
        /// Constructor with begin WTF Code to parse
        /// </summary>
        /// <param name="WTFString"></param>
        public WindowsTextFoundation(string WTFString)
        {
            Parse(WTFString);
        }
        
        public static WindowsTextFoundation FromFile(string filename)
        {
            return new WindowsTextFoundation(System.IO.File.ReadAllText(filename));
        }
        
        public static WindowsTextFoundation FromStream(Stream stream)
        {
            string sVal = "";
            for (int i = 0; i < stream.Length; i++)
            {
                byte[] buffer = new byte[2];
                stream.Read(buffer, i, 1);
                sVal += (char) buffer[0];
            }
            return new WindowsTextFoundation(sVal);
        }
        
        public void Parse(string WTFString)
        {
            StringReader sr = new StringReader(WTFString);
            while (sr.Peek() != -1)
            {
                // set up vars
                AST.WTFObject o;
                string name="";
                string type="";
                List<string> constructorargs = new List<string>();
                
                // parse line
                string line = sr.ReadLine();
                if (line.StartsWith("--"))
                    continue; // its a comment
                else if (line.ToUpper().StartsWith("BEGIN "))
                {
                    line = line.Substring("BEGIN ".Length).Trim();
                    while ((line.Substring(0, 1) != " "))
                    {
                        type += line.Substring(0, 1);
                        line = line.Substring(1);
                    }
                    line = line.Substring(line.IndexOf(" ")).Trim();
                    if (line.Contains(" "))
                    {
                        name = line.Substring(line.IndexOf(" ")).Trim();
                        line = line.Substring(line.IndexOf(" ")).Trim();
                    }
                    else
                    {
                        name = line.Trim();
                        line = "";
                    }
                    foreach (string arg in line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                        constructorargs.Add(arg);
                    // create WTF Object
                    o = new AST.WTFObject(name, type, constructorargs);

                    // parse properties
                    line = sr.ReadLine();
                    while (line.ToUpper() != "ENDOBJECT")
                    {
                        // parse line into <Property Name> = <Value>;
                        line = line.Trim();
                        string[] line2 = line.Split(new string[] { "=" },
                                                    StringSplitOptions.None);
                        o.properties.Add(new AST.WTFProperty(line2[0].Trim(), line2[1].Trim()));

                        // read a line
                        line = sr.ReadLine();
                    }
                    // add it to the collection of parsed objects
                    Objects.Add(o);
                }
            }
        }
    }
}
