using Microsoft.EntityFrameworkCore;
using ODWZ.LB1.Domain.Models;
using ODWZ.LB1.Persistence.DBContext;
using ODWZ.LB1.Persistence.Interfaces;

namespace ODWZ.LB1.Persistence.Repositories;

public class ClassRepository : BaseRepository, IClassRepository
{
    public ClassRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public Task<Class?> GetClassById(int id)
    {
        return AppDbContext.Classes.FirstOrDefaultAsync(c => c.Id == id);
    }
}