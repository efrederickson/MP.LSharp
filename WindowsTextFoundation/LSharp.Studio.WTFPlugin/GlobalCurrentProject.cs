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
		if (ProjectForm != null)
                    ProjectForm.UpdateForm();
                if (PropertiesForm != null)
                    PropertiesForm.UpdateForm();
	}
    }
}
