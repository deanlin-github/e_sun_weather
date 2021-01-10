using e_sun_weather.DomainModel.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.Infra.Data.Repositories
{
    public class DapperContext : IDapperContext, IDisposable
    {
        public IDbConnection MasterConn { get; }

        public IDbConnection SlaveConn { get; }

        public IDbTransaction Transaction { get; private set; }

        //private readonly ILogger<DapperContext> _logger;

        public DapperContext(IDbConnection masterConn, IDbConnection slaveConn/*, ILogger<DapperContext> logger*/)
        {
            MasterConn = masterConn;
            SlaveConn = slaveConn;
            //logger.LogInformation("DapperContext constructor.....");
            //_logger = logger;
        }

        public void BeginTransaction()
        {
            if (Transaction != null)
                return;

            if (MasterConn.State == ConnectionState.Closed)
                MasterConn.Open();

            Transaction = MasterConn.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
            Transaction.Dispose();
            Transaction = null;
            MasterConn.Close();
        }

        public void Rollback()
        {
            Transaction.Dispose();
            Transaction = null;
            MasterConn.Close();
        }

        public void Dispose()
        {
            MasterConn.Close();
            MasterConn.Dispose();

            SlaveConn.Close();
            SlaveConn.Dispose();
            //_logger.LogInformation("DapperContext dispose.....");
        }
    }
}
