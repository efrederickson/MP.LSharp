using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSharp.Studio.WTFPlugin.Projects
{
    interface IProject
    {
        string Name
        {get; }
        string Info
        { get; }
        WTFProject Create(string outputDir, string projectFile);
    }

    class BasicProject : IProject
    {
        public WTFProject Create(string outputDir, string projectFile)
        {
            string wtfFileText = @"BEGIN System.Windows.Forms.Form MainForm
    Text = ""MainForm""
    Name = ""Form1""
    Size = System.Drawing.Size(500, 300)
ENDOBJECT
";
            string lsFileText = ";;; Show WTF Form\r\n(showdialog MainForm)";
            System.IO.File.WriteAllText(outputDir + "\\MainForm.wtf", wtfFileText);
            System.IO.File.WriteAllText(outputDir + "\\main.ls", lsFileText);
            WTFProject proj = new WTFProject();
            proj.Files.Add(outputDir + "\\MainForm.wtf");
            proj.Files.Add(outputDir + "\\main.ls");
            proj.CompileOutputType = WindowsTextFoundation.LSharpProvider.Compiler.OutputType.WinFormsExe;
            proj.XmlFilename = projectFile;
            proj.Save(projectFile);
            proj.Load(projectFile);
            return proj;
        }

        public string Info
        {
            get { return "Basic L# Windows Text Foundation Project"; }
        }

        public string Name
        {
            get { return "Basic L# WTF Project"; }
        }
    }

    class InstructinalProject : IProject
    {
        public string Info
        {
            get { return "L# WTF Project Template with examples and instructional text"; }
        }

        public WTFProject Create(string outputDir, string projectFile)
        {
            
        }
    
        public string  Name 
        {
            get { return "L# WTF Instructional Project"; }
        }
    }   

}
