/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/22/2011
 * Time: 9:07 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LSharp
{
	/// <summary>
	/// Methods created by defmethod for use in defclass
	/// </summary>
	public class DefinedMethod
	{
		public string Commands;
		public string Name;
		public string[] args;
		
		public DefinedMethod(string c, string n, string[] a)
		{
			Commands = "(do " + c + ")";
			Name = n;
			args = a;
		}
		
	}
}
