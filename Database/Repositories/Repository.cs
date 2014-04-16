using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class Repository
    {
        private SqlConnectionStringBuilder m_sqlConnectionString = new SqlConnectionStringBuilder();

        #region Private Methods

        private void CreateConnectionString()
        {
            m_sqlConnectionString.DataSource = "pzze5baa7t.database.windows.net,1433";
            m_sqlConnectionString.InitialCatalog = "cloudclass-db";
            m_sqlConnectionString.Encrypt = true;
            m_sqlConnectionString.TrustServerCertificate = true;
            m_sqlConnectionString.UserID = "hackidc";
            m_sqlConnectionString.Password = "hack2014!";
        }

        private IDbConnection CreateConnection()
        {
            try
            {
                var connection = new SqlConnection(m_sqlConnectionString.ToString());
                connection.Open();
                return connection;
            }
            catch (SqlException exception)
            {
                var message = string.Format("Failed opening SQL connection. Error number {0}. Exception {1}", exception.Number, exception);
                throw new DatabaseException(message);
            }
            catch (InvalidOperationException exception)
            {
                var message = string.Format("Failed opening SQL connection. Exception {0}", exception);
                throw new DatabaseException(message);
            }
        }

        #endregion
    }
}
