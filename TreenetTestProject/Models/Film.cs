using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TreenetTestProject.Models
{
    public class Film
    {
        public int filmID { get; set; }
        public string title { get; set; }
        public string producer { get; set; }
        public int duration { get; set; }

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
            return $"{filmID}.{title}|";
        }
    }
}
