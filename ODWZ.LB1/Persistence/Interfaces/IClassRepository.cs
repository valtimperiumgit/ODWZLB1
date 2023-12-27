using ODWZ.LB1.Domain.Models;

namespace ODWZ.LB1.Persistence.Interfaces;

public interface IClassRepository
{
    public Task<Class?> GetClassById(int id);
}