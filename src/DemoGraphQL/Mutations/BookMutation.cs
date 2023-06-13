using DemoGraphQL.Abstractions;
using DemoGraphQL.Services;
using HotChocolate.Subscriptions;

namespace DemoGraphQL.Mutations;

public class BookMutation
{
    private readonly BookRepository _bookRepository;

    public BookMutation(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book> AddBook(Book book, [Service] ITopicEventSender eventSender)
    {
        _bookRepository.AddBook(book);
        await eventSender.SendAsync(nameof(Subscriptions.BookUpdates.BooksUpdated), book);
        return book;
    }

    public bool RemoveBook(string title)
    {
        return _bookRepository.RemoveBook(title);
    }
}