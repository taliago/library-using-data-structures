using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class RunProgram
    {
        public static void Main(string[] args)
        {
            Library library = new Library();
            while (true)
            {
                Console.WriteLine("Welcome to the library! Choose an option: (input a number 1-7)");
                Console.WriteLine("1) Add a new book to the library");
                Console.WriteLine("2) Add a new subscriber to the library");
                Console.WriteLine("3) Borrow a book");
                Console.WriteLine("4) Return a book");
                Console.WriteLine("5) Print details of all books in library");
                Console.WriteLine("6) Print book details by genre");
                Console.WriteLine("7) Print details of books borrowed by a specific subscriber");
                Console.WriteLine("8) Leave the program");

                switch (Console.ReadLine())
                {
                    case "1":
                        int id;
                        Console.WriteLine("ID number of book?");
                        bool success = int.TryParse(Console.ReadLine(), out id);
                        if (success)
                        {
                            library.addBook(id);
                        }
                        else
                        {
                            Console.WriteLine("Must input a number");
                        }
                        break;
                
                    case "2":
                        int id1;
                        Console.WriteLine("ID number of subscriber?");
                        bool success1 = int.TryParse(Console.ReadLine(), out id1);
                        if (success1)
                        {
                            library.addSub(id1);
                        }
                        else
                        {
                            Console.WriteLine("Must input a number");
                        }
                        break;

                        

                    case "3":
                        int id2;
                        Console.WriteLine("What is your ID number?");
                        bool num1 = int.TryParse(Console.ReadLine(), out id2);
                        if (!num1)
                        {
                            Console.WriteLine("Invalid input");
                            break;
                        }
                        Console.WriteLine("Please enter either the book's ID number or title.");
                        library.loanBook(id2, Console.ReadLine().ToLower());
                        break;

                    case "4":
                        int id3;
                        Console.WriteLine("What is your ID number?");
                        bool num2 = int.TryParse(Console.ReadLine(), out id3);
                        if (!num2)
                        {
                            Console.WriteLine("Invalid input");
                            break;
                        }
                        int id4;
                        Console.WriteLine("Please enter the book's ID number.");
                        bool num3 = int.TryParse(Console.ReadLine(), out id4);
                        if (!num3)
                        {
                            Console.WriteLine("Invalid input");
                            break;
                        }
                        library.returnBook(id3, id4);
                        break;

                    case "5":
                        string str = (library.ToString());
                        if (str == "")
                        {
                            Console.WriteLine("There are no books in the library.");
                        }
                        else
                        {
                            Console.WriteLine(str);
                        }
                        break;

                    case "6":
                        Console.WriteLine("Pick a genre:");
                        String genre = Console.ReadLine().ToLower();
                        String s = library.booksByGenre(genre);
                        if (s == "")
                        {
                            Console.WriteLine("There are no books in this genre in the library.");
                        }
                        else
                        {
                            Console.WriteLine($"Books in {genre} genre are: \n {s}");
                        }

                        break;

                    case "7":
                        int id5;
                        Console.WriteLine("What is your ID number?");
                        bool num4 = int.TryParse(Console.ReadLine(), out id5);
                        if (!num4)
                        {
                            Console.WriteLine("Invalid input");
                            break;
                        }
                       
                        string str1 = (library.booksBySub(id5));
                        if (str1 == "")
                        {
                            Console.WriteLine("There are no books in the subscriber's account.");
                        }
                        else
                        {
                            Console.WriteLine(str1);
                        }
                        break;

                    case "8":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Please enter a number between 1 and 8.");
                        break;
                }
            }
        }
    }
}
