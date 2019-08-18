using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Base
{
    public abstract class BaseConnection
    {
        private MySqlConnection _connection;

        protected BaseConnection()
        {
            _connection = new MySqlConnection("Server=remotemysql.com;Database=RxIuwNvphM;Uid=RxIuwNvphM;Pwd=UAtxhV9gkS;");
        }

        protected IEnumerable<T> QuerryForList<T>(string sql)
        {
            return _connection.Query<T>(sql);
        }

        protected T QueryForObject<T>(string sql)
        {
            var result = _connection.Query<T>(sql);

            return result.Any() ? result.FirstOrDefault() : default(T);
        }
    }
}
