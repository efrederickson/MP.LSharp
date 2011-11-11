/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 10/21/2011
 * Time: 6:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LSharp
{
    /// <summary>
    /// Used in the Compiler
    /// </summary>
    public class AssemblyDefintion
    {
        public DefinitionType Type;
        public string value;
        
        public AssemblyDefintion(DefinitionType dt, string value)
        {
            this.Type = dt;
            this.value = value;
        }
    }
    
    public enum DefinitionType
    {
        None, // used for empty declarations
        Namespace, 
        Class,
        EndNamespace,
        EndClass
    }
}
