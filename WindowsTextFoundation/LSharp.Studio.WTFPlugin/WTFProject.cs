using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.CodeDom.Compiler;
namespace LSharp.Studio.WTFPlugin
{
    public class WTFProject
    {
        public string XmlFilename = "";
        public List<string> Files = new List<string>();
        public string OutputFileName="";
        public WindowsTextFoundation.LSharpProvider.Compiler.OutputType CompileOutputType = WindowsTextFoundation.LSharpProvider.Compiler.OutputType.Exe;

        public void Load(string filename)
        {
            Files.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            foreach (XmlNode n in doc.SelectNodes("/project/files/file"))
                Files.Add(n.InnerText);
            OutputFileName = doc.SelectSingleNode("/project/outfile").InnerText;
            CompileOutputType =(WindowsTextFoundation.LSharpProvider.Compiler.OutputType) Enum.Parse(typeof(WindowsTextFoundation.LSharpProvider.Compiler.OutputType), doc.SelectSingleNode("/project/outputtype").InnerText);
        }

        public void Save(string filename)
        {
            XmlWriterSettings s = new XmlWriterSettings();
            s.CheckCharacters = true;
            s.Indent = true;
            s.IndentChars = "    ";
            XmlWriter writer = XmlWriter.Create(filename, s);
            writer.WriteStartElement("project");
            /******* FILES ********/
            writer.WriteStartElement("files");
            foreach (string filename2 in Files)
            {
                writer.WriteElementString("file", filename2);
            }
            writer.WriteEndElement();
            /******* END FILES ******/
            writer.WriteElementString("outfile", OutputFileName);
            writer.WriteElementString("outputtype", CompileOutputType.ToString());
            writer.WriteEndElement();
        }

        public CompilerResults Build()
        {
            return WindowsTextFoundation.LSharpProvider.Compiler.Compile(GetLSharpSources(), OutputFileName, WindowsTextFoundation.LSharpProvider.Compiler.OutputType.Exe, GetWTFFileNames());
        }

        public string GetLSharpSources()
        {
            string ret = "";
            foreach (string fn in Files)
            {
                if (fn.ToLower().EndsWith(".ls"))
                    ret += System.IO.File.ReadAllText(fn);
            }
            return ret;
        }

        public string[] GetWTFFileNames()
        {
            List<string> wtfFiles = new List<string>();
            foreach (string fn in Files)
            {
                if (fn.ToLower().EndsWith(".wtf"))
                    wtfFiles.Add(fn);
            }
            return wtfFiles.ToArray();
        }
    }
}
