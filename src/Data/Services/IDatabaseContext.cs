using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface IDatabaseContext : IDisposable
    {
        NpgsqlConnection GetConnection();
    }
}
