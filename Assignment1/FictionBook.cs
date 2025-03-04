using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class FictionBook : Book
    {
        public string Genre { get; set; }
        public FictionBook(string title, string author, string genre) : base(title, author)
        {
            this.Genre = genre;
        }
        public override string ToString()
        {
            string details = base.ToString() + "Genre = " + Genre;
            return details;
        }

    }
}
