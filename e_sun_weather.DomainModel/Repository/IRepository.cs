using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.DomainModel.Repository
{
    public interface IRepository<TEntity> where TEntity : IAggregate
    {
        Task<TEntity> FindById(long id);

        Task<bool> AddAsync(TEntity entity);

        Task<bool> RemoveAsync(TEntity entity);
    }

    public interface IRepository
    {

    }
}
