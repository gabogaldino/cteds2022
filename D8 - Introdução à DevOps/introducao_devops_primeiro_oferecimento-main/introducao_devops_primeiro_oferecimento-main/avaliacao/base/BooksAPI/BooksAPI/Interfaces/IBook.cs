using BooksAPI.Domains;

namespace BooksAPI.Interfaces;

public interface IBook
{
    List<Book> List();
}
