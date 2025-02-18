using System;
using System.Collections.Generic;
// main program : Program.cs
class Program
{
    // Data structures to store books and members
    static List<Book> books = new List<Book>();
    static List<Member> members = new List<Member>();

    static void Main(string[] args)
    {
        SeedData(); // Prepopulate some data

        while (true)    // basic Library system options
        {
            Console.Clear();
            Console.WriteLine("Library Management System\n");
            Console.WriteLine("1. Manage Books");
            Console.WriteLine("2. Manage Members");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            // taking input from User
            switch (Console.ReadLine())   
            {
                case "1": ManageBooks(); break;
                case "2": ManageMembers(); break;
                case "3": BorrowBook(); break;
                case "4": ReturnBook(); break;
                case "5": return;
                default: Console.WriteLine("Invalid choice. Press Enter to try again."); Console.ReadLine(); break;
            }
        }
    }
    // defining book management method
    static void ManageBooks()
    {
        while (true)    // Basic options for book management
        {
            Console.Clear();
            Console.WriteLine("Manage Books\n");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View Books");
            Console.WriteLine("3. Go Back");
            Console.Write("Enter your choice: ");

            switch (Console.ReadLine())  // taking user input 
            {
                case "1":   // for adding a book
                    Console.Write("Enter Book Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter Copies Available: ");
                    int copies;
                    int.TryParse(Console.ReadLine(), out copies);
                    books.Add(new Book { Title = title, Author = author, CopiesAvailable = copies });
                    Console.WriteLine("Book added successfully! Press Enter to continue.");
                    Console.ReadLine();
                    break;
                case "2":    // for viewing available books
                    Console.Clear();
                    Console.WriteLine("Books List:\n");
                    foreach (var book in books)
                    {
                        Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Copies: {book.CopiesAvailable}");
                    }
                    Console.WriteLine("\nPress Enter to go back.");
                    Console.ReadLine();
                    break;
                case "3": return;
                default: Console.WriteLine("Invalid choice. Press Enter to try again."); Console.ReadLine(); break;
            }
        }
    }
    // defining member management method
    static void ManageMembers()
    {
        while (true)      // Library members' data mgm
        {
            Console.Clear();
            Console.WriteLine("Manage Members\n");
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. View Members");
            Console.WriteLine("3. Go Back");
            Console.Write("Enter your choice: ");

            switch (Console.ReadLine())  // Taking user input
            {
                case "1":   // for adding a new member
                    Console.Write("Enter Member Name: ");
                    string name = Console.ReadLine();
                    members.Add(new Member { Name = name });
                    Console.WriteLine("Member added successfully! Press Enter to continue.");
                    Console.ReadLine();
                    break;
                case "2":    // for viewing member's list
                    Console.Clear();
                    Console.WriteLine("Members List:\n");
                    foreach (var member in members)
                    {
                        Console.WriteLine($"Name: {member.Name}");
                    }
                    Console.WriteLine("\nPress Enter to go back.");
                    Console.ReadLine();
                    break;
                case "3": return;
                default: Console.WriteLine("Invalid choice. Press Enter to try again."); Console.ReadLine(); break;
            }
        }
    }
    // defining borrowing book method
    static void BorrowBook()
    {
        Console.Clear();
        Console.WriteLine("Borrow Book\n");
        // first checking memeber is available or not
        Console.Write("Enter Member Name: ");
        string memberName = Console.ReadLine();
        var member = members.Find(m => m.Name.Equals(memberName, StringComparison.OrdinalIgnoreCase));

        if (member == null)
        {
            Console.WriteLine("Member not found. Press Enter to go back.");
            Console.ReadLine();
            return;
        }
        // next checking entered book name is available or not
        Console.Write("Enter Book Title: ");
        string bookTitle = Console.ReadLine();
        var book = books.Find(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));

        if (book == null || book.CopiesAvailable <= 0)
        {
            Console.WriteLine("Book not available. Press Enter to go back.");
            Console.ReadLine();
            return;
        }
        // if available then after borrinwing lowering down the previously available copies
        book.CopiesAvailable--;
        Console.WriteLine("Book borrowed successfully! Press Enter to continue.");
        Console.ReadLine();
    }
// defining return book method
    static void ReturnBook()
    {
        Console.Clear();
        Console.WriteLine("Return Book\n");
        // checking entered book name present in book list or not
        Console.Write("Enter Book Title: ");
        string bookTitle = Console.ReadLine();
        var book = books.Find(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));

        if (book == null)
        {
            Console.WriteLine("Book not found. Press Enter to go back.");
            Console.ReadLine();
            return;
        }
        // after returning book incrementing the copies available
        book.CopiesAvailable++;
        Console.WriteLine("Book returned successfully! Press Enter to continue.");
        Console.ReadLine();
    }
    // Primary data prepopulation
    static void SeedData()
    {
        books.Add(new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", CopiesAvailable = 4 });
        books.Add(new Book { Title = "1984", Author = "George Orwell", CopiesAvailable = 2 });
        members.Add(new Member { Name = "Susmit" });
        members.Add(new Member { Name = "Alice" });
        members.Add(new Member { Name = "Priyanka" });
        members.Add(new Member { Name = "Selena" });
    }
}
