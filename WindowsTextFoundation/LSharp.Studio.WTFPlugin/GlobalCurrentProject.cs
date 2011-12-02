/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 11/30/2011
 * Time: 9:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LSharp.Studio.WTFPlugin
{
    /// <summary>
    /// The current project for global access
    /// </summary>
    public class GlobalCurrentProject
    {
        private GlobalCurrentProject()
        {
        }
        
        public static WTFProject Project
        {get; set; }

        public static Forms.ProjectItemsForm ProjectForm
        {get; set; }

        public static Forms.PropertiesForm PropertiesForm
        {get; set; }

        public static void UpdateWindows()
        {
            if (ProjectForm == null)
            {
                ProjectForm = new LSharp.Studio.WTFPlugin.Forms.ProjectItemsForm();
                LSharp.Studio.MainForm.Instance.AddForm(ProjectForm);
            }
            if (PropertiesForm == null)
            {
                PropertiesForm = new LSharp.Studio.WTFPlugin.Forms.PropertiesForm();
                LSharp.Studio.MainForm.Instance.AddForm(PropertiesForm);
            }
            if (ProjectForm != null)
                ProjectForm.UpdateForm();
            if (PropertiesForm != null)
                PropertiesForm.UpdateForm();
        }
        
        public static void OpenDocumentFromIndex(int index)
        {
            LSharp.Studio.Core.CodeEditingForm f = new LSharp.Studio.Core.CodeEditingForm(System.IO.Path.GetFileName(Project.Files[index].Path));
            f.LoadFile(Project.Files[index].Path);
            LSharp.Studio.MainForm.Instance.AddForm(f);
        }
        
        public static void SelectPropertyItem(int index)
        {
            if (PropertiesForm == null)
            {
                PropertiesForm = new Forms.PropertiesForm();
                LSharp.Studio.MainForm.Instance.AddForm(PropertiesForm);
            }
            if (index != -1)
                PropertiesForm.SelectObject(Project.Files[index]);
            else
                PropertiesForm.SelectObject(Project);
        }
    }
}
