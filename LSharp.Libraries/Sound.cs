using System;

using System.Runtime.InteropServices;

namespace LSharp.Libraries
{
	/// <summary>
	/// Summary description for Sound.
	/// </summary>
	public class Sound
	{
		[DllImport("Winmm.dll")]
		static extern int sndPlaySound(string lpszSound,  int fuSound);
		
        /// <summary>
        /// Plays a sound from filename
        /// </summary>
        /// <param name="filename"></param>
		public static int Play(string filename) 
		{
			 return sndPlaySound(filename,0);
		}
	}
}
