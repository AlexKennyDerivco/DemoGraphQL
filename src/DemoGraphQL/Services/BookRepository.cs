using System.Collections.ObjectModel;
using DemoGraphQL.Abstractions;

namespace DemoGraphQL.Services;

public class BookRepository
{
    private List<Book> StoredBooks { get; } = new();

    public void AddBook(Book book)
    {
        if (StoredBooks.Any(x => x.Title == book.Title)) return;
        StoredBooks.Add(book);
    }

    public bool RemoveBook(string title) => StoredBooks.RemoveAll(x => x.Title == title) != 0;

    public Book? GetBook(string title) => StoredBooks.FirstOrDefault(x => x.Title == title);

    public ReadOnlyCollection<Book> GetBooks() => StoredBooks.AsReadOnly();
}