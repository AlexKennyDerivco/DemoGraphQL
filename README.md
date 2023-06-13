# Simple GraphQL implementation in dotnet

This is a very basic implementation of GraphQL in dotnet feel free to play around.

## How to run

Build and run the application from your favourite IDE.

## How to use

When the debugging starts the GraphQL interface will open up.
If it does not, you can access it at: <https://localhost:7280/graphql/>.

You are then free to explore and create your own queries.

## Example queries

Here are some example queries you can try out:

### Mutation to add a book and query back the result

```
mutation AddBook {
  addBook(
    book: { title: "LotR", revision: 1, author: { name: "J. R. R. Tolkien
" } }
  ) {
    title
    revision
    author {
      name
    }
  }
}
```

### Query for a specific book

```
query GetBook {
  book(title: "LotR") {
    title
    revision
  }
}
```

### Query all books

```
query GetBooks {
  books {
    title
    revision
  }
}
```

### Mutation to remove a book

```
mutation RemoveBook {
  removeBook(title: "LotR")
}
```

### Subscription for book changes

This one you can run in a separate tab and add books from another tab as a subscription blocks a tab as it receives updates from a Websocket.

```
subscription BookUpdated {
  booksUpdated {
    title
    revision
  }
}
```