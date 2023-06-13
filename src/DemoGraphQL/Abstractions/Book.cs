namespace DemoGraphQL.Abstractions;

/// <summary>
/// A book
/// </summary>
public class Book
{
    /// <summary>
    /// The title of the book
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The author of the book
    /// </summary>
    public Author Author { get; set; }

    public int Revision { get; set; }

    public Book(string title, int revision, Author author)
    {
        Title = title;
        Revision = revision;
        Author = author;
    }
}

/// <summary>
/// An author
/// </summary>
public class Author
{
    /// <summary>
    /// The name of the author
    /// </summary>
    public string Name { get; set; }

    public Author(string name)
    {
        Name = name;
    }
}