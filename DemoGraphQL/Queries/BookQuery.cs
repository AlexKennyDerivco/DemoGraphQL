using DemoGraphQL.Abstractions;
using DemoGraphQL.Services;

namespace DemoGraphQL.Queries;

public class BookQuery
{
    private readonly BookRepository _bookRepository;

    public BookQuery(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    /// <summary>
    /// Returns a single book
    /// </summary>
    /// <returns></returns>
    public Book? GetBook(string title) => _bookRepository.GetBook(title);
}