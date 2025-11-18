using System;
using System.Collections;

interface IBook
{
    string Id { get; }
    string Title { get; }
    string Author { get; }
    int Year { get; }

    void DisplayInfor();
}

class Book : IBook
{
    public string Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Year { get; private set; }
    public int Pages { get; private set; }

    public Book(string id, string title, string author, int year, int pages)
    {
        Id = id;
        Title = title;
        Author = author;
        Year = year;
        Pages = pages;
    }

    public virtual void DisplayInfor()
    {
        Console.WriteLine($"[Book] {Id} | {Title} - {Author} ({Year}), {Pages} pages");
    }
}

class EBook : Book
{
    private double FileSizeMB;

    public double fileSizeMB 
    {
        get { return FileSizeMB; } 
        set { FileSizeMB = value; }
    }

    public EBook(string id, string title, string author, int year, int pages, double fileSizeMB)
        : base(id, title, author, year, pages)
    {
        FileSizeMB = fileSizeMB;
    }

    public override void DisplayInfor()
    {
        Console.WriteLine($"[EBook] {Id} | {Title} - {Author} ({Year}), {Pages} pages, {FileSizeMB}MB");
    }
}

class Library
{
    private List<IBook> books = new List<IBook>();

    public void AddBook(IBook book)
    {
        books.Add(book);
    }

    public bool RemoveBook(IBook book)
    {
        if (books.Contains(book))
        {
            books.Remove(book);
            return true;
        }
        return false;
    }

    public List<IBook> GetAll()
    {
        return books;
    }

    public void PrintInventory()
    {
        foreach (IBook book in books)
        {
            book.DisplayInfor();
        }
    }

    public void PrintInventory(string author)
    {
        foreach (IBook book in books)
        {
            if (book.Author == author)
            {
                book.DisplayInfor();
            }
        }
    }
}


class Program
{
    static void Main()
    {
        Library list = new Library();

        IBook book1 = new Book("B001", "The Great Gatsby", "F. Scott Fitzgerald", 1925, 180);
        IBook ebook1 = new EBook("EB001", "1984", "George Orwell", 1949, 328, 1.5);

        list.AddBook(book1);
        list.AddBook(ebook1);

        list.PrintInventory();

        list.GetAll();

        Console.WriteLine("Find Author: ");
        string author = Console.ReadLine();
        list.PrintInventory(author);

    }
}
