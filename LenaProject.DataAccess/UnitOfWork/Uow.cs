using LenaProject.DataAccess.Context;
using LenaProject.DataAccess.Entities;
using LenaProject.DataAccess.Repositories;
using System.Threading.Tasks;

namespace LenaProject.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly ProjectContext _context;

        public Uow(ProjectContext context)
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
