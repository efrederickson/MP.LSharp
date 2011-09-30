/*
 * Created by SharpDevelop.
 * User: elijah
 * Date: 9/24/2011
 * Time: 1:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;
using Microsoft.Build.Tasks;
using System.IO;
namespace LSharp.MSBuild.Tasks
{
	[Serializable]
	public class CreateLSharpManifestResourceName : CreateCSharpManifestResourceName
	{
		protected override string CreateManifestName(string fileName, string linkFileName, string rootNamespace, string dependentUponFileName, System.IO.Stream binaryStream)
		{
			string text = (linkFileName == null) ? fileName : linkFileName;
			string text2 = base.CreateManifestName(fileName, linkFileName, "", dependentUponFileName, null);
			if (text.EndsWith(".resources", StringComparison.OrdinalIgnoreCase) && !text2.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
			{
				return text2 + ".resources";
			}
			return text2;
		}
		protected override bool IsSourceFile(string filename)
		{
			string extension = Path.GetExtension(filename);
			return string.Equals(extension, ".ls", StringComparison.OrdinalIgnoreCase) || string.Equals(extension, ".ml", StringComparison.OrdinalIgnoreCase);
		}
	}
}
