using ApiCrud.Repository.Interface;

namespace ApiCrud.Repository
{
    public class RentRepository(DataContext context) : BaseRepository<Rent, DataContext>(context), IRentRepository
    {
    }
}