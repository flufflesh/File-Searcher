using System;
using System.Collections.Generic;

namespace SonMogendorff
{
    public class SearchResultsLogic : Base_Logic
    {
        public void AddResult(int id, string resultString)
        {
            
            SearchResult result = new SearchResult
            {
                SearchQueryID = id,
                FoundFile = resultString
            };
            DB.SearchResults.Add(result);
            try
            {
                DB.SaveChanges();
            }
            catch(Exception e)
            {
                // The path nvarchar in the database is 100 characters long, if it is longer
                // then it will throw this exception, otherwise the program will crash
                // to a "validation error"
                e = new Exception($"Cannot add {result.FoundFile} to database. Result path is illegal or too long.");
                Console.WriteLine(e.Message);
            }
        }
        public void AddAllResults(string textToSearch, List<string> pathList, int id)
        {
            // Running add results for every path i found..
            foreach (string item in pathList)
            {
                AddResult(id, item);
            }
            
            
        }
    }
}
