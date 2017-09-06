using System.Threading.Tasks;

namespace LojaConstrucao.Domain
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
