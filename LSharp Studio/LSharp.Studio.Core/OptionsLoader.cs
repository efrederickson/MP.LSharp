namespace LSharp.Studio.Core
{
    public class OptionsLoader
    {
        public static void Load()
        {
            if (LSharp.Studio.Core.Properties.Settings.Default.DefaultSaveLocation == "SET")
            	LSharp.Studio.Core.Properties.Settings.Default.DefaultSaveLocation =  System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\LSharp Studio";

            if (!System.IO.Directory.Exists(LSharp.Studio.Core.Properties.Settings.Default.DefaultSaveLocation))
                System.IO.Directory.CreateDirectory(LSharp.Studio.Core.Properties.Settings.Default.DefaultSaveLocation);
        }
    }
}
