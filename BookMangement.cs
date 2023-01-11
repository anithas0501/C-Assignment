using System;//Default APIs
using Entities;//For the Entity class
using Repository;//Repo class
using SampleConApp; //Utilities

namespace Entities
{
    class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public int BookStock { get; set; } = 10;

        public void ShallowCopy(Book copy)
        {
            this.BookId = copy.BookId;
            this.BookStock = copy.BookStock;
            this.BookTitle = copy.BookTitle;
            this.Price = copy.Price;
            this.Publisher = copy.Publisher;
            this.Author = copy.Author;
        }

        public Book DeepCopy(Book copy)
        {
            Book book = new Book();
            book.ShallowCopy(copy);
            return book;
        }
    }
}
//datatype [] identifier = new datatype[size]
namespace Repository
{
    class BookRepository
    {
        private Book[] _books = null;
        private readonly int _size = 0;
        public BookRepository(int size)
        {
            _size = size;
            _books = new Book[_size];
        }

        public int AddNewBook(Book book)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] == null)
                {
                    _books[i] = book.DeepCopy(book);
                    return 1;//To exit
                }
            }
            return _size;
        }

        public int UpdateBook(Book book)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] != null && _books[i].BookId == book.BookId)
                {
                    _books[i].ShallowCopy(book);
                    return 1;//To exit
                }
            }
            throw new Exception("No book found to update");
        }

        public int RemoveBook(int id)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] != null && _books[i].BookId == id)
                {
                    _books[i] = null;
                    return 1;//To exit
                }
            }
            throw new Exception("No book found to remove");
        }

        public Book[] FindByAuthor(string author)
        {
            int count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.Author.Contains(author))
                {
                    count += 1;
                }
            }
            Book[] books = new Book[count];
            count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.Author.Contains(author))
                {
                    books[count] = book.DeepCopy(book);
                    count += 1;
                }
            }
            return books;
        }

        public Book[] FindByTitle(string title)
        {
            int count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.BookTitle.Contains(title))
                {
                    count += 1;
                }
            }
            Book[] books = new Book[count];
            count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.BookTitle.Contains(title))
                {
                    books[count] = book.DeepCopy(book);
                    count += 1;
                }
            }
            return books;
        }
    }
}

namespace UILayer
{
    enum Options
    {
        Add = 1, Remove=5, Author=3, Title=4, Update=2
    }
    class UIComponent
    {
        public const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~BOOK STORE MANAGER SOFTWARE~~~~~~~~~~~~~~~~~~~\nTO ADD NEW BOOK------------------------>PRESS 1\nTO UPDATE EXISTING BOOK---------------->PRESS 2\nTO FIND BOOK BY AUTHOR----------------->PRESS 3\nTO FIND BOOK BY TITLE------------------>PRESS 4\nTO DELETE BOOK------------------------->PRESS 5\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";

        private static BookRepository repo;

        public static void Run()
        {
            int size = Utilities.GetNumber("Enter the no of Books U need for the Store");
            repo = new BookRepository(size);
            bool processing = true;
            do
            {
                Options option = (Options)Utilities.GetNumber(menu);
                processing = processMenu(option);
            } while (processing);
            Console.WriteLine("Thanks for Using our Application!!!");
        }

        private static bool processMenu(Options option)
        {
            switch (option)
            {

                case Options.Add:
                    addBook();
                    break;
                case Options.Remove:
                    DeleteBook();
                    break;
                case Options.Author:
                    SelectByAuthor();
                    break;
                case Options.Title:
                    SelectByTitle();
                    break;
                case Options.Update:
                    BookUpdate();
                    break;
                default:
                    return false;
            }
            return true;
        }

        public static void addBook()
        {

            int id = Utilities.GetNumber("Enter the book Id");
            string title = Utilities.Prompt("Enter the title of the book");
            string author = Utilities.Prompt("Enter author of the book");
            double Price = Convert.ToDouble(Utilities.Prompt("enter the Price of the Book"));
            string Publisher = Utilities.Prompt("Enter the Publisher of the book");
         int Stock = Utilities.GetNumber("enter the number of stock");
            Book book = new Book { BookId = id, BookTitle = title, Author = author, Price = Price, Publisher = Publisher, BookStock =Stock};

           int result= repo.AddNewBook(book);
            if (result == 1)
            {
                Console.WriteLine("Book added successfully");
            }
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }

        public static void DeleteBook()
        {
            int id = Utilities.GetNumber("Enter the book Id you want to Remove");
            int result = repo.RemoveBook(id);
            if (result == 1)
            {
                Console.WriteLine(" Book removed successfully");
            }
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }
        public static void BookUpdate()
        {

            int id = Utilities.GetNumber("Enter the book Id you want to Update");
            string title = Utilities.Prompt("Enter the title of the book");
            string author = Utilities.Prompt("Enter author of the book");
            double Price = Convert.ToDouble(Utilities.Prompt("enter the Price of the Book"));
            string Publisher = Utilities.Prompt("Enter the Publisher of the book");
            int Stock = Utilities.GetNumber("enter the number of stock");
            Book book = new Book { BookId = id, BookTitle = title, Author = author, Price = Price, Publisher = Publisher, BookStock = Stock };
            int result = repo.UpdateBook(book);
            if(result==1)
                Console.WriteLine("Book update Successfully");
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }
        public static void SelectByAuthor()
        {
            string author = Utilities.Prompt("Enter author of the book");
            Book[] result=repo.FindByAuthor(author);
            foreach (Book item in result)
            {
                Console.WriteLine($"The Id of Book is: {item.BookId}\n The title of the Book is:{item.BookTitle}\n The Author of the Book is: {item.Author}\n The price of the book is:" +
                    $"{item.Price} The Publisher of the Book is: {item.Publisher}\n The Stockof books is: {item.BookStock} ");
            }
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }
        public static void SelectByTitle()
        {
            string title = Utilities.Prompt("Enter the title of the book");
            Book[] result = repo.FindByTitle(title);
            foreach (Book item in result)
            {
                Console.WriteLine($"The Id of Book is: {item.BookId}\n The title of the Book is:{item.BookTitle}\n The Author of the Book is: {item.Author}\n The price of the book is:" +
                   $"{item.Price} The Publisher of the Book is: {item.Publisher}\n The Stockof books is: {item.BookStock} ");
            }
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }
    }
}

namespace BookManagement
{
    class App
    {
        static void Main(string[] args)
        {
            UILayer.UIComponent.Run();
        }
    }
}
