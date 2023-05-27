using LenaProject.DataAccess.Entities;
using LenaProject.DataAccess.Repositories;
using System.Threading.Tasks;

namespace LenaProject.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangesAsync();
    }
}
