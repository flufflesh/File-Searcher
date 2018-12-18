using System;
using System.Collections.Generic;
using System.Threading;

namespace SonMogendorff
{

    class UI
    {
        public List<string> pathList = new List<string>();
        public void DisplayFile(object sender, FileEventArgs e)
        {
            Console.WriteLine(e.FilePath);
        }

        public void SendPathToList(object sender, FileEventArgs e)
        {

            pathList.Add(e.FilePath);

        }

        bool Continue = true;

        public void FirstPrompt()
        {

            if (Continue == true)
            {
                Console.WriteLine("Hello and welcome to FileSearcher by Son Mogendorff\n Would you like to:\n" +
                    "1 - Search for file with directory\n" +
                    "2 - Search for file in entire computer\n" +
                    "3 - Exit");
                try
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            SearchFile(PromptFolder(), PromptFile());
                            Console.WriteLine("Enter any key to continue.");
                            Console.ReadLine();
                            break;
                        case 2:
                            SearchFile("C:\\", PromptFile());
                            Console.WriteLine("Enter any key to continue.");
                            Console.ReadLine();
                            break;
                        case 3:
                            Continue = false;
                            break;

                        default:
                            Console.WriteLine("Please input a number from 1 - 3");
                            Console.WriteLine("Enter any key to continue.");
                            Console.ReadLine();
                            break;
                    }
                }
                catch (Exception e)
                {
                    // I'm using this try/catch incase the user's input is anything that isn't an integer. Then it'll throw the exception.

                    e = new Exception("Please input a number.");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter any key to continue.");
                    Console.ReadLine();
                };
                Console.Clear();
                FirstPrompt();
            }

        }

        public string PromptFolder()
        {
            Console.WriteLine("Please enter a folder.");
            return Console.ReadLine();
        }
        public string PromptFile()
        {
            Console.WriteLine("Please enter a file to search");
            return Console.ReadLine();
        }
        public void SearchFile(string FolderToSearch, string TextToSearch)
        {
            SearchQueriesLogic queriesLogic = new SearchQueriesLogic();
            SearchResultsLogic resultsLogic = new SearchResultsLogic();

            FileSearcher fs = new FileSearcher();
            fs.FoundOneFile += DisplayFile;
            fs.FoundOneFile += SendPathToList;
            fs.SearchWithRoot(FolderToSearch, TextToSearch);

            queriesLogic.AddSearchQuery(TextToSearch, FolderToSearch);
            resultsLogic.AddAllResults(TextToSearch, pathList, queriesLogic.GetID());
            if(fs.hadException == true)
            {
                Console.WriteLine("Could not search a folder(s) due to said folder being unreachable or not existing. Try administrator rights to fix this.");
            }
            

        }
    }
}
