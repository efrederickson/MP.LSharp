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

    class InstructionalProject : IProject
    {
        public string Info
        {
            get { return "L# WTF Project Template with examples and instructional text"; }
        }

        public WTFProject Create(string outputDir, string projectFile)
        {
            string wtfFileText = @"BEGIN System.Windows.Forms.Form MainForm
    Text = ""MainForm""
    Name = ""Form1""
    Size = System.Drawing.Size(500, 300)
ENDOBJECT
";
            string lsFileText = @";;; L# in WindowsTextFoundation sample
;;; WTF Is basically wpf except text version, no visual designer, and for L#.
;;; even so, Windows Text Foundation can easily let 
;;; you create forms and put controls on them.
;;; Then, in your L# code, you can access that 
;;; object through the name you gave it in the
;;; .wtf file.

;;; example: reference the MainForm object created in wtf
;;; and show it to the user
(showdialog MainForm)
";
            System.IO.File.WriteAllText(outputDir + "\\MainForm.wtf", wtfFileText);
            System.IO.File.WriteAllText(outputDir + "\\main.ls", lsFileText);
            WTFProject proj = new WTFProject();
            proj.Files.Add(outputDir + "\\MainForm.wtf");
            proj.Files.Add(outputDir + "\\main.ls");
            proj.CompileOutputType = WindowsTextFoundation.LSharpProvider.Compiler.OutputType.Exe;
            proj.XmlFilename = projectFile;
            proj.Save(projectFile);
            proj.Load(projectFile);
            return proj;
        }
    
        public string  Name 
        {
            get { return "L# WTF Instructional Project"; }
        }
    }   

}
