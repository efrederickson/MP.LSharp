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
        public string XmlFilename
        {get; set; }
        public string ProjectName
        {get; set; }
        private List<File> files = new List<File>();
        public List<File> Files
        {
            get
            {
                return files;
            }
            set
            {
                files = value;
            }
        }
        public string OutputFileName
        {get; set; }
        public WindowsTextFoundation.LSharpProvider.Compiler.OutputType CompileOutputType = WindowsTextFoundation.LSharpProvider.Compiler.OutputType.Exe;

        public void Load(string filename)
        {
            Files.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            ProjectName = doc.SelectSingleNode("/project/projectname").InnerText;
            foreach (XmlNode n in doc.SelectNodes("/project/files/file"))
                Files.Add(new File(n.InnerText));
            OutputFileName = doc.SelectSingleNode("/project/outfile").InnerText;
            CompileOutputType =(WindowsTextFoundation.LSharpProvider.Compiler.OutputType) Enum.Parse(typeof(WindowsTextFoundation.LSharpProvider.Compiler.OutputType), doc.SelectSingleNode("/project/outputtype").InnerText);
            XmlFilename = filename;
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
            writer.WriteElementString("projectname", ProjectName);
            writer.WriteStartElement("files");
            foreach (File filename2 in Files)
            {
                writer.WriteElementString("file", filename2.Path);
            }
            writer.WriteEndElement();
            /******* END FILES ******/
            writer.WriteElementString("outfile", OutputFileName);
            writer.WriteElementString("outputtype", CompileOutputType.ToString());
            writer.WriteEndElement();
            writer.Close();
        }

        public CompilerResults Build()
        {
            return WindowsTextFoundation.LSharpProvider.Compiler.Compile(GetLSharpSources(), OutputFileName, WindowsTextFoundation.LSharpProvider.Compiler.OutputType.Exe, GetWTFFileNames());
        }

        public string GetLSharpSources()
        {
            string ret = "";
            foreach (File fn in Files)
            {
                if (fn.Path.ToLower().EndsWith(".ls"))
                    ret += System.IO.File.ReadAllText(fn.Path);
            }
            return ret;
        }

        public string[] GetWTFFileNames()
        {
            List<string> wtfFiles = new List<string>();
            foreach (File fn in Files)
            {
                if (fn.Path.ToLower().EndsWith(".wtf"))
                    wtfFiles.Add(fn.Path);
            }
            return wtfFiles.ToArray();
        }
    }
}
