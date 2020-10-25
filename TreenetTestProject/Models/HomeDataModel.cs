using System;
using System.Collections;
using System.Collections.Generic;

namespace TreenetTestProject.Models
{
    public class HomeDataModel : IEnumerable<HomeDataModel>
    {
        public List<Film> models { get; set; }

        public HomeDataModel(List<Film> models)
        {
            this.models = models;
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
            string temp = "";
            foreach (Film item in models)
            {
                temp += item.ToString();
            }
            return (temp);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<HomeDataModel> IEnumerable<HomeDataModel>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
