using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Subscriber
    {
        public string Username { get; set; }
        public Dictionary<int, Book> Books { get; set; }
        public int NumBooks { get; set; }

        public Subscriber(string username)
        {
            this.Username = username;
            this.Books = new Dictionary<int, Book>();
            this.NumBooks = 0;
        }

        public void addBook(int id, Book book)
        {
            Books.Add(id, book);
            return;
        }

        public void removeBook (int id)
        {
            Books.Remove(id);
            return;
        }
    }
}
