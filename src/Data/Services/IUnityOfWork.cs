using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface IUnityOfWork
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        IDatabaseContext DataContext { get; }
        NpgsqlTransaction BeginTransaction();

        /// <summary>
        /// The Commit.
        /// </summary>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
        void Commit();
    }

}
