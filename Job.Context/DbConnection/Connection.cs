using System;
using System.Data;
using System.Data.SqlClient;

namespace Job.Context.DbConnection
{
    public class Connection : IConnection
    {
        private static readonly SqlConnectionStringBuilder LocalConnectionString =
            new SqlConnectionStringBuilder
            {

                ApplicationName = "LocalConnection",
                DataSource = "DESKTOP-NADVQ97",
                InitialCatalog = "JobRecruitmentDb",
                IntegratedSecurity = true,
                PersistSecurityInfo = false,
                Pooling = true
            };

        private static readonly SqlConnectionStringBuilder LiveConnectionString =
            new SqlConnectionStringBuilder
            {
                ApplicationName = "LiveConnection",
                DataSource = "61.247.185.66",
                InitialCatalog = "JobRecruitmentDb",
                IntegratedSecurity = false,
                PersistSecurityInfo = false,
                Pooling = true,
                UserID = "sa",
                Password = "InvoguE!123@",
            };

        private SqlConnection _databaseConnection;
        public IDbConnection GetConnection
        {

            get
            {
                _databaseConnection = new SqlConnection(LiveConnectionString.ConnectionString);

                try
                {
                    if (_databaseConnection.State != ConnectionState.Open)
                    {
                        _databaseConnection?.Open();
                    }

                }
                catch (Exception)
                {
                    _databaseConnection.Close();
                    // ignored
                }
                finally
                {
                    _databaseConnection.Close();
                }
                return _databaseConnection;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Connection() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
