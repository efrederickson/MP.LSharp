/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 11/30/2011
 * Time: 10:49 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LSharp.Studio.WTFPlugin
{
    /// <summary>
    /// Description of File.
    /// </summary>
    public class File
    {
        private string path;
        public string Path
        {
            get{return path;}
            set{path = value;}
        }
        
        private string node;
        public string NodePath
        {
            get {return node;}
            set { node = value;}
        }
        public File(string paTH, string nodePath)
        {
            Path = paTH;
            NodePath = nodePath;
        }
    }
}
