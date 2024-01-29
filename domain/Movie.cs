using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace software_architectuur_3_xin_jascha.domain
{
    internal class Movie
    {
        public string Title { get; set; }

        public Movie(string title)
        {
            Title = title;
        }

        public void AddScreening(MovieScreening MovieScreening)
        {

        }

        public static string ToString()
        {
            return "";
        }
    }
}
