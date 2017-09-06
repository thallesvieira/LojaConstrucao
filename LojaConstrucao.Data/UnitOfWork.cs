using LojaConstrucao.Data.Contexts;
using LojaConstrucao.Domain;
using System.Threading.Tasks;

namespace LojaConstrucao.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
