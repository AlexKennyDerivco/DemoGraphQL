using System.Collections.ObjectModel;
using DemoGraphQL.Abstractions;

namespace DemoGraphQL.Services;

public class BookRepository
{
    private List<Book> StoredBooks { get; } = new();

    public void AddBook(Book book)
    {
        if(StoredBooks.All(x => x.Title != book.Title))
            StoredBooks.Add(book);
    }

    public bool RemoveBook(string title)
    {
        return StoredBooks.RemoveAll(x => x.Title == title) == 0;
    }

    public Book? GetBook(string title)
    {
        return StoredBooks.FirstOrDefault(x => x.Title == title);
    }

    public ReadOnlyCollection<Book> GetBooks()
    {
        return StoredBooks.AsReadOnly();
    }
}