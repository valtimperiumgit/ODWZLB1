using ODWZ.LB1.Persistence.DBContext;

namespace ODWZ.LB1.Persistence.Repositories;

public abstract class BaseRepository
{
    protected readonly AppDbContext AppDbContext;

    protected BaseRepository(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }
}