using System;
using System.Data;

namespace Job.Context.DbConnection
{
    public interface IConnection : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
