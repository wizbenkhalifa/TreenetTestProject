using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
