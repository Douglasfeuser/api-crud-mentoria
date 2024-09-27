using ApiCrud.Models;

namespace ApiCrud.Repository.Interface
{
    public interface IBookRepository
    {
        Task<Book?> GetEntityById(int id);
        Task<List<Book>> GetAll();
        IEnumerable<Book> GetBooksByIds(List<int> bookIds);
        Task<Book> InsertEntity(Book entity);
        Task UpdateEntity(Book entity);
    }
}