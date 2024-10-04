using System.Transactions;

namespace library_managment_system
{ public class Book
    {
        public string Title {get;set;}
        public string Author { get;set;}
        public string ISBN { get;set;}
        public bool Availability { get;set;}

        public Book(string _title, string _author, string _iSBN)
        {
            this.Title = _title;
            this.Author = _author;
            this.ISBN = _iSBN;
            this.Availability = true;
        }

        public Book() { 
        
        
        }
    }

    public class Library
    {
        public List<Book> Books{ get; set; } = new List<Book>();
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        public Library()
        {
            Books = new List<Book>();
        }



        public void AddBook(Book b)
        {
           Books.Add(b);

        }


         public Book SearchBook(string value)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Title ==value || Books[i].Author==value)
                {
                    return Books[i];
                }
            }

            return null;
        }
        public void BorrowBook(string title , string author=null)

           
        {
            string BorrowedBook ;
            for (int i = 0; i < Books.Count; i++)

            {
                if (Books[i].Title == title || Books[i].Author == author )
                {
                    BorrowedBook= Books[i].Title;
                    BorrowedBooks.Add( Books[i]);
                    Console.WriteLine($"Borrowing book: {Books[i].Title}");
                    Books.RemoveAt(i);
                    
                }
            }
            Console.WriteLine("Book not found.");
        }
        public void ReturnBook(string title, string author = null)
        {
            for (int i = 0; i < BorrowedBooks.Count; i++)
            {
               
                if (BorrowedBooks[i].Title == title || BorrowedBooks[i].Author == author)
                {
                    
                    Books.Add(BorrowedBooks[i]);
                    Console.WriteLine($"Returning book: {BorrowedBooks[i].Title}");

                    
                    BorrowedBooks.RemoveAt(i);
                    return;  
                }
            }

            
            Console.WriteLine("this book is not Borrowed");
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("The Great Gatsby");
            library.BorrowBook("harry potter"); // This book is not in the library
            
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("The Great Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();

        }
    }
}
