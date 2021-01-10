using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.DomainModel.Repository
{
    public interface IDapperContext
    {
        IDbConnection MasterConn { get; }
        IDbConnection SlaveConn { get; }
        IDbTransaction Transaction { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
