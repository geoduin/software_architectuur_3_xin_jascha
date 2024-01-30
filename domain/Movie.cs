using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace software_architectuur_3_xin_jascha.domain
{
    public class Movie
    {
        public string Title { get; set; }

        public Movie(string title)
        {
            Title = title;
        }

        public void AddScreening(MovieScreening MovieScreening)
        {

        }

        public string ToString()
        {
            return "Title: " + this.Title + "\n";
        }
    }
}
