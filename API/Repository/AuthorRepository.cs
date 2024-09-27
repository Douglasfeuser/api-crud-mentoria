namespace ApiCrud.Repository;

public class AuthorRepository(DataContext context) : BaseRepository<Author, DataContext>(context)
{
    
}