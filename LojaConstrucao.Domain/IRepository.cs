

using System.Collections.Generic;

namespace LojaConstrucao.Domain
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> All();
        void Save(TEntity entity);
    }
}
