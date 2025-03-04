using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class ReferenceBook : Book
    {
        public bool CanLoan { get; set; }
        public ReferenceBook(string title, string author, bool canLoan) : base(title, author)
        {
            this.CanLoan = canLoan;
        }
        public override string ToString()
        {
            string details = base.ToString() + "Can be loaned = " + CanLoan;
            return details;
        }
    }
}
