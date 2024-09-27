using ApiCrud.Database;
using ApiCrud.Models;

namespace ApiCrud.Repository;

public class GenreRepository(DataContext context) : BaseRepository<Genre, DataContext>(context)
{
    public void DeleteEntity(Genre genre)
    {
        context.Set<Genre>().Remove(genre);
    }
}