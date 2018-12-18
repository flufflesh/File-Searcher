using System;
using System.IO;

namespace SonMogendorff
{
    public delegate void FilesHandler(object sender, FileEventArgs e);
    public class FileSearcher
    {
        public event FilesHandler FoundOneFile;
        public bool hadException = false;
        public void SearchWithRoot(string folder, string textToSearch)
        {
            try
            {
                string[] files = Directory.GetFiles(folder, "*" + textToSearch + "*");

                foreach (string item in files)
                {
                    FoundOneFile(this, new FileEventArgs(item, textToSearch, folder));
                }
                string[] directories = Directory.GetDirectories(folder);
                foreach (string item in directories)
                {
                    SearchWithRoot(item, textToSearch);
                }
            }
            // If the user is trying to access folders that aren't accessible without admin rights, or at all
            // such as the default Windows folders, or the Recycle bin.
            // I chose to not display the exception because it'll FLOOD the command line with the exception, and the user
            // should care more about the files they searched for more than the error.
            catch 
            {
                
                hadException = true;
            }
        }
        
        
    }
}
