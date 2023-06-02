using DemoGraphQL.Abstractions;

namespace DemoGraphQL.Subscriptions;

public class BookUpdates
{
    [Subscribe]
    public Book BooksUpdated([EventMessage] Book book) => book;
}