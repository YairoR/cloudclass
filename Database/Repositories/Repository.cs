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
        private const string RetryPolicyName = "DefaultRetry";
        private const int BackoffRetry = 3;

        private static readonly TimeSpan s_backOffMin = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan s_backOffMax = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan s_backOffDelta = TimeSpan.FromSeconds(3);

        private SqlConnectionStringBuilder m_sqlConnectionString = new SqlConnectionStringBuilder();

        public Repository()
        {
            CreateConnectionString();
        }

        #region Private Methods

        private void CreateConnectionString()
        {
            m_sqlConnectionString.DataSource = "pzze5baa7t.database.windows.net,1433";
            m_sqlConnectionString.InitialCatalog = "cloudclass-db";
            m_sqlConnectionString.Encrypt = true;
            m_sqlConnectionString.TrustServerCertificate = false;
            m_sqlConnectionString.UserID = "hackidc";
            m_sqlConnectionString.Password = "hack2014!";
        }

        protected IDbConnection CreateConnection()
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
