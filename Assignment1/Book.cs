namespace Assignment1
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int NumCopies { get; set; }

        public Book(string title, string author)
        {
            this.Title = title;
            this.Author = author;
            this.NumCopies = 1;
        }
        public override string ToString()
        {
            String details = $"Title = {Title}, Author = {Author}, ";
            return details;
        }
        public string ToStringCopies()
        {
            String details = $", Number of copies available for loan = {NumCopies}";
            return details;
        }
    }
}
