using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Library
    {
        protected Dictionary<int, Book> books;
        protected Dictionary<int, Subscriber> subs;

        public Library()
        {
            books = new Dictionary<int, Book>();
            subs = new Dictionary<int, Subscriber>();
        }

        public bool bookExists(int id)
        {
            if (books.ContainsKey(id))
            {
                return true;
            }
            return false;
        }

        public void addBook(int id)
        {
            if(bookExists(id))
            {
                books[id].NumCopies++;
                Console.WriteLine("Book is already in the library - a new copy has been added.");
                return;
            }
            else
            {
                if (id / 100000 < 1)
                {
                    Console.WriteLine("Title of book?");
                    string title = Console.ReadLine();
                    Console.WriteLine("Author of book?");
                    string author = Console.ReadLine();
                    Console.WriteLine("Would you like to input a fiction or reference book?");
                    string input = Console.ReadLine().ToLower();
                    if (input == "fiction")
                    {
                        Console.WriteLine("What genre?");
                        string genre = Console.ReadLine();
                        FictionBook fb = new FictionBook(title, author, genre);
                        books.Add(id, fb);
                        Console.WriteLine("Success, book added!");
                        return;
                    }
                    if (input == "reference")
                    {
                        bool canLoan;
                        Console.WriteLine("Can the book be loaned? (yes or no)");
                        if (Console.ReadLine().ToLower() == "yes")
                        {
                            canLoan = true;
                        }
                        else
                        {
                            canLoan = false;
                        }
                        ReferenceBook rb = new ReferenceBook(title, author, canLoan);
                        books.Add(id, rb);
                        Console.WriteLine("Success, book added!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                    return;
                }
                else
                {
                    Console.WriteLine("The id number must be 5 digits or less.");
                    return;
                }
            }
        }

        public bool subExists(int id)
        {
            if (subs.ContainsKey(id))
            {
                return true;
            }
            return false;
        }

        public void addSub(int id)
        {
            if (subExists(id))
            {
                Console.WriteLine("Subscriber is already in the library, cannot be added again.");
                return;
            }
            else
            {
                Console.WriteLine("Name of subscriber?");
                string name = Console.ReadLine();
                Subscriber sub = new Subscriber(name);
                subs.Add(id, sub);
                Console.WriteLine("Success, subscriber added!");
                return;
            }
        }

        public void loanBook(int idS, string idB)
        {
            if (!subExists(idS))
            {
                Console.WriteLine("There is no subscriber with the id number {0}.", idS);
                return;
            }
            else
            {
                if (subs[idS].NumBooks == 3)
                {
                    Console.WriteLine("You have already hit your max amount of borrowed books.");
                    return;
                }
            }
            int idBook;
            bool details = int.TryParse(idB, out idBook);

            if (!details)
            {
                Dictionary<int, Book> sameTitles = new Dictionary<int, Book>();
                foreach (var book in books)
                {
                    if (book.Value.Title.ToLower() == idB)
                    {
                        sameTitles.Add(book.Key, book.Value);
                    }
                }
                int num_elements = sameTitles.Count;
                if (num_elements == 0)
                {
                    Console.WriteLine("There are no books with this title in the library.");
                    return;
                }
                if (num_elements == 1)
                {
                    foreach (var title in sameTitles)
                    {
                        idBook = title.Key;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Choose a book from the list (please enter the ID): ");
                    foreach (KeyValuePair<int, Book> book in sameTitles)
                    {
                        Console.WriteLine($"ID is {book.Key}, {book.Value.ToString()}");
                    }
                    int choice = -1;
                    int.TryParse(Console.ReadLine(), out choice);
                    if (sameTitles.ContainsKey(choice) == true)
                    {
                        idBook = choice;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                        return;
                    }
                }
            }
            else 
            {
                if (books.ContainsKey(idBook) == false) 
                {
                    Console.WriteLine("There is no book with this id number in the library.");
                    return;
                }
            }
           
            if (books[idBook] is ReferenceBook)
            {
                ReferenceBook rb = (ReferenceBook)books[idBook];
                if (!rb.CanLoan)
                {
                Console.WriteLine("Error! This book is unavailable for loan.");
                return;
                }
            }
            if (books[idBook].NumCopies == 0)
            {
                Console.WriteLine("There are no copies available for loan.");
                return;
            }
            books[idBook].NumCopies--;
            subs[idS].addBook(idBook, books[idBook]);
            subs[idS].NumBooks++;
            Console.WriteLine("The book has been successfully loaned!");
            return;
        }
        public void returnBook(int idS, int idB)
        {
            if (!subExists(idS))
            {
                Console.WriteLine("There is no subscriber with the id number {0}.", idS);
                return;
            }
            if (subs[idS].Books.ContainsKey(idB) == false)
            {
                Console.WriteLine("This book is not found in the subscriber's account.");
                return;
            }

            books[idB].NumCopies++;
            subs[idS].removeBook(idB);
            subs[idS].NumBooks--;
            Console.WriteLine("The book has been successfully returned!");
            return;
        }

        public override string ToString()
        {
            String details = "";
            foreach(KeyValuePair<int, Book> book in books)
            {
                details += ($"ID is {book.Key}, {book.Value.ToString()}{book.Value.ToStringCopies()} \n");
            }
           
            return details;
        } 

        public string booksByGenre(string genre)
        {
            String genreBooks = "";
            foreach(var book in books)
            {
                if (book.Value is FictionBook)
                {
                    FictionBook fb = (FictionBook)book.Value;
                    if (fb.Genre.ToLower() == genre)
                    {
                        genreBooks += book.Value.ToString() + book.Value.ToStringCopies() + "\n";
                    }
                }
            }
            return genreBooks;
        }

        public string booksBySub(int id)
        {
            if (!subExists(id))
            {
                Console.WriteLine("There is no subscriber with the id number {0}.", id);
                return "";
            }

            String details = "";
            foreach (KeyValuePair<int, Book> book in subs[id].Books)
            {
                details += ($"ID is {book.Key}, {book.Value.ToString()} \n");
            }
            return details;
        }
    }
}
