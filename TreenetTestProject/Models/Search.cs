namespace TreenetTestProject.Models
{
    public class Search
    {
        public int searchID { get; set; }
        public string searchText { get; set; }

        public Search(string searchText)
        {
            this.searchText = searchText;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{searchID} | {searchText}";
        }
    }
}
