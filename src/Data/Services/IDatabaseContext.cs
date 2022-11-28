using Npgsql;

namespace Core.Data
{
    public interface IDatabaseContext : IDisposable
    {
        NpgsqlConnection GetConnection();
    }
}
