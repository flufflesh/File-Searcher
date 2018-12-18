namespace SonMogendorff
{
    public class FileEventArgs
    {
        public string FilePath;
        public string RootDirectory;
        public string TextToSearch;
        public FileEventArgs(string filePath, string textToSearch, string rootDir)
        {
            FilePath = filePath;
            TextToSearch = textToSearch;
            RootDirectory = rootDir;
        }
        
    }
}
