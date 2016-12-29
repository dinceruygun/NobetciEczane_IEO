using Dapper;
using NobetciEczane_IEO.CHZDataEntity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobetciEczane_IEO
{
    public static class NCZData
    {
        
    }



    class DataRetriever : IDisposable
    {
        private IDbConnection _dbConnection;

        public DataRetriever(string connectionString)
        {
            _dbConnection = new NpgsqlConnection(connectionString);
            _dbConnection.Open();
        }

        public IDbConnection DbConnection
        {
            get
            {
                return _dbConnection;
            }
        }

        public void Dispose()
        {
            _dbConnection.Close();
        }
    }

}
