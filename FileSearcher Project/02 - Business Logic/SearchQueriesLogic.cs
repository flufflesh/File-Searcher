namespace SonMogendorff
{
    public class SearchQueriesLogic : Base_Logic
    {
        int id;
        public void AddSearchQuery(string searchText, string rootDir)
        {
            SearchQuery query = new SearchQuery {
                RootDirectory = rootDir,
                TextToSearch = searchText };
            DB.SearchQueries.Add(query);
            
            DB.SaveChanges();
            id = query.SearchQueryID;
        }
        
        public int GetID()
        {
            return id;
        }

        
        

    }
}
