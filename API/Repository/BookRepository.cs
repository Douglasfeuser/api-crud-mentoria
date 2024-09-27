using ApiCrud.Database;
using ApiCrud.Models;
using ApiCrud.Repository.Interface;

namespace ApiCrud.Repository;

public class BookRepository(DataContext context) : BaseRepository<Book, DataContext>(context), IBookRepository
{
    public IEnumerable<Book> GetBooksByIds(List<int> bookIds)
    {
        return context.Books.Where(b => bookIds.Contains(b.Id)).ToList();
    }
}